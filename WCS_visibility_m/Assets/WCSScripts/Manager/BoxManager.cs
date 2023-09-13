using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WCSScripts.Model.Box;
using WCSScripts.Model.HTTP.Base;
using WCSScripts.Model.HTTP.Test;
using Newtonsoft.Json;
using System;
using UnityEngine.XR;
using UnityEngine.UIElements;

namespace WCSScripts.Manager
{
    public class BoxManager : MonoBehaviour
    {
        public PathManager pathManager;

        public List<BoxObj> mArrBox;

        public List<BoxObj> mArrBoxWillActive;
        
        private float startTime = 0;
        private float addTime;
        private int nActiveIdx = 0;

        public GameObject goBoxInputTote1;
        public GameObject goBoxInputTote2;
        public GameObject goBoxInputBox1;
        public GameObject goBoxInputBox2;
        public GameObject goBoxInputBox3;
        public GameObject goBoxInputBox4;
        public GameObject goBoxInputBox5;
        public GameObject goBoxOutputBox1;
        public GameObject goBoxOutputBox2;

        public HttpCommunicationModule httpModule;

        public GameObject prefabBox;

        public List<GameObject> mArrBoxRemaining;

        public GameObject objCameraMain;


        private bool isFirstSearch = true;

        private void Awake()
        {

            mArrBoxWillActive = new List<BoxObj>();
            mArrBox = new List<BoxObj>();
            

            mArrBoxRemaining = new List<GameObject>();


            for (int i = 0; i < 1000; i++)
            {   // 박스들 미리 생성
                GameObject newGameObject = Instantiate(prefabBox);
                newGameObject.transform.parent = this.transform;
                newGameObject.SetActive(false);
                mArrBoxRemaining.Add(newGameObject);
            }

            //newGameObject.SetActive(true);
        }

        // Use this for initialization
        void Start()
        {
            //httpModule = GetComponent<HttpCommunicationModule>();
            httpModule.ResponseReceived += HandleResponse; // 이벤트 구독

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

            //// GET 요청 보내기
            //StartCoroutine(httpModule.GetRequest(svcTest));



            // // // 더미데이터(test)
            //ServiceDashboard3D.BodyDashboard3DResAll resAll = JsonConvert.DeserializeObject<ServiceDashboard3D.BodyDashboard3DResAll>(Dummy3DData.strDummy1);

            //List<ServiceDashboard3D.BodyDashboard3DRes> lktBodyRef = new List<ServiceDashboard3D.BodyDashboard3DRes>();


            //for (int i = 0; i < resAll.lktBody.Count; i++)
            //{
            //    if (resAll.lktBody[i].bcrCode == "NOREAD" ||
            //       resAll.lktBody[i].logMessage == "TOTE Box 매칭" ||
            //       resAll.lktBody[i].logMessage == "오토라벨출력" ||
            //       resAll.lktBody[i].logMessage == "바코드 검증" ||
            //       resAll.lktBody[i].logMessage == "박스 분기")
            //    {   // 박스 분기
            //        continue;
            //    }

            //    bool isFind = false;
            //    foreach(ServiceDashboard3D.BodyDashboard3DRes bodyTmp in lktBodyRef)
            //    {
            //        if(resAll.lktBody[i].objCode == bodyTmp.objCode)
            //        {
            //            isFind = true;
            //            break;
            //        }
            //    }

            //    if(!isFind)
            //        lktBodyRef.Add(resAll.lktBody[i]);
            //}


            //Debug.Log("counttttt lktbody: " + resAll.lktBody.Count);
            //Debug.Log("counttttt lktbodyRef: " + lktBodyRef.Count);

            //for (int i = lktBodyRef.Count - 1; i >= 0; i--) // 역순
            //{

            //    if (lktBodyRef[i].bcrCode == "NOREAD" ||
            //        lktBodyRef[i].logMessage == "TOTE Box 매칭" ||
            //        lktBodyRef[i].logMessage == "오토라벨출력" ||
            //        lktBodyRef[i].logMessage == "바코드 검증" ||
            //        lktBodyRef[i].logMessage == "박스 분기")
            //    {   // 박스 분기
            //        // 1번째 컨베이어 분기
            //        // 2번째 컨베이어 분기

            //        continue;
            //    }

            //    bool isFind = false;

            //    foreach (BoxObj objTmp in mArrBox)
            //    {
            //        //if (lktBodyRef[i].objCode == "X" && objTmp.boxInfo.objCode == "X")
            //        if (false)   // X 도 막는다(데이터유효성이 많이 안좋음 좀비 오브젝트 된다
            //        {// 오픈카톤
            //            if (lktBodyRef[i].bcrCode == objTmp.boxInfo.bcrCode)
            //            {
            //                objTmp.boxInfo.logCall = lktBodyRef[i].logCall;
            //                objTmp.boxInfo.logCode = lktBodyRef[i].logCode;
            //                objTmp.boxInfo.logMessage = lktBodyRef[i].logMessage;
            //                objTmp.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
            //                objTmp.boxInfo.addDateTime = lktBodyRef[i].addDateTime;

            //                objTmp.LoadBoxInfo();
            //                isFind = true;
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            if (lktBodyRef[i].objCode == objTmp.boxInfo.objCode)
            //            {
            //                objTmp.boxInfo.bcrCode = lktBodyRef[i].bcrCode;
            //                objTmp.boxInfo.logCall = lktBodyRef[i].logCall;
            //                objTmp.boxInfo.logCode = lktBodyRef[i].logCode;
            //                objTmp.boxInfo.logMessage = lktBodyRef[i].logMessage;
            //                objTmp.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
            //                objTmp.boxInfo.addDateTime = lktBodyRef[i].addDateTime;


            //                objTmp.LoadBoxInfo();
            //                isFind = true;
            //                break;
            //            }
            //        }
            //    }

            //    if (!isFind)
            //    {
            //        BoxObj boxNew = this.GetNewBox();

            //        if (boxNew == null)
            //        {
            //            Debug.Log("boxNew == null");
            //        }
            //        else
            //        {


            //            boxNew.boxManager = this;
            //            boxNew.pathManager = this.pathManager;
            //            boxNew.boxInfo = new BoxInfo();

            //            boxNew.boxInfo.objCode = lktBodyRef[i].objCode;
            //            boxNew.boxInfo.bcrCode = lktBodyRef[i].bcrCode;
            //            boxNew.boxInfo.logCall = lktBodyRef[i].logCall;
            //            boxNew.boxInfo.logCode = lktBodyRef[i].logCode;
            //            boxNew.boxInfo.logMessage = lktBodyRef[i].logMessage;
            //            boxNew.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
            //            boxNew.boxInfo.addDateTime = lktBodyRef[i].addDateTime;
            //            boxNew.LoadBoxInfo();

            //            mArrBox.Add(boxNew);
            //        }
            //    }
            //}



            return;

            // test
            //for (int i = 0; i < goBoxInputTote1.transform.childCount; i++)
            //{
            //    mArrBox.Add(goBoxInputTote1.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputTote2.transform.childCount)
            //        mArrBox.Add(goBoxInputTote2.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputBox1.transform.childCount)
            //        mArrBox.Add(goBoxInputBox1.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputBox2.transform.childCount)
            //        mArrBox.Add(goBoxInputBox2.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputBox3.transform.childCount)
            //        mArrBox.Add(goBoxInputBox3.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputBox4.transform.childCount)
            //        mArrBox.Add(goBoxInputBox4.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxInputBox5.transform.childCount)
            //        mArrBox.Add(goBoxInputBox5.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxOutputBox1.transform.childCount)
            //        mArrBox.Add(goBoxOutputBox1.transform.GetChild(i).GetComponent<BoxObj>());

            //    if (i < goBoxOutputBox2.transform.childCount)
            //        mArrBox.Add(goBoxOutputBox2.transform.GetChild(i).GetComponent<BoxObj>());
            //}

        }



        // Update is called once per frame
        void Update()
        {



            // test
            //if (nActiveIdx < mArrBox.Count)
            //{
            //    startTime += Time.deltaTime;
            //    if (startTime > 0.5f)
            //    {
            //        mArrBox[nActiveIdx].gameObject.SetActive(true);
            //        nActiveIdx++;
            //        startTime = 0;
            //    }

            //    return;
            //}





            
            startTime += Time.deltaTime;
            if (startTime >= 1f)
            {
                ServiceDashboard3D svcTest = new ServiceDashboard3D();
                svcTest.strUrl = "http://192.168.42.70:2007/dashboard/3d";
                svcTest.payload.lktBody = new List<LktBody>();

                ServiceDashboard3D.BodyDashboard3D body = new ServiceDashboard3D.BodyDashboard3D();
                System.DateTime currentTime = Dummy3DData.GetCurrentTime();
                System.DateTime oneHourAgo;
                //if (isFirstSearch)
                //{
                //    oneHourAgo = currentTime.AddHours(-2);
                //    isFirstSearch = false;
                //}
                //else
                //{
                    oneHourAgo = currentTime.AddSeconds(-2);
                //}

                
                //System.DateTime oneHourAgo = currentTime(-2);

                string formattedCurrentTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
                string formattedOneHourAgo = oneHourAgo.ToString("yyyy-MM-dd HH:mm:ss");

                body.currentTimeStart = formattedOneHourAgo;
                body.currentTimeEnd = formattedCurrentTime;
                svcTest.payload.lktBody.Add(body);

                // GET 요청 보내기
                StartCoroutine(httpModule.GetRequest(svcTest));



                






                startTime = 0;
            }


            if (mArrBoxWillActive.Count > 0)
            {
                /// 이부분을 업데이트에
                mArrBoxWillActive[0].isUse = true;
                mArrBoxWillActive[0].boxManager = this;
                mArrBoxWillActive[0].pathManager = this.pathManager;


                mArrBoxWillActive[0].LoadBoxInfo();


                mArrBoxWillActive.RemoveAt(0);
                ///
            }


        }


        public BoxObj GetNewBox()
        {
            BoxObj box = null;

            foreach (GameObject objTmp in mArrBoxRemaining)
            {
                BoxObj tmp = objTmp.GetComponent<BoxObj>();
                if (!tmp.isUse)
                {
                    tmp.objCameraMain = this.objCameraMain;
                    
                    box = tmp;
                    
                    
                    break;
                }
                
            }


            return box;
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



                List<ServiceDashboard3D.BodyDashboard3DRes> lktBodyRef = new List<ServiceDashboard3D.BodyDashboard3DRes>();


                for (int i = 0; i < svcDashboard3D.lktBodyResAll.lktBody.Count; i++)
                {
                    if (svcDashboard3D.lktBodyResAll.lktBody[i].bcrCode == "NOREAD" ||
                       svcDashboard3D.lktBodyResAll.lktBody[i].logMessage == "TOTE Box 매칭" ||
                       svcDashboard3D.lktBodyResAll.lktBody[i].logMessage == "오토라벨출력" ||
                       svcDashboard3D.lktBodyResAll.lktBody[i].logMessage == "바코드 검증" ||
                       svcDashboard3D.lktBodyResAll.lktBody[i].logMessage == "박스 분기")
                    {   // 박스 분기
                        continue;
                    }

                    bool isFind = false;
                    foreach (ServiceDashboard3D.BodyDashboard3DRes bodyTmp in lktBodyRef)
                    {
                        if (svcDashboard3D.lktBodyResAll.lktBody[i].objCode == bodyTmp.objCode)
                        {
                            isFind = true;
                            break;
                        }
                    }

                    if (!isFind)
                        lktBodyRef.Add(svcDashboard3D.lktBodyResAll.lktBody[i]);
                }

                
                Debug.Log("counttttt lktbody: " + svcDashboard3D.lktBodyResAll.lktBody.Count);
                Debug.Log("counttttt lktbodyRef: " + lktBodyRef.Count);

                for (int i = lktBodyRef.Count - 1; i >= 0; i--) // 역순
                {

                    // test
                    //if (lktBodyRef[i].logMessage == "1번째 컨베이어 분기")
                    //{
                        //if (i % 7 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 1 로 컨베이어 분기 명령 전송";
                        //else if (i % 6 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 3 로 컨베이어 분기 명령 전송";
                        //else if (i % 5 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 5 로 컨베이어 분기 명령 전송";
                        //else if (i % 4 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 7 로 컨베이어 분기 명령 전송";
                        //else if (i % 3 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 9 로 컨베이어 분기 명령 전송";
                        //else if (i % 2 == 0)
                            //lktBodyRef[i].logDetailMessage = "1번째 컨베이어 분기 : 99 로 컨베이어 분기 명령 전송";
                    //}

                    if (lktBodyRef[i].bcrCode == "NOREAD" ||
                        lktBodyRef[i].logMessage == "TOTE Box 매칭" ||
                        lktBodyRef[i].logMessage == "오토라벨출력" ||
                        lktBodyRef[i].logMessage == "바코드 검증" ||
                        lktBodyRef[i].logMessage == "박스 분기")
                    {   // 박스 분기
                        // 1번째 컨베이어 분기
                        // 2번째 컨베이어 분기

                        continue;
                    }

                    bool isFind = false;

                    foreach (BoxObj objTmp in mArrBox)
                    {
                        //if (lktBodyRef[i].objCode == "X" && objTmp.boxInfo.objCode == "X")
                        if (false)   // X 도 막고 자동생성한다(데이터유효성이 많이 안좋음 좀비 오브젝트 된다
                        {// 오픈카톤
                            if (lktBodyRef[i].bcrCode == objTmp.boxInfo.bcrCode)
                            {
                                objTmp.boxInfo.logCall = lktBodyRef[i].logCall;
                                objTmp.boxInfo.logCode = lktBodyRef[i].logCode;
                                objTmp.boxInfo.logMessage = lktBodyRef[i].logMessage;
                                objTmp.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
                                objTmp.boxInfo.addDateTime = lktBodyRef[i].addDateTime;

                                objTmp.LoadBoxInfo();
                                isFind = true;
                                break;
                            }
                        }
                        else
                        {
                            if (lktBodyRef[i].objCode == objTmp.boxInfo.objCode)
                            {
                                objTmp.boxInfo.bcrCode = lktBodyRef[i].bcrCode;
                                objTmp.boxInfo.logCall = lktBodyRef[i].logCall;
                                objTmp.boxInfo.logCode = lktBodyRef[i].logCode;
                                objTmp.boxInfo.logMessage = lktBodyRef[i].logMessage;
                                objTmp.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
                                objTmp.boxInfo.addDateTime = lktBodyRef[i].addDateTime;



                                mArrBoxWillActive.Add(objTmp);

                                //objTmp.LoadBoxInfo();
                                isFind = true;
                                break;
                            }
                        }
                    }

                    if (!isFind)
                    {
                        BoxObj boxNew = this.GetNewBox();

                        if (boxNew == null)
                        {
                            Debug.Log("boxNew == null");
                        }
                        else
                        {
                            boxNew.boxInfo = new BoxInfo();
                            boxNew.boxInfo.objCode = lktBodyRef[i].objCode;
                            boxNew.boxInfo.bcrCode = lktBodyRef[i].bcrCode;
                            boxNew.boxInfo.logCall = lktBodyRef[i].logCall;
                            boxNew.boxInfo.logCode = lktBodyRef[i].logCode;
                            boxNew.boxInfo.logMessage = lktBodyRef[i].logMessage;
                            boxNew.boxInfo.logDetailMessage = lktBodyRef[i].logDetailMessage;
                            boxNew.boxInfo.addDateTime = lktBodyRef[i].addDateTime;
                            boxNew.boxInfoPre = new BoxInfo();

                            mArrBox.Add(boxNew);
                            mArrBoxWillActive.Add(boxNew);


                            


                        }
                    }
                }





                Debug.Log("end");
            }


            //ServiceDashboard3D.BodyDashboard3D  
            //    JsonConvert.SerializeObject(svcBase.payload);
            //svcBase.payloadRes =
            // 여기서 원하는 처리 작업을 수행할 수 있습니다.
        }
    }

}