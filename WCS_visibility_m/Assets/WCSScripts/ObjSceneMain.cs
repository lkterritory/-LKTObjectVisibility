using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using ExcelDataReader;
using UnityEngine.Networking;
using System.Net;

namespace WCSScripts
{
    public class ObjSceneMain : MonoBehaviour
    {
        public DataManager mDm;

        public GameObject goMenuPan;

        public FreeCam freeCam;

        public GameObject objBuilding;

        public GameObject objFloor1;
        public GameObject objFloor2;

        public GameObject objStaticFloor1;
        public GameObject objStaticFloor2;

        public GameObject objFloorWeb1;
        public GameObject objFloorWeb2;

        public GameObject ObjFree;

        public float conSpeed = 3f;

        public GameObject goLibiCon3D1Top;
        public GameObject goLibiCon3D2Top;
        public GameObject goLibiCon3D2FTop;

        public List<RobotInfo> arrRobot2Top;
        public List<RobotInfo> arrRobot1Top;
        public List<RobotInfo> arrRobot2FTop;



        public GameObject goLibiConT1Top;
        public GameObject goLibiConT2Top;
        public GameObject goLibiConT3Top;
        public GameObject goLibiConT4Top;
        public GameObject goLibiConT5Top;
        public GameObject goLibiConT6Top;
        public GameObject goLibiConT7Top;
        public GameObject goLibiConT8Top;
        public GameObject goLibiConT8Base;

        public List<RobotInfo> arrRobotT8;
        public List<RobotInfo> arrRobotT7;
        public List<RobotInfo> arrRobotT6;
        public List<RobotInfo> arrRobotT5;
        public List<RobotInfo> arrRobotT4;
        public List<RobotInfo> arrRobotT3;
        public List<RobotInfo> arrRobotT2;
        public List<RobotInfo> arrRobotT1;
        public List<RobotInfo> arrRobotTBase;

        public List<RobotInfo> arrRobot3dBetween;

        public float fSecend = 0f;

        public List<GameObject> arrBox;
        public List<GameObject> arrBoxRed;


        public bool is1F;   // 1층일때
        public bool isHome; // home 일때

        public GameObject goProgress;


        public TextMeshProUGUI txtPer;


        int nInitIdx;

        //public GameObject objTarget;
        //public Material mtTarget;

        //public GameObject[] gameObjects;


        // Start is called before the first frame update

        private void Awake()
        {
            is1F = true;
            arrBox = new List<GameObject>();
            arrBoxRed = new List<GameObject>();

            nInitIdx = 0;
            txtPer.text = "0%";
        }

        public void onBtnHome()
        { // 홈(외관)
            isHome = true;

            moveFloor(0);

            // 69.07357, 20.56514, 62.07927
            // 39.397, -45.655, 0

            //if (speed != 0)
            //{
            //    speed = 0;
            //}
            //else
            //{
            //    speed = 3f;
            //}
        }

        public void onBtnUp()
        { // 2층
            is1F = false;

            moveFloor(2);

            // 69.07357, 20.56514, 62.07927
            // 39.397, -45.655, 0

            //if (speed != 0)
            //{
            //    speed = 0;
            //}
            //else
            //{
            //    speed = 3f;
            //}
        }

        public void onBtnDown()
        {// 1층
            is1F = true;
            moveFloor(1);

            // 123.8955, 20.23319, 33.99925
            // 33.476, -54.676



            //if(speed == 3f)
            //{
            //    speed = 1.5f;
            //}
            //else
            //{
            //    speed = 3f;
            //}
        }



        private void moveFloor(int aFloor)
        {
            if (aFloor == 0)
            {
                isHome = true;
                objFloorWeb1.SetActive(true);
                objStaticFloor1.SetActive(true);
                objFloorWeb2.SetActive(true);
                objStaticFloor2.SetActive(true);
                freeCam.moveFloor(aFloor);
            }
            else if (aFloor == 1)
            {
                isHome = false;
                objFloorWeb1.SetActive(true);
                objStaticFloor1.SetActive(true);
                objFloorWeb2.SetActive(false);
                objStaticFloor2.SetActive(false);
                freeCam.moveFloor(aFloor);
                //freeCam.transform.position = new Vector3(123.8955f, 20.23319f, 33.99925f);
            }
            else if (aFloor == 2)
            {
                isHome = false;
                objFloorWeb1.SetActive(false);
                objStaticFloor1.SetActive(false);
                objFloorWeb2.SetActive(true);
                objStaticFloor2.SetActive(true);
                freeCam.moveFloor(aFloor);
                //freeCam.transform.position = new Vector3(69.07357f, 20.56514f, 62.07927f);
            }
        }






        IEnumerator BoxMoveHTTP(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);


            // GET 방식
            string url = "https://naver.com";

            // UnityWebRequest에 내장되있는 GET 메소드를 사용한다.
            UnityWebRequest www = UnityWebRequest.Get(url);

            yield return www.SendWebRequest();  // 응답이 올때까지 대기한다.

            if (www.error == null)  // 에러가 나지 않으면 동작.
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("error");
            }



            GameObject myPrefab = mDm.copyPrefab("box_h");
            arrBox.Add(myPrefab);



            StartCoroutine("BoxMoveHTTP", 2f);
        }

        IEnumerator BoxMoveMQTT()
        {
            while (true)
            {

                yield return new WaitForSeconds(5f);
            }
        }




        void Update()
        {


            if (nInitIdx <= 24)
            {   // 로딩 제거?
                if (nInitIdx == 0)
                    txtPer.text = "0%";
                else
                {
                    txtPer.text = Mathf.RoundToInt((float)nInitIdx / 24f * 100f) + "%";

                    Debug.Log("perper:" + txtPer.text);
                }


                //StartCommon(nInitIdx);// 이건 안됨

                StartCoroutine(StartCommon(nInitIdx));


                nInitIdx++;

                Debug.Log(nInitIdx + "??");

                return;
            }
            else if (nInitIdx < 100)
            {   // 로딩후 한번 실행
                nInitIdx = 100;
                Debug.Log(nInitIdx + "else??else");

                moveFloor(0);

                goProgress.SetActive(false);
                goMenuPan.SetActive(true);

                return;
            }



            // 모든 로딩 끝난 후 실행
            // 박스 무빙
            foreach (GameObject goBoxH in arrBox)
            {
                goBoxH.transform.Translate(Vector3.forward * conSpeed * Time.deltaTime);  // 박스 무빙

                if (goBoxH.transform.position.z >= 89.976)
                {
                    goBoxH.transform.position = new Vector3(24.1f, goBoxH.transform.position.y, 55f);
                }
            }



        }

        private void LateUpdate()
        {

        }

        void Start()
        {
            goMenuPan.SetActive(false);



            //#if UNITY_WEBGL && !UNITY_EDITOR
#if true
#else
        TextAsset excelFile = Resources.Load("Data/visualizor_data0227") as TextAsset;

        Debug.Log("bytelen:" + excelFile.bytes.Length);

        MemoryStream stream = new MemoryStream(excelFile.bytes);
        IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);


        var tables = reader.AsDataSet().Tables;

        for (var sheetIndex = 0; sheetIndex < tables.Count; sheetIndex++)
        {
            var sheet = tables[sheetIndex];

            Debug.Log("sheet:" + sheet.TableName);



            if (sheet.TableName == "wcsv_conveyor")
            {
                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
                {// 행 루프 0번째는 컬럼



                    // 행 가져오기
                    var slot = sheet.Rows[rowIndex];
                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
                    {
                        break;
                    }



                    WModelInfo modelInfo = new WModelInfo();



                    Debug.Log(slot.ItemArray[0] + slot.ItemArray[2].ToString());

                    modelInfo.obj_type = slot.ItemArray[0].ToString();
                    modelInfo.len_x = float.Parse(slot.ItemArray[2].ToString());
                    modelInfo.len_y = float.Parse(slot.ItemArray[3].ToString());
                    modelInfo.len_z = float.Parse(slot.ItemArray[4].ToString());

                    mDm.mArrModelInfo.Add(modelInfo);

                }


            }

            if (sheet.TableName == "wcsv_conveyor_position" || sheet.TableName == "wcsv_conveyor_2f_position")
            {   // 생성
                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
                {// 행 루프 0번째는 컬럼


                    // 행 가져오기
                    var slot = sheet.Rows[rowIndex];
                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
                    {
                        break;
                    }

                    for (int i = 0; i < mDm.mArrModelInfo.Count; i++)
                    {
                        WModelInfo modelInfo = mDm.mArrModelInfo[i] as WModelInfo;


                        if (modelInfo.obj_type == null || modelInfo.obj_type == "")
                        {
                            continue;
                        }



                        if (modelInfo.obj_type == slot.ItemArray[0].ToString())
                        {
                            WModel model = new WModel();
                            model.info = modelInfo;

                            //model.pos_x = float.Parse(slot.ItemArray[2].ToString()) + (modelInfo.len_x * 0.5f);
                            //model.pos_y = float.Parse(slot.ItemArray[3].ToString()) + (modelInfo.len_y * 0.5f); 
                            //model.pos_z = float.Parse(slot.ItemArray[4].ToString()) + (modelInfo.len_z * 0.5f);

                            model.pos_x = float.Parse(slot.ItemArray[2].ToString());
                            model.pos_y = float.Parse(slot.ItemArray[3].ToString());
                            model.pos_z = float.Parse(slot.ItemArray[4].ToString());
                            model.floor = int.Parse(slot.ItemArray[5].ToString());

                            model.scale_x = float.Parse(slot.ItemArray[6].ToString());
                            model.scale_y = float.Parse(slot.ItemArray[7].ToString());
                            model.scale_z = float.Parse(slot.ItemArray[8].ToString());



                            // 프리팹으로 만들 게임 오브젝트

                            //GameObject myPrefab = Resources.Load<GameObject>(model.info.obj_type);

                            GameObject myPrefab = mDm.copyPrefab(model.info.obj_type);

                            




                            // 프리팹 생성
                            GameObject instantiatedPrefab = myPrefab;//Instantiate(myPrefab);

                            if(!sheet.TableName.Contains("2f"))
                                instantiatedPrefab.transform.parent = objFloor1.transform;
                            else
                                instantiatedPrefab.transform.parent = objFloor2.transform;

                            if (instantiatedPrefab.name == "libiRackRight(Clone)")
                            {
                                instantiatedPrefab.tag = instantiatedPrefab.name;
                                Debug.Log("name:" + instantiatedPrefab.name);
                                Debug.Log("tag:" + instantiatedPrefab.tag);
                            }


                            instantiatedPrefab.transform.localPosition = new Vector3(model.pos_x, model.pos_y, model.pos_z);
                            //instantiatedPrefab.transform.localScale = new Vector3(model.scale_x, model.scale_y, model.scale_z);

                            model.objPrefab = instantiatedPrefab;


                            // 모델정보  모두저장
                            mDm.mArrModel.Add(model);


                            break;
                        }
                    }
                }

            }
            else if (sheet.TableName == "wcsv_conveyor_position_h" || sheet.TableName == "wcsv_conveyor_2f_position_h")
            {   // 생성
                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
                {// 행 루프 0번째는 컬럼


                    // 행 가져오기
                    var slot = sheet.Rows[rowIndex];
                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
                    {
                        break;
                    }

                    for (int i = 0; i < mDm.mArrModelInfo.Count; i++)
                    {
                        WModelInfo modelInfo = mDm.mArrModelInfo[i] as WModelInfo;


                        if (modelInfo.obj_type == null || modelInfo.obj_type == "")
                        {
                            continue;
                        }



                        if (modelInfo.obj_type == slot.ItemArray[0].ToString())
                        {
                            WModel model = new WModel();
                            model.info = modelInfo;

                            //model.pos_x = float.Parse(slot.ItemArray[2].ToString()) + (modelInfo.len_x * 0.5f);
                            //model.pos_y = float.Parse(slot.ItemArray[3].ToString()) + (modelInfo.len_y * 0.5f); 
                            //model.pos_z = float.Parse(slot.ItemArray[4].ToString()) + (modelInfo.len_z * 0.5f);

                            model.pos_x = float.Parse(slot.ItemArray[2].ToString());
                            model.pos_y = float.Parse(slot.ItemArray[3].ToString());
                            model.pos_z = float.Parse(slot.ItemArray[4].ToString());
                            model.floor = int.Parse(slot.ItemArray[5].ToString());

                            model.scale_x = float.Parse(slot.ItemArray[6].ToString());
                            model.scale_y = float.Parse(slot.ItemArray[7].ToString());
                            model.scale_z = float.Parse(slot.ItemArray[8].ToString());

                            

                            // 프리팹으로 오브젝트

                            //GameObject myPrefab = Resources.Load<GameObject>(model.info.obj_type);

                            GameObject myPrefab = mDm.copyPrefab(model.info.obj_type);





                            
                            // 프리팹 생성
                            GameObject instantiatedPrefab = myPrefab;//Instantiate(myPrefab);

                            if (!sheet.TableName.Contains("2f"))
                                instantiatedPrefab.transform.parent = objFloor1.transform;
                            else
                                instantiatedPrefab.transform.parent = objFloor2.transform;
                            
                            instantiatedPrefab.transform.localPosition = new Vector3(model.pos_x, model.pos_y, model.pos_z);

                            instantiatedPrefab.transform.localEulerAngles = new Vector3(0, 90, 0);
                            Transform tfCon = instantiatedPrefab.transform.Find("Conveyor_Belt");
                            if (tfCon != null)
                            {
                                tfCon.localPosition = new Vector3(
                                    -tfCon.localPosition.x,
                                    tfCon.localPosition.y,
                                    tfCon.localPosition.z);
                            }

                            Transform tfLeg = instantiatedPrefab.transform.Find("con_leg");
                            if (tfLeg != null)
                            {
                                tfLeg.localPosition = new Vector3(
                                    -1,
                                    tfLeg.localPosition.y,
                                    tfLeg.localPosition.z);

                                if (instantiatedPrefab.transform.localPosition.y != 0)
                                {
                                    tfLeg.gameObject.SetActive(false);
                                }
                            }







                            model.objPrefab = instantiatedPrefab;


                            // 모델정보  모두저장
                            mDm.mArrModel.Add(model);


                            break;
                        }
                    }
                }

            }



            ////시트 이름 필터링 가능
            ////Debug.Log($"Sheet[{sheetIndex}] Name: {sheet.TableName}");

            //for (var rowIndex = 0; rowIndex < sheet.Rows.Count; rowIndex++)
            //{// 행 루프

            //    // 행 가져오기
            //    var slot = sheet.Rows[rowIndex];
            //    for (var columnIndex = 0; columnIndex < slot.ItemArray.Length; columnIndex++)
            //    {// 열 루프
            //        var item = slot.ItemArray[columnIndex];


            //        // 열 가져오기
            //        //Debug.Log($"slot[{rowIndex}][{columnIndex}] : {item}");
            //    }
            //}
        }
        reader.Dispose();
        reader.Close();

        //int nIdx = 0;
        //while (reader.Read())
        //{

        //    // 열 인덱스 또는 열 이름으로 데이터에 액세스합니다.
        //    string value = reader.GetString(0); // 첫 번째 열의 인덱스는 0입니다.
        //                                        // 값에 대해 필요한 작업을 수행합니다...




        //    Debug.Log(reader.Name + nIdx.ToString() + ":" + value);

        //    nIdx++;
        //}


        //reader.Close();
        //stream.Close();
#endif





            //StartCoroutine("BoxMoveHTTP", 2f);
        }



        //void InitPath3D()
        //{
        //    float nXMax = 31.05f;   // 22.05 // 1.8(base)
        //    float nZMax = 1.772f;   // 34.622(base)


        //        Init3D1_2(nXMax, nZMax);

        //        Init3D2_2(nXMax, nZMax);

        //        Init3D2F_2(nXMax, nZMax);
        //}


        IEnumerator StartCommon(int aIdx)
        {
            {
                if (aIdx == 0)
                {
                    Init3D1();
                }
                if (aIdx == 1)
                {
                    Init3D2();
                }
                if (aIdx == 2)
                    Init3D2F();

                float nXMax = 31.05f;   // 22.05 // 1.8(base)
                float nZMax = 1.772f;   // 34.622(base)

                if (aIdx == 3)
                    Init3D1_2(nXMax, nZMax);
                if (aIdx == 4)
                    Init3D2_2(nXMax, nZMax);
                if (aIdx == 5)
                    Init3D2F_2(nXMax, nZMax);
            }


            {
                if (aIdx == 6)
                    InitT1();
                if (aIdx == 7)
                    InitT2();
                if (aIdx == 8)
                    InitT3();
                if (aIdx == 9)
                    InitT4();
                if (aIdx == 10)
                    InitT5();
                if (aIdx == 11)
                    InitT6();
                if (aIdx == 12)
                    InitT7();
                if (aIdx == 13)
                    InitT8();

                float nXMax = 22.05f; // 31.05 // 1.8(base)
                float nZMax = 1.772f;   // 34.622(base)

                if (aIdx == 14)
                    InitT1_2(nXMax, nZMax);

                if (aIdx == 15)
                    InitT2_2(nXMax, nZMax);

                if (aIdx == 16)
                    InitT3_2(nXMax, nZMax);
                if (aIdx == 17)
                    InitT4_2(nXMax, nZMax);
                if (aIdx == 18)
                    InitT5_2(nXMax, nZMax);
                if (aIdx == 19)
                    InitT6_2(nXMax, nZMax);
                if (aIdx == 20)
                    InitT7_2(nXMax, nZMax);
                if (aIdx == 21)
                    InitT8_2(nXMax, nZMax);
            }
            {
                if (aIdx == 22)
                    InitTBase();

                float nXMax = 1.8f;     // 22.05, 31.05
                float nZMax = 34.622f;   // 1.772

                if (aIdx == 23)
                    InitTBase_2(nXMax, nZMax);

            }
            {
                if (aIdx == 24)
                    InitBetween();

            }


            yield return null;
        }

        private void InitBetween()
        {
            GameObject[] arrGoLibiRight = GameObject.FindGameObjectsWithTag("libiRackRight(Clone)");

            arrRobot3dBetween = new List<RobotInfo>();

            foreach (GameObject goTmp in arrGoLibiRight)
            {
                int nCnt = goTmp.transform.childCount - 1;
                for (int i = 0; i < nCnt; i++)
                {
                    arrRobot3dBetween.Add((RobotInfo)goTmp.transform.GetChild(i).GetComponent<RobotInfo>());
                }
            }

            float nYMin = 1f; // 2f
            float nYMax = 1.5f;     // 2.5f 
            float nZMax = 1.772f;   // 1.772



            for (int i = 0; i < arrRobot3dBetween.Count; i++)
            {
                arrRobot3dBetween[i].isBetween = true;
                if (arrRobot3dBetween[i].name.Contains("2"))
                {
                    nYMin = 2f;
                    nYMax = 2.5f;
                }
                else
                {
                    nYMin = 1f; // 2f
                    nYMax = 1.5f;     // 2.5f 
                }

                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobot3dBetween[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobot3dBetween[i].transform.localPosition.z, arrRobot3dBetween[i].transform.localPosition.y);


                arrRobot3dBetween[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPathBetween(moveInfo, arrRobot3dBetween, arrRobot3dBetween[i], nYMin, nYMax, nZMax);
            }
        }

        private void InitTBase_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotTBase.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotTBase[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotTBase[i].transform.localPosition.x, arrRobotTBase[i].transform.localPosition.z);

                arrRobotTBase[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotTBase, arrRobotTBase[i], nXMax, nZMax);
            }
        }

        private void InitTBase()
        {
            int nCnt = goLibiConT8Base.transform.childCount - 1;
            arrRobotTBase = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotTBase.Add((RobotInfo)goLibiConT8Base.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT8_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT8.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT8[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT8[i].transform.localPosition.x, arrRobotT8[i].transform.localPosition.z);

                arrRobotT8[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT8, arrRobotT8[i], nXMax, nZMax);
            }
        }

        private void InitT7_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT7.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT7[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT7[i].transform.localPosition.x, arrRobotT7[i].transform.localPosition.z);

                arrRobotT7[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT7, arrRobotT7[i], nXMax, nZMax);
            }
        }

        private void InitT6_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT6.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT6[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT6[i].transform.localPosition.x, arrRobotT6[i].transform.localPosition.z);

                arrRobotT6[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT6, arrRobotT6[i], nXMax, nZMax);
            }
        }

        private void InitT5_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT5.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT5[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT5[i].transform.localPosition.x, arrRobotT5[i].transform.localPosition.z);

                arrRobotT5[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT5, arrRobotT5[i], nXMax, nZMax);
            }
        }

        private void InitT4_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT4.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT4[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT4[i].transform.localPosition.x, arrRobotT4[i].transform.localPosition.z);

                arrRobotT4[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT4, arrRobotT4[i], nXMax, nZMax);
            }
        }

        private void InitT3_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT3.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT3[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT3[i].transform.localPosition.x, arrRobotT3[i].transform.localPosition.z);

                arrRobotT3[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT3, arrRobotT3[i], nXMax, nZMax);
            }
        }

        private void InitT2_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT2.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT2[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT2[i].transform.localPosition.x, arrRobotT2[i].transform.localPosition.z);

                arrRobotT2[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT2, arrRobotT2[i], nXMax, nZMax);
            }
        }

        private void InitT1_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobotT1.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobotT1[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobotT1[i].transform.localPosition.x, arrRobotT1[i].transform.localPosition.z);

                arrRobotT1[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobotT1, arrRobotT1[i], nXMax, nZMax);
            }
        }

        private void InitT8()
        {
            int nCnt = goLibiConT8Top.transform.childCount - 1;
            arrRobotT8 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT8.Add((RobotInfo)goLibiConT8Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT7()
        {
            int nCnt = goLibiConT7Top.transform.childCount - 1;
            arrRobotT7 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT7.Add((RobotInfo)goLibiConT7Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT6()
        {
            int nCnt = goLibiConT6Top.transform.childCount - 1;
            arrRobotT6 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT6.Add((RobotInfo)goLibiConT6Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT5()
        {
            int nCnt = goLibiConT5Top.transform.childCount - 1;
            arrRobotT5 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT5.Add((RobotInfo)goLibiConT5Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT4()
        {
            int nCnt = goLibiConT4Top.transform.childCount - 1;
            arrRobotT4 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT4.Add((RobotInfo)goLibiConT4Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT3()
        {
            int nCnt = goLibiConT3Top.transform.childCount - 1;
            arrRobotT3 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT3.Add((RobotInfo)goLibiConT3Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT2()
        {
            int nCnt = goLibiConT2Top.transform.childCount - 1;
            arrRobotT2 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT2.Add((RobotInfo)goLibiConT2Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void InitT1()
        {
            int nCnt = goLibiConT1Top.transform.childCount - 1;
            arrRobotT1 = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobotT1.Add((RobotInfo)goLibiConT1Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void Init3D2F_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobot2FTop.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobot2FTop[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobot2FTop[i].transform.localPosition.x, arrRobot2FTop[i].transform.localPosition.z);

                arrRobot2FTop[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot2FTop, arrRobot2FTop[i], nXMax, nZMax);
                //arrRobot2FTop[i].arrMove = arrMoveInfo;
            }
        }

        private void Init3D2_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobot2Top.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobot2Top[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobot2Top[i].transform.localPosition.x, arrRobot2Top[i].transform.localPosition.z);

                arrRobot2Top[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot2Top, arrRobot2Top[i], nXMax, nZMax);
                //arrRobot2Top[i].arrMove = arrMoveInfo;
            }
        }

        private void Init3D1_2(float nXMax, float nZMax)
        {
            for (int i = 0; i < arrRobot1Top.Count; i++)
            {
                RobotMoveInfo moveInfo = new RobotMoveInfo();
                moveInfo.degree = Mathf.RoundToInt(arrRobot1Top[i].transform.GetChild(0).localEulerAngles.y);
                moveInfo.vec2Posi = new Vector2(arrRobot1Top[i].transform.localPosition.x, arrRobot1Top[i].transform.localPosition.z);

                arrRobot1Top[i].arrMove = new List<RobotMoveInfo>();
                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot1Top, arrRobot1Top[i], nXMax, nZMax);
                //arrRobot1Top[i].arrMove = arrMoveInfo;
            }
        }

        private void Init3D2F()
        {
            int nCnt = goLibiCon3D2FTop.transform.childCount - 1;
            arrRobot2FTop = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobot2FTop.Add((RobotInfo)goLibiCon3D2FTop.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void Init3D2()
        {
            int nCnt = goLibiCon3D2Top.transform.childCount - 1;
            arrRobot2Top = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobot2Top.Add((RobotInfo)goLibiCon3D2Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

        private void Init3D1()
        {
            int nCnt = goLibiCon3D1Top.transform.childCount - 1;
            arrRobot1Top = new List<RobotInfo>();
            for (int i = 0; i < nCnt; i++)
            {
                arrRobot1Top.Add((RobotInfo)goLibiCon3D1Top.transform.GetChild(i).GetComponent<RobotInfo>());
            }
        }

    }

}