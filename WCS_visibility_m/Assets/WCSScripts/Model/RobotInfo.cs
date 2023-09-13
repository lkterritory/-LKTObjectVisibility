using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class RobotInfo : MonoBehaviour
{

	public List<RobotMoveInfo> arrMove;

    public bool isBetween;

    public Transform tfChild;

    float fSumdeltaTime = 0f;

    private float movementDuration = 3f;

    int nIdxPre = 0;

    private void Awake()
    {
		arrMove = new List<RobotMoveInfo>();

        //Debug.Log(this.name);

        try
        {
            tfChild = this.transform.GetChild(0);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("error tfChild find");
            Debug.Log(ex.Message);
        }

        isBetween = false;
    }

    // Use this for initialization
    void Start()
	{

    }

    
    private float elapsedTime = 0f;

    // Update is called once per frame
    void Update()
    {
        
        // editinbg by elf
        if (tfChild == null)
        { // no moving

        }

        if (arrMove.Count > 0) { 
            fSumdeltaTime += Time.deltaTime;
        }else
        {
            return;
        }

        int nIdxCur = Mathf.RoundToInt(fSumdeltaTime * movementDuration);

        if(nIdxCur >= arrMove.Count)
        {
            fSumdeltaTime = 0;
            nIdxPre = 0;
            nIdxCur = 0;

            return;
        }

        RobotMoveInfo preMove = arrMove[nIdxPre];
        RobotMoveInfo curMove = arrMove[nIdxCur];

        //Debug.Log("idxCur " + nIdxCur.ToString());
        if (nIdxCur > nIdxPre)
        {   // 새로운 목표지점 생성시 기존 목표지점으로 바로 이동하여 move진행
            tfChild.localEulerAngles = new Vector3(0, preMove.degree, 0);
            if(!isBetween)
                this.transform.localPosition = new Vector3(preMove.vec2Posi.x, this.transform.localPosition.y, preMove.vec2Posi.y);
            else
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, preMove.vec2Posi.y, preMove.vec2Posi.x);

            elapsedTime = 0;
        }

        if (nIdxCur >= 1)
        {// 이전값으로 되돌림
            preMove = arrMove[nIdxCur - 1];
        }


        {// 무브 진행

            // 1초 동안 이동하는 보간 계산
            //elapsedTime += Time.deltaTime;
            //float t = Mathf.Clamp01(elapsedTime / 10);


            // 시작 위치에서 목표 위치까지 보간 이동
            //transform.localPosition = Vector3.Lerp(transform.localPosition,
            //    new Vector3(curMove.vec2Posi.x, transform.localPosition.y, curMove.vec2Posi.y), t);

            //tfChild.localEulerAngles = Vector3.Lerp(tfChild.localEulerAngles,
            //    new Vector3(0, curMove.degree, 0), t);



            tfChild.localEulerAngles += new Vector3(0, (curMove.degree - preMove.degree) * Time.deltaTime * movementDuration, 0);
            if (!isBetween)
                this.transform.localPosition += new Vector3(
                (curMove.vec2Posi.x - preMove.vec2Posi.x) * Time.deltaTime * movementDuration,
                0,
                (curMove.vec2Posi.y - preMove.vec2Posi.y) * Time.deltaTime * movementDuration);
            else
                this.transform.localPosition += new Vector3(
                    0,
                (curMove.vec2Posi.y - preMove.vec2Posi.y) * Time.deltaTime * movementDuration

                ,(curMove.vec2Posi.x - preMove.vec2Posi.x) * Time.deltaTime * movementDuration);

            //this.transform.localPosition += new Vector3(
            //    curMove.vec2Posi.x * Time.deltaTime,
            //    0,
            //    curMove.vec2Posi.y * Time.deltaTime);
        }

        nIdxPre = nIdxCur;





        //if (tfChild.localEulerAngles.y == curMove.degree)




        //  tfChild.localEulerAngles = new Vector3(0, curMove.degree, 0); // * Time.deltaTime;
        //this.transform.localPosition += new Vector3(curMove.vec2Posi.x * Time.deltaTime, 0, curMove.vec2Posi.y * Time.deltaTime);


        //this.transform.localPosition = new Vector3(curMove.vec2Posi.x, this.transform.localPosition.y, curMove.vec2Posi.y);
    }
}

