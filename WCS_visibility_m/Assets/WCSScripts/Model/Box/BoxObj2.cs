using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace WCSScripts.Model.Box
{
    public class BoxObj2 : MonoBehaviour
    {
        //   public List<BezierCurve> mArrPath;

        //   public BezierCurve pathCur;

        //   public int curPathIndex = 0;
        //   public int currentPointIndex = 0; // 현재 오브젝트가 이동 중인 라인 렌더러의 점 인덱스


        //   public BoxObj boxNear;

        //   public bool bColStop = false;  // 충돌방지멈

        //   public bool bStop = false; // 실제 멈춤

        //   // Use this for initialization
        //   void Start()
        //{
        //       pathCur = null;

        //       boxNear = null;

        //       pathCur = mArrPath[curPathIndex];
        //       // 시작점으로 이동
        //       this.transform.localPosition = pathCur.controlPoints[0];
        //   }

        //// Update is called once per frame
        //void Update()
        //{
        //       if(pathCur == null)
        //       {
        //           return;
        //       }

        //       if (this.bStop)
        //       {
        //           return;
        //       }


        //       if (this.bColStop)
        //       {
        //           return;
        //       }


        //       // 다음 점으로 이동
        //       float step = pathCur.moveSpeed * Time.deltaTime;
        //       this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, pathCur.controlPoints[this.currentPointIndex], step);

        //       // 현재 점에 도착하면 다음 점으로 이동
        //       if (Vector3.Distance(this.transform.localPosition, pathCur.controlPoints[currentPointIndex]) < 0.001f)
        //       {
        //           currentPointIndex++;
        //           if (currentPointIndex >= pathCur.controlPoints.Length)
        //           {// 현재 경로의 마지막 포인트

        //               // 라인 렌더러의 끝에 도달했을 다음 path로 이동함
        //               this.currentPointIndex = 0;

        //               curPathIndex++; // 다음경로로 변경

        //               if (mArrPath.Count == curPathIndex) // 마지막 경로이면
        //               {
        //                   // 최종 경로 도달하면 처음부터 다시 시작
        //                   curPathIndex = 0;
        //                   this.currentPointIndex = 0;
        //                   pathCur = mArrPath[curPathIndex];
        //                   this.transform.localPosition = pathCur.controlPoints[0];

        //                   // 최종 경로 도달하면 멈춤
        //                   //this.bStop = true;


        //               }
        //               else
        //               {
        //                   pathCur = mArrPath[curPathIndex];
        //               }
        //               //else
        //               //{



        //               //}
        //           }
        //       }



        //       if (pathCur != null)
        //       {
        //           // 오브젝트 방향 설정
        //           if (currentPointIndex < pathCur.controlPoints.Length - 1)
        //           {
        //               Vector3 direction = (pathCur.controlPoints[currentPointIndex + 1] - pathCur.controlPoints[currentPointIndex]).normalized;
        //               Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        //               this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, pathCur.moveSpeed * Time.deltaTime);
        //           }
        //       }
        //   }


        //   //    int nNextIdx = i + 1;
        //   //    if (nNextIdx == mArrBox.Count)
        //   //        nNextIdx = 0;


        //   //    float distance = Vector3.Distance(mArrBox[i].transform.localPosition, mArrBox[nNextIdx].transform.localPosition);

        //   //    if(distance <= 1.2f)
        //   //    {
        //   //        if(mArrBox[i].boxNear == null)
        //   //        {
        //   //            mArrBox[i].bWillStop = true;
        //   //            mArrBox[nNextIdx].boxNear = mArrBox[i];
        //   //        }
        //   //    }
        //   //    else
        //   //    {
        //   //        mArrBox[i].bWillStop = false;
        //   //        mArrBox[i].boxNear = null;
        //   //    }
        //   private void OnTriggerEnter(Collider other)
        //   {
        //       BoxObj boxColl = other.gameObject.GetComponent<BoxObj>();


        //       // 현재 오브젝트의 Rigidbody와 forward 벡터를 가져옴
        //       Rigidbody rb = GetComponent<Rigidbody>();
        //       Vector3 objectForward = transform.forward;

        //       //// 충돌한 물체의 위치와 현재 오브젝트의 위치 비교
        //       //Vector3 collisionPoint = other.contacts[0].point;
        //       //Vector3 objectPosition = transform.position;

        //       // 현재 오브젝트의 forward 방향과 충돌 벡터를 비교하여 처리
        //       Vector3 collisionDirection = this.transform.localPosition - boxColl.transform.localPosition;
        //       float dotProduct = Vector3.Dot(objectForward, collisionDirection);


        //       if (dotProduct >= 0)
        //       {   // 내가 앞에 있을때

        //   {
        //if(this.bColStop)
        //       {
        //       return;
        //   }
        //           if (boxColl.boxNear == null)
        //           {
        //               boxColl.bColStop = true;
        //               this.boxNear = this;

        //               this.bColStop = !boxColl.bColStop;
        //               boxColl.boxNear = null;
        //           }
        //       }
        //       else
        //       {   // 상대방이 앞에 있을때
        //           if (this.boxNear == null)
        //           {
        //               this.bColStop = true;
        //               boxColl.boxNear = this;

        //               boxColl.bColStop = !this.bColStop;
        //               this.boxNear = null;
        //           }
        //       }


        //       Debug.Log("t enter");
        //   }

        //   private void OnTriggerStay(Collider other)
        //   {
        //if(this.bColStop)
        //       {
        //       return;
        //   }


        //       BoxObj boxColl = other.gameObject.GetComponent<BoxObj>();


        //       // 현재 오브젝트의 Rigidbody와 forward 벡터를 가져옴
        //       Rigidbody rb = GetComponent<Rigidbody>();
        //       Vector3 objectForward = transform.forward;

        //       //// 충돌한 물체의 위치와 현재 오브젝트의 위치 비교
        //       //Vector3 collisionPoint = other.contacts[0].point;
        //       //Vector3 objectPosition = transform.position;

        //       // 현재 오브젝트의 forward 방향과 충돌 벡터를 비교하여 처리
        //       Vector3 collisionDirection = this.transform.localPosition - boxColl.transform.localPosition;
        //       float dotProduct = Vector3.Dot(objectForward, collisionDirection);



        //       if (dotProduct >= 0)
        //       {

        //           if (boxColl.boxNear == null)
        //           {
        //               boxColl.bColStop = true;
        //               this.boxNear = this;


        //               this.bColStop = !boxColl.bColStop;
        //               boxColl.boxNear = null;
        //           }
        //       }
        //       else
        //       {
        //           if (this.boxNear == null)
        //           {
        //               this.bColStop = true;
        //               boxColl.boxNear = this;


        //               boxColl.bColStop = !this.bColStop;
        //               this.boxNear = null;
        //           }
        //       }



        //       //Debug.Log("t stay");
        //   }

        //   private void OnTriggerExit(Collider other)
        //   {
        //       this.bColStop = false;
        //       this.boxNear = null;

        //       Debug.Log("t exit");
        //   }


    }

}