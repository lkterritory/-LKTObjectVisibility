//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;
//using ExcelDataReader;
//using UnityEngine.Networking;

//public class ObjSceneMain : MonoBehaviour
//{
//    public DataManager mDm;

//    public FreeCam freeCam;


//    public GameObject objBoxTmp;

//    public GameObject objFloor1;
//    public GameObject objFloor2;

//    public GameObject objStaticFloor1;
//    public GameObject objStaticFloor2;

//    public GameObject objFloorWeb1;
//    public GameObject objFloorWeb2;

//    public GameObject ObjFree;

//    public float speed = 3f;

//    public GameObject goLibiConT1Top;
//    public GameObject goLibiConT2Top;
//    public GameObject goLibiCon2FTop;

//    public List<RobotInfo> arrRobot2Top;
//    public List<RobotInfo> arrRobot1Top;
//    public List<RobotInfo> arrRobot2FTop;



//    public GameObject goLibiCon3d1Top;
//    public GameObject goLibiCon3d2Top;
//    public GameObject goLibiCon3d3Top;
//    public GameObject goLibiCon3d4Top;
//    public GameObject goLibiCon3d5Top;
//    public GameObject goLibiCon3d6Top;
//    public GameObject goLibiCon3d7Top;
//    public GameObject goLibiCon3d8Top;
//    public GameObject goLibiCon3d8Base;

//    public List<RobotInfo> arrRobot3d8;
//    public List<RobotInfo> arrRobot3d7;
//    public List<RobotInfo> arrRobot3d6;
//    public List<RobotInfo> arrRobot3d5;
//    public List<RobotInfo> arrRobot3d4;
//    public List<RobotInfo> arrRobot3d3;
//    public List<RobotInfo> arrRobot3d2;
//    public List<RobotInfo> arrRobot3d1;
//    public List<RobotInfo> arrRobot3dBase;

//    public List<RobotInfo> arrRobot3dBetween;

//    public float fSecend = 0f;

//    public List<GameObject> arrBox;
//    public List<GameObject> arrBoxRed;


//    public bool is1F;   // 1층일때

//    public GameObject goProgress;



    

//    //public GameObject objTarget;
//    //public Material mtTarget;

//    //public GameObject[] gameObjects;


//    // Start is called before the first frame update

//    private void Awake()
//    {
//        is1F = true;
//        arrBox = new List<GameObject>();
//        arrBoxRed = new List<GameObject>();
//    }

//    public void onBtnSpeed()
//    {// 1층
//        is1F = true;
//        moveFloor(1);

//        // 123.8955, 20.23319, 33.99925
//        // 33.476, -54.676



//        //if(speed == 3f)
//        //{
//        //    speed = 1.5f;
//        //}
//        //else
//        //{
//        //    speed = 3f;
//        //}
//    }



//    private void moveFloor(int aFloor)
//    {
//        if (aFloor == 1)
//        {
//            objFloorWeb1.SetActive(true);
//            objStaticFloor1.SetActive(true);
//            objFloorWeb2.SetActive(false);
//            objStaticFloor2.SetActive(false);
//            freeCam.moveFloor(aFloor);
//            //freeCam.transform.position = new Vector3(123.8955f, 20.23319f, 33.99925f);
//        }
//        else
//        {
//            objFloorWeb1.SetActive(false);
//            objStaticFloor1.SetActive(false);
//            objFloorWeb2.SetActive(true);
//            objStaticFloor2.SetActive(true);
//            freeCam.moveFloor(aFloor);
//            //freeCam.transform.position = new Vector3(69.07357f, 20.56514f, 62.07927f);
//        }
//    }

//    public void onBtnStop()
//    { // 2층
//        is1F = false;

//        moveFloor(2);

//        // 69.07357, 20.56514, 62.07927
//        // 39.397, -45.655, 0

//        //if (speed != 0)
//        //{
//        //    speed = 0;
//        //}
//        //else
//        //{
//        //    speed = 3f;
//        //}
//    }


//    void TestBoxMoveInfo()
//    {
//        objBoxTmp.transform.Translate(Vector3.forward * speed * Time.deltaTime);  // 박스 무빙


//        if (objBoxTmp.transform.position.z >= 89.976)
//        {
//            objBoxTmp.transform.position = new Vector3(24.293f, objBoxTmp.transform.position.y, 55f);
//        }
//    }


//    IEnumerator BoxMoveHTTP() {
//        while (true)
//        {

//            GameObject myPrefab = mDm.copyPrefab("box_h");
//            arrBox.Add(myPrefab);
//            //arrBox

//            yield return new WaitForSeconds(5f);
//        }
//    }

//    IEnumerator BoxMoveMQTT()
//    {
//        while (true)
//        {

//            yield return new WaitForSeconds(5f);
//        }
//    }




//    void Update()
//    {
//        //if (objBoxTmp.transform.position.z >= 81.87)
//        //{
//        //    speed = 1.5f;
//        //}

//        //fSecend += Time.deltaTime;
        

//        //if (Mathf.RoundToInt(fSecend / 5f)  == 5)
//        //{
//        //    StartCoroutine(mDm.MoveTest());
//        //    TestBoxMoveInfo();
//        //}

//        foreach(GameObject goBoxH in arrBox)
//        {
//            goBoxH.transform.Translate(Vector3.forward * speed * Time.deltaTime);  // 박스 무빙

//            if (goBoxH.transform.position.z >= 89.976)
//            {
//                goBoxH.transform.position = new Vector3(24.293f, goBoxH.transform.position.y, 55f);
//            }
//        }


        


//    }

//    void Start()
//    {
//        //StartCoroutine(BoxMoveHTTP());
//        //StartCoroutine(BoxMoveMQTT());
//        //#if UNITY_WEBGL && !UNITY_EDITOR
//#if true
//#else
//        TextAsset excelFile = Resources.Load("Data/visualizor_data0227") as TextAsset;

//        Debug.Log("bytelen:" + excelFile.bytes.Length);

//        MemoryStream stream = new MemoryStream(excelFile.bytes);
//        IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);


//        var tables = reader.AsDataSet().Tables;

//        for (var sheetIndex = 0; sheetIndex < tables.Count; sheetIndex++)
//        {
//            var sheet = tables[sheetIndex];

//            Debug.Log("sheet:" + sheet.TableName);



//            if (sheet.TableName == "wcsv_conveyor")
//            {
//                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
//                {// 행 루프 0번째는 컬럼



//                    // 행 가져오기
//                    var slot = sheet.Rows[rowIndex];
//                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
//                    {
//                        break;
//                    }



//                    WModelInfo modelInfo = new WModelInfo();



//                    Debug.Log(slot.ItemArray[0] + slot.ItemArray[2].ToString());

//                    modelInfo.obj_type = slot.ItemArray[0].ToString();
//                    modelInfo.len_x = float.Parse(slot.ItemArray[2].ToString());
//                    modelInfo.len_y = float.Parse(slot.ItemArray[3].ToString());
//                    modelInfo.len_z = float.Parse(slot.ItemArray[4].ToString());

//                    mDm.mArrModelInfo.Add(modelInfo);

//                }


//            }

//            if (sheet.TableName == "wcsv_conveyor_position" || sheet.TableName == "wcsv_conveyor_2f_position")
//            {   // 생성
//                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
//                {// 행 루프 0번째는 컬럼


//                    // 행 가져오기
//                    var slot = sheet.Rows[rowIndex];
//                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
//                    {
//                        break;
//                    }

//                    for (int i = 0; i < mDm.mArrModelInfo.Count; i++)
//                    {
//                        WModelInfo modelInfo = mDm.mArrModelInfo[i] as WModelInfo;


//                        if (modelInfo.obj_type == null || modelInfo.obj_type == "")
//                        {
//                            continue;
//                        }



//                        if (modelInfo.obj_type == slot.ItemArray[0].ToString())
//                        {
//                            WModel model = new WModel();
//                            model.info = modelInfo;

//                            //model.pos_x = float.Parse(slot.ItemArray[2].ToString()) + (modelInfo.len_x * 0.5f);
//                            //model.pos_y = float.Parse(slot.ItemArray[3].ToString()) + (modelInfo.len_y * 0.5f); 
//                            //model.pos_z = float.Parse(slot.ItemArray[4].ToString()) + (modelInfo.len_z * 0.5f);

//                            model.pos_x = float.Parse(slot.ItemArray[2].ToString());
//                            model.pos_y = float.Parse(slot.ItemArray[3].ToString());
//                            model.pos_z = float.Parse(slot.ItemArray[4].ToString());
//                            model.floor = int.Parse(slot.ItemArray[5].ToString());

//                            model.scale_x = float.Parse(slot.ItemArray[6].ToString());
//                            model.scale_y = float.Parse(slot.ItemArray[7].ToString());
//                            model.scale_z = float.Parse(slot.ItemArray[8].ToString());



//                            // 프리팹으로 만들 게임 오브젝트

//                            //GameObject myPrefab = Resources.Load<GameObject>(model.info.obj_type);

//                            GameObject myPrefab = mDm.copyPrefab(model.info.obj_type);

                            




//                            // 프리팹 생성
//                            GameObject instantiatedPrefab = myPrefab;//Instantiate(myPrefab);

//                            if(!sheet.TableName.Contains("2f"))
//                                instantiatedPrefab.transform.parent = objFloor1.transform;
//                            else
//                                instantiatedPrefab.transform.parent = objFloor2.transform;

//                            if (instantiatedPrefab.name == "libiRackRight(Clone)")
//                            {
//                                instantiatedPrefab.tag = instantiatedPrefab.name;
//                                Debug.Log("name:" + instantiatedPrefab.name);
//                                Debug.Log("tag:" + instantiatedPrefab.tag);
//                            }


//                            instantiatedPrefab.transform.localPosition = new Vector3(model.pos_x, model.pos_y, model.pos_z);
//                            //instantiatedPrefab.transform.localScale = new Vector3(model.scale_x, model.scale_y, model.scale_z);

//                            model.objPrefab = instantiatedPrefab;


//                            // 모델정보  모두저장
//                            mDm.mArrModel.Add(model);


//                            break;
//                        }
//                    }
//                }

//            }
//            else if (sheet.TableName == "wcsv_conveyor_position_h" || sheet.TableName == "wcsv_conveyor_2f_position_h")
//            {   // 생성
//                for (var rowIndex = 1; rowIndex < sheet.Rows.Count; rowIndex++)
//                {// 행 루프 0번째는 컬럼


//                    // 행 가져오기
//                    var slot = sheet.Rows[rowIndex];
//                    if (slot.ItemArray[0] == null || slot.ItemArray[0].ToString() == "")
//                    {
//                        break;
//                    }

//                    for (int i = 0; i < mDm.mArrModelInfo.Count; i++)
//                    {
//                        WModelInfo modelInfo = mDm.mArrModelInfo[i] as WModelInfo;


//                        if (modelInfo.obj_type == null || modelInfo.obj_type == "")
//                        {
//                            continue;
//                        }



//                        if (modelInfo.obj_type == slot.ItemArray[0].ToString())
//                        {
//                            WModel model = new WModel();
//                            model.info = modelInfo;

//                            //model.pos_x = float.Parse(slot.ItemArray[2].ToString()) + (modelInfo.len_x * 0.5f);
//                            //model.pos_y = float.Parse(slot.ItemArray[3].ToString()) + (modelInfo.len_y * 0.5f); 
//                            //model.pos_z = float.Parse(slot.ItemArray[4].ToString()) + (modelInfo.len_z * 0.5f);

//                            model.pos_x = float.Parse(slot.ItemArray[2].ToString());
//                            model.pos_y = float.Parse(slot.ItemArray[3].ToString());
//                            model.pos_z = float.Parse(slot.ItemArray[4].ToString());
//                            model.floor = int.Parse(slot.ItemArray[5].ToString());

//                            model.scale_x = float.Parse(slot.ItemArray[6].ToString());
//                            model.scale_y = float.Parse(slot.ItemArray[7].ToString());
//                            model.scale_z = float.Parse(slot.ItemArray[8].ToString());



//                            // 프리팹으로 오브젝트

//                            //GameObject myPrefab = Resources.Load<GameObject>(model.info.obj_type);

//                            GameObject myPrefab = mDm.copyPrefab(model.info.obj_type);





                            
//                            // 프리팹 생성
//                            GameObject instantiatedPrefab = myPrefab;//Instantiate(myPrefab);

//                            if (!sheet.TableName.Contains("2f"))
//                                instantiatedPrefab.transform.parent = objFloor1.transform;
//                            else
//                                instantiatedPrefab.transform.parent = objFloor2.transform;
                            
//                            instantiatedPrefab.transform.localPosition = new Vector3(model.pos_x, model.pos_y, model.pos_z);

//                            instantiatedPrefab.transform.localEulerAngles = new Vector3(0, 90, 0);
//                            Transform tfCon = instantiatedPrefab.transform.Find("Conveyor_Belt");
//                            if (tfCon != null)
//                            {
//                                tfCon.localPosition = new Vector3(
//                                    -tfCon.localPosition.x,
//                                    tfCon.localPosition.y,
//                                    tfCon.localPosition.z);
//                            }

//                            Transform tfLeg = instantiatedPrefab.transform.Find("con_leg");
//                            if (tfLeg != null)
//                            {
//                                tfLeg.localPosition = new Vector3(
//                                    -1,
//                                    tfLeg.localPosition.y,
//                                    tfLeg.localPosition.z);

//                                if (instantiatedPrefab.transform.localPosition.y != 0)
//                                {
//                                    tfLeg.gameObject.SetActive(false);
//                                }
//                            }







//                            model.objPrefab = instantiatedPrefab;


//                            // 모델정보  모두저장
//                            mDm.mArrModel.Add(model);


//                            break;
//                        }
//                    }
//                }

//            }



//            ////시트 이름 필터링 가능
//            ////Debug.Log($"Sheet[{sheetIndex}] Name: {sheet.TableName}");

//            //for (var rowIndex = 0; rowIndex < sheet.Rows.Count; rowIndex++)
//            //{// 행 루프

//            //    // 행 가져오기
//            //    var slot = sheet.Rows[rowIndex];
//            //    for (var columnIndex = 0; columnIndex < slot.ItemArray.Length; columnIndex++)
//            //    {// 열 루프
//            //        var item = slot.ItemArray[columnIndex];


//            //        // 열 가져오기
//            //        //Debug.Log($"slot[{rowIndex}][{columnIndex}] : {item}");
//            //    }
//            //}
//        }
//        reader.Dispose();
//        reader.Close();

//        //int nIdx = 0;
//        //while (reader.Read())
//        //{

//        //    // 열 인덱스 또는 열 이름으로 데이터에 액세스합니다.
//        //    string value = reader.GetString(0); // 첫 번째 열의 인덱스는 0입니다.
//        //                                        // 값에 대해 필요한 작업을 수행합니다...




//        //    Debug.Log(reader.Name + nIdx.ToString() + ":" + value);

//        //    nIdx++;
//        //}


//        //reader.Close();
//        //stream.Close();
//#endif

//        StartCommon();

//        moveFloor(1);
//    }



//    void StartCommon()
//    {
//        {

//            int nCnt = goLibiConT1Top.transform.childCount - 1;
//            arrRobot1Top = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot1Top.Add((RobotInfo)goLibiConT1Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiConT2Top.transform.childCount - 1;
//            arrRobot2Top = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot2Top.Add((RobotInfo)goLibiConT2Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon2FTop.transform.childCount - 1;
//            arrRobot2FTop = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot2FTop.Add((RobotInfo)goLibiCon2FTop.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            float nXMax = 31.05f;   // 22.05 // 1.8(base)
//            float nZMax = 1.772f;   // 34.622(base)

//            for (int i = 0; i < arrRobot1Top.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot1Top[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot1Top[i].transform.localPosition.x, arrRobot1Top[i].transform.localPosition.z);

//                arrRobot1Top[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot1Top, arrRobot1Top[i], nXMax, nZMax);
//                //arrRobot1Top[i].arrMove = arrMoveInfo;
//            }

//            for (int i = 0; i < arrRobot2Top.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot2Top[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot2Top[i].transform.localPosition.x, arrRobot2Top[i].transform.localPosition.z);

//                arrRobot2Top[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot2Top, arrRobot2Top[i], nXMax, nZMax);
//                //arrRobot2Top[i].arrMove = arrMoveInfo;
//            }

//            for (int i = 0; i < arrRobot2FTop.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot2FTop[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot2FTop[i].transform.localPosition.x, arrRobot2FTop[i].transform.localPosition.z);

//                arrRobot2FTop[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot2FTop, arrRobot2FTop[i], nXMax, nZMax);
//                //arrRobot2FTop[i].arrMove = arrMoveInfo;
//            }
//        }


//        {
            

//            int nCnt = goLibiCon3d1Top.transform.childCount - 1;
//            arrRobot3d1 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d1.Add((RobotInfo)goLibiCon3d1Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d2Top.transform.childCount - 1;
//            arrRobot3d2 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d2.Add((RobotInfo)goLibiCon3d2Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d3Top.transform.childCount - 1;
//            arrRobot3d3 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d3.Add((RobotInfo)goLibiCon3d3Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d4Top.transform.childCount - 1;
//            arrRobot3d4 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d4.Add((RobotInfo)goLibiCon3d4Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d5Top.transform.childCount - 1;
//            arrRobot3d5 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d5.Add((RobotInfo)goLibiCon3d5Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d6Top.transform.childCount - 1;
//            arrRobot3d6 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d6.Add((RobotInfo)goLibiCon3d6Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d7Top.transform.childCount - 1;
//            arrRobot3d7 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d7.Add((RobotInfo)goLibiCon3d7Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            nCnt = goLibiCon3d8Top.transform.childCount - 1;
//            arrRobot3d8 = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3d8.Add((RobotInfo)goLibiCon3d8Top.transform.GetChild(i).GetComponent<RobotInfo>());
//            }

//            float nXMax = 22.05f; // 31.05 // 1.8(base)
//            float nZMax = 1.772f;   // 34.622(base)

//            for (int i = 0; i < arrRobot3d1.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d1[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d1[i].transform.localPosition.x, arrRobot3d1[i].transform.localPosition.z);

//                arrRobot3d1[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d1, arrRobot3d1[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d2.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d2[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d2[i].transform.localPosition.x, arrRobot3d2[i].transform.localPosition.z);

//                arrRobot3d2[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d2, arrRobot3d2[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d3.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d3[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d3[i].transform.localPosition.x, arrRobot3d3[i].transform.localPosition.z);

//                arrRobot3d3[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d3, arrRobot3d3[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d4.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d4[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d4[i].transform.localPosition.x, arrRobot3d4[i].transform.localPosition.z);

//                arrRobot3d4[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d4, arrRobot3d4[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d5.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d5[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d5[i].transform.localPosition.x, arrRobot3d5[i].transform.localPosition.z);

//                arrRobot3d5[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d5, arrRobot3d5[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d6.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d6[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d6[i].transform.localPosition.x, arrRobot3d6[i].transform.localPosition.z);

//                arrRobot3d6[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d6, arrRobot3d6[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d7.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d7[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d7[i].transform.localPosition.x, arrRobot3d7[i].transform.localPosition.z);

//                arrRobot3d7[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d7, arrRobot3d7[i], nXMax, nZMax);
//            }

//            for (int i = 0; i < arrRobot3d8.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3d8[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3d8[i].transform.localPosition.x, arrRobot3d8[i].transform.localPosition.z);

//                arrRobot3d8[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3d8, arrRobot3d8[i], nXMax, nZMax);
//            }
//        }
//        {

            
            
//            int nCnt = goLibiCon3d8Base.transform.childCount - 1;
//            arrRobot3dBase = new List<RobotInfo>();
//            for (int i = 0; i < nCnt; i++)
//            {
//                arrRobot3dBase.Add((RobotInfo)goLibiCon3d8Base.transform.GetChild(i).GetComponent<RobotInfo>());
//            }



//            float nXMax = 1.8f;     // 22.05, 31.05
//            float nZMax = 34.622f;   // 1.772


//            for (int i = 0; i < arrRobot3dBase.Count; i++)
//            {
//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3dBase[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3dBase[i].transform.localPosition.x, arrRobot3dBase[i].transform.localPosition.z);

//                arrRobot3dBase[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPath(moveInfo, arrRobot3dBase, arrRobot3dBase[i], nXMax, nZMax);
//            }

//        }

//        {

            
//            GameObject[] arrGoLibiRight = GameObject.FindGameObjectsWithTag("libiRackRight(Clone)");

//            arrRobot3dBetween = new List<RobotInfo>();

//            foreach (GameObject goTmp in arrGoLibiRight)
//            {
//                int nCnt = goTmp.transform.childCount - 1;
//                for (int i = 0; i < nCnt; i++)
//                {
//                    arrRobot3dBetween.Add((RobotInfo)goTmp.transform.GetChild(i).GetComponent<RobotInfo>());
//                }
//            }

//            float nYMin = 1f; // 2f
//            float nYMax = 1.5f;     // 2.5f 
//            float nZMax = 1.772f;   // 1.772



//            for (int i = 0; i < arrRobot3dBetween.Count; i++)
//            {
//                arrRobot3dBetween[i].isBetween = true;
//                if (arrRobot3dBetween[i].name.Contains("2"))
//                {
//                    nYMin = 2f;
//                    nYMax = 2.5f;
//                }
//                else
//                {
//                    nYMin = 1f; // 2f
//                    nYMax = 1.5f;     // 2.5f 
//                }

//                RobotMoveInfo moveInfo = new RobotMoveInfo();
//                moveInfo.degree = Mathf.RoundToInt(arrRobot3dBetween[i].transform.GetChild(0).localEulerAngles.y);
//                moveInfo.vec2Posi = new Vector2(arrRobot3dBetween[i].transform.localPosition.z, arrRobot3dBetween[i].transform.localPosition.y);


//                arrRobot3dBetween[i].arrMove = new List<RobotMoveInfo>();
//                List<RobotMoveInfo> arrMoveInfo = mDm.createRobotPathBetween(moveInfo, arrRobot3dBetween, arrRobot3dBetween[i], nYMin, nYMax, nZMax);
//            }

//        }
//    }

//}
