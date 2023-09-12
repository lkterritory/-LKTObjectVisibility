using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using WCSScripts.Path;
using System.Reflection.Emit;
using UnityEngine.SocialPlatforms;
using WCSScripts.Manager;
using UnityEngine.UI;
using TMPro;
using System;

namespace WCSScripts.Model.Box
{

    public class BoxObj : MonoBehaviour
    {
        public enum STOP_MODE
        {
            None,
            Coll,
            Real,
            FromReal
        }

        public enum BOX_TYPE
        {
            NONE,
            TOTE,
            CARTON_OPEN,
            CARTON_CLOSE
        }


        public TMP_Text txtOrdNum;

        public bool isUse = false;  //  사용중인지 구분

        public BoxManager boxManager;
        public PathManager pathManager;
        public GameObject objCameraMain;

        public GameObject objTote;
        public GameObject objCartonOpen;
        public GameObject objCartonClose;

        
        private BOX_TYPE enBoxtype;
        public BOX_TYPE ProBoxType // 프로퍼티
        {
            get { return enBoxtype; }
            set {
                
                enBoxtype = value;
                objTote.SetActive(false);
                objCartonOpen.SetActive(false);
                objCartonClose.SetActive(false);

                if(enBoxtype == BOX_TYPE.TOTE)
                {
                    objTote.SetActive(true);
                }else if(enBoxtype == BOX_TYPE.CARTON_OPEN)
                {
                    objCartonOpen.SetActive(true);
                }
                else if (enBoxtype == BOX_TYPE.CARTON_CLOSE)
                {
                    objCartonClose.SetActive(true);
                }
            }
        }


        public BoxInfo boxInfoPre; // 필요할까?
        public BoxInfo boxInfo;


        public List<BezierCurve> mArrPath;

        public BezierCurve pathCur;

        public int curPathIndex = 0;
        public int currentPointIndex = 0; // 현재 오브젝트가 이동 중인 라인 렌더러의 점 인덱스



        public STOP_MODE enStopMode = STOP_MODE.None;


        //public bool bStopColl = false;  // 충돌방지멈

        //public bool bStopReal = false; // 마지막 멈춤
        //public bool bStopFromReal = false; // 마지막 멈춤으로 인한 멈춤

        // Use this for initialization

        private void Awake()
        {
            //boxInfo = new BoxInfo();
            //boxInfoPre = new BoxInfo();
            
            
            //mArrPath = new List<BezierCurve>();
            //enStopMode = STOP_MODE.FromReal;
            //pathCur = null;
            //curPathIndex = 0;
            //currentPointIndex = 0;
        }

        void Start()
        {
            // test
            //if (mArrPath.Count > 0)
            //{
            //    isUse = true;
            //    pathCur = mArrPath[0];
            //    this.transform.localPosition = pathCur.controlPoints[0];
            //}
        }



        // Update is called once per frame
        void Update()
        {
            //if (this.transform.localPosition.x > 10000)
            //{
            //    this.gameObject.SetActive(false);
            //}

            if (!isUse)
            {
                
                //this.gameObject.SetActive(false);
                return;
            }

            if (pathCur == null)
                return;

            if (enStopMode == STOP_MODE.Real || enStopMode == STOP_MODE.FromReal)
                return;

            if (enStopMode == STOP_MODE.Coll)
                return;

            if(curPathIndex == 0 && this.currentPointIndex == 0)
            {
                this.transform.localPosition = pathCur.controlPoints[0];
            }

            // 다음 점으로 이동
            float step = pathCur.moveSpeed * Time.deltaTime;
            this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, pathCur.controlPoints[this.currentPointIndex], step);

            // 현재 점에 도착하면 다음 점으로 이동
            if (Vector3.Distance(this.transform.localPosition, pathCur.controlPoints[currentPointIndex]) < 0.001f)
            {
                currentPointIndex++;
                if (currentPointIndex >= pathCur.controlPoints.Length)
                {// 현재 경로의 마지막 포인트

                    // 라인 렌더러의 끝에 도달했을 다음 path로 이동함
                    this.currentPointIndex = 0;

                    curPathIndex++; // 다음경로로 변경

                    if (mArrPath.Count <= curPathIndex) // 마지막 경로이면
                    {
                        // 최종 경로 도달하면 처음부터 다시 시작
                        //curPathIndex = 0;
                        //this.currentPointIndex = 0;
                        //pathCur = mArrPath[curPathIndex];
                        //this.transform.localPosition = pathCur.controlPoints[0];

                        // 최종 경로 도달하면 멈춤
                        this.enStopMode = STOP_MODE.Real;

                        if(this.enBoxtype == BOX_TYPE.CARTON_CLOSE)
                        {// 최종경로가 진짜 마지막 길이면 박스 제사용 위해 제거
                            this.isUse = false;
                            this.ProBoxType = BOX_TYPE.NONE;
                            this.transform.localPosition = new Vector3(20000, 20000, 20000);
                            boxManager.mArrBox.Remove(this);
                            //this.gameObject.SetActive(false);

                        }
                        else
                        {
                            
                            if(this.enBoxtype == BOX_TYPE.TOTE &&
                                this.boxInfo.logDetailMessage != "1번째 컨베이어 분기 : 1 로 컨베이어 분기 명령 전송")
                            {// 
                                this.isUse = false;
                                this.ProBoxType = BOX_TYPE.NONE;
                                this.transform.localPosition = new Vector3(20000, 20000, 20000);
                                boxManager.mArrBox.Remove(this);
                            }
                        }
                        
                    }
                    else
                    {
                        pathCur = mArrPath[curPathIndex];
                    }
                    
                }
            }



            if (pathCur != null)
            {
                // 오브젝트 방향 설정
                if (currentPointIndex < pathCur.controlPoints.Length - 1)
                {
                    Vector3 direction = (pathCur.controlPoints[currentPointIndex + 1] - pathCur.controlPoints[currentPointIndex]).normalized;
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, pathCur.moveSpeed * Time.deltaTime);
                }
            }
        }
        
        private void LateUpdate()
        {
            if (objCameraMain != null)
            {
                // 텍스트 오브젝트의 방향을 카메라 방향으로 설정
                this.txtOrdNum.transform.LookAt(transform.position + objCameraMain.transform.rotation * Vector3.forward,
                    objCameraMain.transform.rotation * Vector3.up);
            }
        }

        public void LoadBoxInfo()
        {// 박스 무빙

            if (boxInfoPre == null)
                boxInfoPre = new BoxInfo();

            if (boxInfoPre.logMessage == boxInfo.logMessage){
                return;
            }

            if(boxInfo.logMessage == "TOTE Box 매칭")
            {
                return;
            }
            if (boxInfo.logMessage == "오토라벨출력")
            {
                return;
            }
            if (boxInfo.logMessage == "바코드 검증")
            {
                return;
            }
  

            mArrPath = new List<BezierCurve>();
            enStopMode = STOP_MODE.None;
            pathCur = null;
            curPathIndex = 0;
            currentPointIndex = 0;

            

            if (boxInfo.objCode == "X")
                this.txtOrdNum.text = "";
            else
                this.txtOrdNum.text = boxInfo.objCode;

            



            if (boxInfo.logMessage.Contains("박스 분기"))
            {
                isUse = true;
                this.mArrPath = pathManager.GetPathFromInputBox(boxInfo.logDetailMessage);
                this.boxInfo.nPathRR = pathManager.nInputBoxRR == 0 ? 1 : 0;
                this.ProBoxType = BOX_TYPE.CARTON_OPEN;
                this.pathCur = mArrPath[0];
                this.transform.localPosition = pathCur.controlPoints[0];
                this.gameObject.SetActive(true);

            }
            else
            {
                if (boxInfo.logMessage == "1번째 컨베이어 분기")
                {
                    this.mArrPath = pathManager.GetPathFromInputTote(boxInfo.logDetailMessage);
                    this.boxInfo.nPathRR = pathManager.nInputToteRR == 0 ? 1 : 0;
                    this.ProBoxType = BOX_TYPE.TOTE;
                    this.pathCur = mArrPath[0];
                    this.transform.localPosition = pathCur.controlPoints[0];
                    this.gameObject.SetActive(true);


                    if (this.boxInfo.logDetailMessage == "1번째 컨베이어 분기 : 1 로 컨베이어 분기 명령 전송")
                    {
                        //// 카톤 박스 도 생성
                        BoxObj boxNew = boxManager.GetNewBox();
                        boxNew.boxManager = boxManager;
                        boxNew.pathManager = this.pathManager;
                        boxNew.boxInfo = new BoxInfo();

                        boxNew.boxInfo.objCode = "X";
                        boxNew.boxInfo.bcrCode = "";
                        boxNew.boxInfo.logCall = "";
                        boxNew.boxInfo.logCode = "";
                        boxNew.boxInfo.logMessage = "박스 분기";
                        boxNew.boxInfo.logDetailMessage = "박스 분기증 : 1";
                        boxNew.boxInfo.addDateTime = boxInfo.addDateTime;
                        boxNew.LoadBoxInfo();
                        boxNew.boxInfoPre = new BoxInfo();
                        boxManager.mArrBox.Add(boxNew);
                    }
                }
                
                if (boxInfo.logMessage == "2번째 컨베이어 분기")
                { // 
                    if (boxInfoPre.logMessage == "1번째 컨베이어 분기" && this.boxInfoPre.logDetailMessage == "1번째 컨베이어 분기 : 1 로 컨베이어 분기 명령 전송")
                    {
                        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, 20000);

                        foreach(BoxObj objTmp in boxManager.mArrBox)
                        {// 열려있는 박스 이고 RR이 같은거 하나 빼기
                            if(objTmp.ProBoxType == BOX_TYPE.CARTON_OPEN &&
                                boxInfoPre.nPathRR == objTmp.boxInfo.nPathRR)
                            {
                                objTmp.transform.localPosition = new Vector3(20000, objTmp.transform.localPosition.y, objTmp.transform.localPosition.z);
                                boxManager.mArrBox.Remove(objTmp);
                                objTmp.ProBoxType = BOX_TYPE.NONE;
                                objTmp.isUse = false;
                                break;
                            }
                        }
                    }


                    this.mArrPath = pathManager.GetPathFromOutputBox(boxInfo.logDetailMessage, boxInfoPre.nPathRR);
                    this.ProBoxType = BOX_TYPE.CARTON_CLOSE;
                    this.pathCur = mArrPath[0];
                    this.transform.localPosition = pathCur.controlPoints[0];
                    this.gameObject.SetActive(true);

                }
            }

            boxInfoPre.nPathRR = boxInfo.nPathRR;
            boxInfoPre.objCode = boxInfo.objCode;
            boxInfoPre.bcrCode = boxInfo.bcrCode;
            boxInfoPre.logCall = boxInfo.logCall;
            boxInfoPre.logCode = boxInfo.logCode;
            boxInfoPre.logMessage = boxInfo.logMessage;
            boxInfoPre.logDetailMessage = boxInfo.logDetailMessage;
            boxInfoPre.addDateTime = boxInfo.addDateTime;
        }



        void moveStart()
        {
            pathCur = mArrPath[curPathIndex];
            // 시작점으로 이동
            this.transform.localPosition = pathCur.controlPoints[0];
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!isUse)
                return;


            BoxObj boxColl = other.gameObject.GetComponent<BoxObj>();
            if (boxColl == null)
                return;

            if (this.ProBoxType != boxColl.ProBoxType)
                return;


            // 현재 오브젝트의 Rigidbody와 forward 벡터를 가져옴
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 objectForward = transform.forward;

    

            // 현재 오브젝트의 forward 방향과 충돌 벡터를 비교하여 처리
            Vector3 collisionDirection = this.transform.localPosition - boxColl.transform.localPosition;
            float dotProduct = Vector3.Dot(objectForward, collisionDirection);


            if (dotProduct >= 0)
            {   // 내가 앞에 있을때
                //this.bColStop = false;
            }
            else
            {   // 상대방이 앞에 있을때
                // 앞에 물체가 끝이라서 멈추거나 혹은 그 원인으로 멈췄으면
                if (boxColl.enStopMode == STOP_MODE.Real || boxColl.enStopMode == STOP_MODE.FromReal)
                {
                    enStopMode = STOP_MODE.FromReal;
                    // 앞의 물제 상태는 건들면 안됨
                }
                else
                {
                    enStopMode = STOP_MODE.Coll;
                    boxColl.enStopMode = STOP_MODE.None;
                }

            }


            Debug.Log("t enter");
        }

        private void OnTriggerStay(Collider other)
        {
            if (!isUse)
                return;

            if (enStopMode != STOP_MODE.None)
            {
                return;
            }


            BoxObj boxColl = other.gameObject.GetComponent<BoxObj>();
            if (boxColl == null)
                return;

            if (this.ProBoxType != boxColl.ProBoxType)
                return;

            
            // 현재 오브젝트의 Rigidbody와 forward 벡터를 가져옴
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 objectForward = transform.forward;

            //// 충돌한 물체의 위치와 현재 오브젝트의 위치 비교
            //Vector3 collisionPoint = other.contacts[0].point;
            //Vector3 objectPosition = transform.position;

            // 현재 오브젝트의 forward 방향과 충돌 벡터를 비교하여 처리
            Vector3 collisionDirection = this.transform.localPosition - boxColl.transform.localPosition;
            float dotProduct = Vector3.Dot(objectForward, collisionDirection);

            if (dotProduct >= 0)
            {   // 내가 앞에 있을때
                //this.bColStop = false;
            }
            else
            {   // 상대방이 앞에 있을때
                // 앞에 물체가 끝이라서 멈추거나 혹은 그 원인으로 멈췄으면
                if (boxColl.enStopMode == STOP_MODE.Real || boxColl.enStopMode == STOP_MODE.FromReal)
                {
                    enStopMode = STOP_MODE.FromReal;
                    // 앞의 물제 상태는 건들면 안됨
                }
                else
                {
                    enStopMode = STOP_MODE.Coll;
                    boxColl.enStopMode = STOP_MODE.None;
                }

            }


            
            //Debug.Log("t stay");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!isUse)
                return;

            enStopMode = STOP_MODE.None;

            Debug.Log("t exit");
        }

    }
}

