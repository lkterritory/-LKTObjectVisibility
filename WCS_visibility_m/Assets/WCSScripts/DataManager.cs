using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;
using WCSScripts.Model.HTTP;
using WCSScripts.Model.HTTP.Base;
using WCSScripts.Model.HTTP.Test;
using WCSScripts.Model.Box;

namespace WCSScripts
{

    public class DataManager : MonoBehaviour
    {
        public List<GameObject> mArrPrefab;


        public List<WModelInfo> mArrModelInfo;
        public List<WModel> mArrModel;

        public int nCntMove;


        //public List<BoxInfo> arrBoxInfo;

        public HttpCommunicationModule httpModule;

        void Awake()
        {
            mArrModelInfo = new List<WModelInfo>();
            mArrModel = new List<WModel>();


            nCntMove = 3600;
            //createLibiMap("");

            // HttpCommunicationModule 인스턴스 생성

            //httpModule = GetComponent<HttpCommunicationModule>();
            //httpModule.ResponseReceived += HandleResponse; // 이벤트 구독

            //ServiceDashboard3D svcTest = new ServiceDashboard3D();
            //svcTest.strUrl = "http://192.168.42.70:2007/dashboard/3d";
            //svcTest.payload.lktBody = new List<LktBody>();

            //ServiceDashboard3D.BodyDashboard3D body = new ServiceDashboard3D.BodyDashboard3D();
            //System.DateTime currentTime = System.DateTime.Now;
            //System.DateTime oneHourAgo = currentTime.AddHours(-3);

            //string formattedCurrentTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            //string formattedOneHourAgo = oneHourAgo.ToString("yyyy-MM-dd HH:mm:ss");

            //body.currentTimeStart = formattedOneHourAgo;
            //body.currentTimeEnd = formattedCurrentTime;
            //svcTest.payload.lktBody.Add(body);

            //// 더미데이터(통신 안될때 사용)
            //ServiceDashboard3D.BodyDashboard3DResAll  resAll = JsonConvert.DeserializeObject<ServiceDashboard3D.BodyDashboard3DResAll>(Dummy3DData.strDummy1);


            //// GET 요청 보내기
            //StartCoroutine(httpModule.GetRequest(svcTest));


        }

        private void HandleResponse(BaseService response)
        {
            // 응답 데이터 처리
            Debug.Log("Received response: " + response);
            
            //ServiceDashboard3D.BodyDashboard3DRes
            if (response is ServiceDashboard3D)
            {
                ServiceDashboard3D svcDashboard3D = (ServiceDashboard3D)response;

                
                svcDashboard3D.lktBodyResAll = JsonConvert.DeserializeObject<ServiceDashboard3D.BodyDashboard3DResAll>(svcDashboard3D.strResData);
                


                Debug.Log("end");
            }


            //ServiceDashboard3D.BodyDashboard3D  
            //    JsonConvert.SerializeObject(svcBase.payload);
            //svcBase.payloadRes =
            // 여기서 원하는 처리 작업을 수행할 수 있습니다.
        }


        public GameObject copyPrefab(string aName)
        {
            for (int i = 0; i < mArrPrefab.Count; i++)
            {
                if (mArrPrefab[i].name == aName)
                {

                    // 복제할 GameObject를 설정합니다.
                    GameObject newGameObject = Instantiate(mArrPrefab[i]);
                    newGameObject.SetActive(true);
                    return newGameObject;
                }
            }

            return null;
        }

        public IEnumerator MoveTest()
        {
            byte[] myData = System.Text.Encoding.UTF8.GetBytes("This is some test data");
            //UnityWebRequest www = UnityWebRequest.Get("http://naver.com", myData);
            UnityWebRequest www = UnityWebRequest.Get("http://naver.com");



            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Upload complete!");
            }
        }

        // 충돌비교 필요(일단 제거
        public List<RobotMoveInfo> createRobotPath(RobotMoveInfo rInfoDefault, List<RobotInfo> aRobotInfos, RobotInfo aRobotTarget, float aXMax, float aZMax)
        {
            List<RobotMoveInfo> arrVc2Posi = new List<RobotMoveInfo>();
            aRobotTarget.arrMove = arrVc2Posi;

            arrVc2Posi.Add(rInfoDefault);

            float nXMin = 0;
            //float nXMax = 31.05f; // 22.05 // 1.8(base)
            float nXMax = aXMax;
            float nXUnit = 0.45f;

            float nZMin = 0.422f;
            //float nZMax = 1.772f;   // 34.622(base)
            float nZMax = aZMax;
            float nZUnit = 0.45f;

            int nXMoveCntAll = Mathf.RoundToInt((nXMax - nXMin) / nXUnit) + 1;
            int nZMoveCntAll = Mathf.RoundToInt((nZMax - nZMin) / nZUnit) + 1;

            Debug.Log(nXMoveCntAll.ToString() + ":" + nZMoveCntAll.ToString());


            for (int i = 0; i < nCntMove; i++)
            {

                RobotMoveInfo infoPre = arrVc2Posi[arrVc2Posi.Count - 1];

                //1, 3
                // 방향
                int nDirect = Random.Range(0, 12);
                if (nDirect == 4 || nDirect == 5 || nDirect == 6 || nDirect == 7)
                {
                    if (nXMax > 10f)
                    {  // 가로길이가 긴 리비아오
                        nDirect = 1;
                    }
                    else
                    {                  // 세로길이가 긴 리비아오
                        nDirect = 0;
                    }
                }
                if (nDirect == 8 || nDirect == 9 || nDirect == 10 || nDirect == 11)
                {
                    if (nXMax > 10f)
                    {  // 가로길이가 긴 리비아오
                        nDirect = 3;
                    }
                    else
                    {                  // 세로길이가 긴 리비아오
                        nDirect = 2;
                    }

                }

                int nDegree = nDirect * 90;

                //if(infoPre != null)
                //{
                //    if(infoPre.degree == nDegree)
                //    {
                //        nDegree = -1;
                //    }
                //}




                RobotMoveInfo infoCur = new RobotMoveInfo();
                infoCur.degree = nDegree;
                infoCur.vec2Posi = infoPre.vec2Posi;
                //infoCur.degree = 90;


                if ((infoPre.degree == 90 && nDegree == 270) ||
                    (infoPre.degree == 270 && nDegree == 90) ||
                    (infoPre.degree == 0 && nDegree == 180) ||
                    (infoPre.degree == 180 && nDegree == 0))
                {
                    infoCur.degree = infoPre.degree;
                }


                if (i % 2 == 0)
                {// 도는 횠수 줄이기
                    infoCur.degree = infoPre.degree;
                }



                if (infoCur.degree == infoPre.degree)   // 방향전환이 없으면 이동
                {
                    float nPosiX = 0f;
                    float nPosiZ = 0f;

                    if (infoCur.degree == 0)
                    {
                        nPosiX = infoPre.vec2Posi.x;
                        nPosiZ = infoPre.vec2Posi.y + nZUnit;
                    }
                    else if (infoCur.degree == 90)
                    {
                        nPosiX = infoPre.vec2Posi.x + nXUnit;
                        nPosiZ = infoPre.vec2Posi.y;

                    }
                    else if (infoCur.degree == 180)
                    {
                        nPosiX = infoPre.vec2Posi.x;
                        nPosiZ = infoPre.vec2Posi.y - nZUnit;

                    }
                    else if (infoCur.degree == 270)
                    {
                        nPosiX = infoPre.vec2Posi.x - nXUnit;
                        nPosiZ = infoPre.vec2Posi.y;
                    }

                    // 범위 벗어나지 않도록
                    if (nPosiX < nXMin) nPosiX = nXMin;
                    if (nPosiX > nXMax) nPosiX = nXMax;
                    if (nPosiZ < nZMin) nPosiZ = nZMin;
                    if (nPosiZ > nZMax) nPosiZ = nZMax;



                    bool isFind = false;
                    foreach (RobotInfo rInfoTmp in aRobotInfos)
                    {
                        if (rInfoTmp == aRobotTarget)
                            continue;

                        else if (rInfoTmp.arrMove.Count == 0)
                            continue;

                        if (rInfoTmp.arrMove[i].vec2Posi.x == nPosiX &&
                            rInfoTmp.arrMove[i].vec2Posi.y == nPosiZ)
                        {
                            isFind = true;
                            break;
                        }
                    }
                    if (isFind) // 충돌인 경우 대기
                    {
                        infoCur.vec2Posi = infoPre.vec2Posi;
                    }
                    else
                    {// 정상이동
                        infoCur.vec2Posi = new Vector2(nPosiX, nPosiZ);
                    }

                    //infoCur.vec2Posi = new Vector2(nPosiX, nPosiZ);




                    //bool Random

                    //bool Random.value > 0.5f;


                    //방향전환구(같으면 안함) 
                    //
                    //Random * nXMove <- 충돌 체크하여 경로 변경

                }// 방향전환이 있으면 전환만



                arrVc2Posi.Add(infoCur);


            }

            Debug.Log("arrvcvc" + arrVc2Posi.ToString());









            return arrVc2Posi;
        }

        // 사이로봇 경로
        public List<RobotMoveInfo> createRobotPathBetween(RobotMoveInfo rInfoDefault, List<RobotInfo> aRobotInfos, RobotInfo aRobotTarget, float aYMin, float aYMax, float aZMax)
        {
            List<RobotMoveInfo> arrVc2Posi = new List<RobotMoveInfo>();
            aRobotTarget.arrMove = arrVc2Posi;

            arrVc2Posi.Add(rInfoDefault);

            float nYMin = aYMin;
            float nYMax = aYMax;
            float nYUnit = 0.5f;

            float nZMin = 0.275f;
            float nZMax = aZMax;
            float nZUnit = 0.37125f;
            //1.497



            int nYMoveCntAll = Mathf.RoundToInt((nYMax - nYMin) / nYUnit) + 1;
            int nZMoveCntAll = Mathf.RoundToInt((nZMax - nZMin) / nZUnit) + 1;

            Debug.Log(nYMoveCntAll.ToString() + ":" + nZMoveCntAll.ToString());

            //UnityWebRequest


            for (int i = 0; i < nCntMove; i++)
            {

                RobotMoveInfo infoPre = arrVc2Posi[arrVc2Posi.Count - 1];

                //1, 3
                // 방향
                int nDirect = Random.Range(0, 2);
                nDirect *= 2;

                int nDegree = nDirect * 90;

                RobotMoveInfo infoCur = new RobotMoveInfo();
                infoCur.degree = nDegree;
                infoCur.vec2Posi = infoPre.vec2Posi;


                if (i % 2 == 0)
                {// 도는 횠수 줄이기
                    infoCur.degree = infoPre.degree;
                }



                if (infoCur.degree == infoPre.degree)   // 방향전환이 없으면 이동
                {
                    float nPosiY = 0f;
                    float nPosiZ = 0f;

                    int nMoveIdx = Random.Range(0, 4);

                    if (nMoveIdx == 0)
                    {
                        nPosiZ = infoPre.vec2Posi.x + nZUnit;
                    }
                    else if (nMoveIdx == 1)
                    {
                        nPosiZ = infoPre.vec2Posi.x - nZUnit;
                    }
                    else if (nMoveIdx == 2)
                    {
                        nPosiY = infoPre.vec2Posi.y + nYUnit;
                    }
                    else if (nMoveIdx == 3)
                    {
                        nPosiY = infoPre.vec2Posi.y - nYUnit;
                    }



                    // 범위 벗어나지 않도록
                    if (nPosiY < nYMin) nPosiY = nYMin;
                    if (nPosiY > nYMax) nPosiY = nYMax;
                    if (nPosiZ < nZMin) nPosiZ = nZMin;
                    if (nPosiZ > nZMax) nPosiZ = nZMax;


                    infoCur.vec2Posi = new Vector2(nPosiZ, nPosiY);

                    //bool isFind = false;
                    //foreach (RobotInfo rInfoTmp in aRobotInfos)
                    //{
                    //    if (rInfoTmp == aRobotTarget)
                    //        continue;
                    //    else if (rInfoTmp.arrMove.Count == 0)
                    //        continue;

                    //    if (rInfoTmp.arrMove[i].vec2Posi.x == nPosiY &&
                    //        rInfoTmp.arrMove[i].vec2Posi.y == nPosiZ)
                    //    {
                    //        isFind = true;
                    //        break;
                    //    }
                    //}
                    //if (isFind) // 충돌인 경우 대기
                    //{
                    //    infoCur.vec2Posi = infoPre.vec2Posi;
                    //}
                    //else
                    //{// 정상이동

                    //}

                    //infoCur.vec2Posi = new Vector2(nPosiX, nPosiZ);




                    //bool Random

                    //bool Random.value > 0.5f;


                    //방향전환구(같으면 안함) 
                    //
                    //Random * nXMove <- 충돌 체크하여 경로 변경

                }// 방향전환이 있으면 전환만



                arrVc2Posi.Add(infoCur);


            }

            Debug.Log("arrvcvc" + arrVc2Posi.ToString());









            return arrVc2Posi;
        }

    }
}

