using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WCSScripts.Path;
using Unity.VisualScripting;
using System.Linq;

namespace WCSScripts.Manager
{

	public class PathManager : MonoBehaviour
	{
		public List<GameObject> arrPahtList;

        public List<BezierCurve> arrPathInputTote1;
        public List<BezierCurve> arrPathInputTote2;
        public List<BezierCurve> arrPathInputBox1;
        public List<BezierCurve> arrPathInputBox2;
        public List<BezierCurve> arrPathInputBox3;
        public List<BezierCurve> arrPathInputBox4;
        public List<BezierCurve> arrPathInputBox5;
        public List<BezierCurve> arrPathOutputBox1;
        public List<BezierCurve> arrPathOutputBox2;


        void Start()
        {
            //foreach (BezierCurve path in arrPathOutputBox1){
            //    path.moveSpeed = 2;
            //}

            //foreach (BezierCurve path in arrPathOutputBox2){
            //    path.moveSpeed = 2;
            //}
        }

        public int nInputToteRR = 0;
        public List<BezierCurve> GetPathFromInputTote(string strMsg)
		{
			List<BezierCurve> arrRst = new List<BezierCurve>();

            
            if (strMsg == "1번째 컨베이어 분기 : 1 로 컨베이어 분기 명령 전송")
            {
                if (nInputToteRR == 0)
                {
                    arrRst.Add(arrPathInputTote1[0]);
                    arrRst.Add(arrPathInputTote1[1]);
                    arrRst.Add(arrPathInputTote1[2]);
                    arrRst.Add(arrPathInputTote1[3]);
                    arrRst.Add(arrPathInputTote1[4]);
                    arrRst.Add(arrPathInputTote1[5]); // 5_1
                    arrRst.Add(arrPathInputTote1[6]);
                    arrRst.Add(arrPathInputTote1[7]);
                    arrRst.Add(arrPathInputTote1[8]);
                    arrRst.Add(arrPathInputTote1[9]);
                    arrRst.Add(arrPathInputTote1[10]);
                    arrRst.Add(arrPathInputTote1[11]);// 5_7


                    arrRst.Add(arrPathInputTote1[15]);
                    arrRst.Add(arrPathInputTote1[16]);
                    arrRst.Add(arrPathInputTote1[17]);// 5_10
                }
                else
                {
                    arrRst.Add(arrPathInputTote1[0]);
                    arrRst.Add(arrPathInputTote1[1]);
                    arrRst.Add(arrPathInputTote1[2]);
                    arrRst.Add(arrPathInputTote1[3]);
                    arrRst.Add(arrPathInputTote1[4]);
                    arrRst.Add(arrPathInputTote1[5]); // 5_1
                    arrRst.Add(arrPathInputTote1[6]);
                    arrRst.Add(arrPathInputTote1[7]);
                    arrRst.Add(arrPathInputTote1[8]);
                    arrRst.Add(arrPathInputTote1[9]);
                    arrRst.Add(arrPathInputTote1[10]);
                    arrRst.Add(arrPathInputTote1[11]);// 5_7
                    arrRst.Add(arrPathInputTote1[12]);// 5_7_1
                    arrRst.Add(arrPathInputTote1[13]);// 5_7_2
                    arrRst.Add(arrPathInputTote1[14]);// 5_7_3

                }
            }else if (strMsg == "1번째 컨베이어 분기 : 3 로 컨베이어 분기 명령 전송")
            {
                    arrRst.Add(arrPathInputTote1[0]);
                    arrRst.Add(arrPathInputTote1[1]);
                    arrRst.Add(arrPathInputTote1[2]);
                    arrRst.Add(arrPathInputTote1[3]);
                    arrRst.Add(arrPathInputTote1[4]); // 5
                    arrRst.Add(arrPathInputTote1[18]); // 6
                    arrRst.Add(arrPathInputTote1[19]); // 6_1
                    arrRst.Add(arrPathInputTote1[20]); // 6_2
                    arrRst.Add(arrPathInputTote1[21]); // 6_3
            }
            else if (strMsg == "1번째 컨베이어 분기 : 5 로 컨베이어 분기 명령 전송")
            {
                arrRst.Add(arrPathInputTote1[0]);
                arrRst.Add(arrPathInputTote1[1]);
                arrRst.Add(arrPathInputTote1[2]);
                arrRst.Add(arrPathInputTote1[3]);
                arrRst.Add(arrPathInputTote1[4]); // 5
                arrRst.Add(arrPathInputTote1[18]); // 6
                arrRst.Add(arrPathInputTote1[22]); // 7
                arrRst.Add(arrPathInputTote1[23]); // 7_1
                arrRst.Add(arrPathInputTote1[24]); // 7_2
                arrRst.Add(arrPathInputTote1[25]); // 7_3
                arrRst.Add(arrPathInputTote1[26]); // 7_4
                arrRst.Add(arrPathInputTote1[27]); // 7_5
                arrRst.Add(arrPathInputTote1[28]); // 7_6
            }else if (strMsg == "1번째 컨베이어 분기 : 7 로 컨베이어 분기 명령 전송")  // 수기검수대
            {
                arrRst.Add(arrPathInputTote1[0]);
                arrRst.Add(arrPathInputTote1[1]);
                arrRst.Add(arrPathInputTote1[2]);
                arrRst.Add(arrPathInputTote1[3]);
                arrRst.Add(arrPathInputTote1[4]); // 5
                arrRst.Add(arrPathInputTote1[18]); // 6
                arrRst.Add(arrPathInputTote1[22]); // 7
                arrRst.Add(arrPathInputTote1[29]); // 8

                arrRst.Add(arrPathInputTote1[30]); // 8_1
                arrRst.Add(arrPathInputTote1[31]); // 8_2
                arrRst.Add(arrPathInputTote1[32]); // 8_3
                arrRst.Add(arrPathInputTote1[33]); // 8_4
                arrRst.Add(arrPathInputTote1[34]); // 8_5

                arrRst.Add(arrPathInputTote1[35]); // 8_6
                arrRst.Add(arrPathInputTote1[36]); // 8_7
                arrRst.Add(arrPathInputTote1[37]); // 8_8
                arrRst.Add(arrPathInputTote1[38]); // 8_9
                arrRst.Add(arrPathInputTote1[39]); // 8_10

                arrRst.Add(arrPathInputTote1[40]); // 8_11
                arrRst.Add(arrPathInputTote1[41]); // 8_12
                arrRst.Add(arrPathInputTote1[42]); // 8_13
                arrRst.Add(arrPathInputTote1[43]); // 8_14
                arrRst.Add(arrPathInputTote1[44]); // 8_15

                if (nInputToteRR == 0)
                {
                    arrRst.Add(arrPathInputTote1[45]); // 8_15_1
                    arrRst.Add(arrPathInputTote1[46]); // 8_15_2
                    arrRst.Add(arrPathInputTote1[47]); // 8_15_3
                }
                else
                {
                    arrRst.Add(arrPathInputTote1[48]); // 8_16
                    arrRst.Add(arrPathInputTote1[49]); // 8_17
                    arrRst.Add(arrPathInputTote1[50]); // 8_18
                }
            }
            else if (strMsg == "1번째 컨베이어 분기 : 9 로 컨베이어 분기 명령 전송")  // 오토배거
            {

                


                arrRst.Add(arrPathInputTote1[0]);
                arrRst.Add(arrPathInputTote1[1]);
                arrRst.Add(arrPathInputTote1[2]);
                arrRst.Add(arrPathInputTote1[3]);
                arrRst.Add(arrPathInputTote1[4]); // 5
                arrRst.Add(arrPathInputTote1[18]); // 6
                arrRst.Add(arrPathInputTote1[22]); // 7
                arrRst.Add(arrPathInputTote1[29]); // 8
                arrRst.Add(arrPathInputTote1[51]); // 9

                arrRst.Add(arrPathInputTote1[52]); // 9_1
                arrRst.Add(arrPathInputTote1[53]); // 9_1
                arrRst.Add(arrPathInputTote1[54]); // 9_1
                arrRst.Add(arrPathInputTote1[55]); // 9_1
                arrRst.Add(arrPathInputTote1[56]); // 9_1

                arrRst.Add(arrPathInputTote1[57]); // 9_6
                arrRst.Add(arrPathInputTote1[58]); // 9_1
                arrRst.Add(arrPathInputTote1[59]); // 9_1
                arrRst.Add(arrPathInputTote1[60]); // 9_1
                arrRst.Add(arrPathInputTote1[61]); // 9_1

                arrRst.Add(arrPathInputTote1[62]); // 9_11
                arrRst.Add(arrPathInputTote1[63]); // 9_1
                arrRst.Add(arrPathInputTote1[64]); // 9_1
                arrRst.Add(arrPathInputTote1[65]); // 9_1
                arrRst.Add(arrPathInputTote1[66]); // 9_1

                arrRst.Add(arrPathInputTote1[67]); // 9_16
                arrRst.Add(arrPathInputTote1[68]); // 9_1
                arrRst.Add(arrPathInputTote1[69]); // 9_1
                arrRst.Add(arrPathInputTote1[70]); // 9_1
                arrRst.Add(arrPathInputTote1[71]); // 9_1

                arrRst.Add(arrPathInputTote1[72]); // 9_21
                arrRst.Add(arrPathInputTote1[73]); // 9_22
            }
            else // 에러슈트
            {
                arrRst.Add(arrPathInputTote1[0]);
                arrRst.Add(arrPathInputTote1[1]);
                arrRst.Add(arrPathInputTote1[2]);
                arrRst.Add(arrPathInputTote1[3]);
                arrRst.Add(arrPathInputTote1[4]); // 5
                arrRst.Add(arrPathInputTote1[18]); // 6
                arrRst.Add(arrPathInputTote1[22]); // 7
                arrRst.Add(arrPathInputTote1[29]); // 8
                arrRst.Add(arrPathInputTote1[51]); // 9

                arrRst.Add(arrPathInputTote1[74]); // 10
                arrRst.Add(arrPathInputTote1[75]); // 11
                arrRst.Add(arrPathInputTote1[76]); // 12
            }


            
            if (nInputToteRR == 0) nInputToteRR = 1;
            else if (nInputToteRR == 1) nInputToteRR = 0;


            return arrRst;
        }


        public int nInputBoxRR = 0;
        public List<BezierCurve> GetPathFromInputBox(string strMsg)
        {
            List<BezierCurve> arrRst = new List<BezierCurve>();

            //if (strMsg.Contains("박스 분기증 : 1"))
            if (nInputBoxRR == 0)
            {
                arrRst.Add(arrPathInputBox1[0]);
                arrRst.Add(arrPathInputBox1[1]);
                arrRst.Add(arrPathInputBox1[2]);
                arrRst.Add(arrPathInputBox1[3]);
                arrRst.Add(arrPathInputBox1[4]);
                arrRst.Add(arrPathInputBox1[5]);
                arrRst.Add(arrPathInputBox1[6]);
                arrRst.Add(arrPathInputBox1[7]);
            }
            else
            {
                arrRst.Add(arrPathInputBox4[0]);
                arrRst.Add(arrPathInputBox4[1]);
                arrRst.Add(arrPathInputBox4[2]);
                arrRst.Add(arrPathInputBox4[3]);
                arrRst.Add(arrPathInputBox4[4]);
                
            }


            if (nInputBoxRR == 0) nInputBoxRR = 1;
            else if (nInputBoxRR == 1) nInputBoxRR = 0;

            return arrRst;
        }


        public List<BezierCurve> GetPathFromOutputBox(string strMsg, int nPreRR)
        {
            List<BezierCurve> arrRst = new List<BezierCurve>();
            //if (strMsg.Contains("2 로 컨베이어 분기 명령 전송"))
            if(nPreRR == 0)
            {
                arrRst.Add(arrPathOutputBox1[0]);   // 1

                arrRst.Add(arrPathOutputBox1[13]); // 2
                arrRst.Add(arrPathOutputBox1[14]); // 2
                arrRst.Add(arrPathOutputBox1[15]); // 2
                arrRst.Add(arrPathOutputBox1[16]); // 5

                arrRst.Add(arrPathOutputBox1[17]); // 6
                arrRst.Add(arrPathOutputBox1[18]); // 6
                arrRst.Add(arrPathOutputBox1[19]); // 6
                arrRst.Add(arrPathOutputBox1[20]); // 6
                arrRst.Add(arrPathOutputBox1[21]); // 10

                arrRst.Add(arrPathOutputBox1[22]); // 11
                arrRst.Add(arrPathOutputBox1[23]); // 6
                arrRst.Add(arrPathOutputBox1[24]); // 6
                arrRst.Add(arrPathOutputBox1[25]); // 6
                arrRst.Add(arrPathOutputBox1[26]); // 15

                arrRst.Add(arrPathOutputBox1[27]); // 16
                arrRst.Add(arrPathOutputBox1[28]); // 17
                arrRst.Add(arrPathOutputBox1[29]); // 18

                
            }
            else
            {
                arrRst.Add(arrPathOutputBox2[0]);

                arrRst.Add(arrPathOutputBox2[11]);
                arrRst.Add(arrPathOutputBox2[12]);
                arrRst.Add(arrPathOutputBox2[13]);
                arrRst.Add(arrPathOutputBox2[14]);
                arrRst.Add(arrPathOutputBox2[15]);

                arrRst.Add(arrPathOutputBox2[16]);
                arrRst.Add(arrPathOutputBox2[17]);
                arrRst.Add(arrPathOutputBox2[18]);
                arrRst.Add(arrPathOutputBox2[19]);
                arrRst.Add(arrPathOutputBox2[20]);

                arrRst.Add(arrPathOutputBox2[21]);
                arrRst.Add(arrPathOutputBox2[22]);
                arrRst.Add(arrPathOutputBox2[23]);
                arrRst.Add(arrPathOutputBox2[24]);
                arrRst.Add(arrPathOutputBox2[25]);

                arrRst.Add(arrPathOutputBox2[26]);


                arrRst.Add(arrPathOutputBox1[26]); // 15

                arrRst.Add(arrPathOutputBox1[27]); // 16
                arrRst.Add(arrPathOutputBox1[28]); // 17
                arrRst.Add(arrPathOutputBox1[29]); // 18
            }

            if (strMsg == "2번째 컨베이어 분기 : 2 로 컨베이어 분기 명령 전송")
            {
                arrRst.Add(arrPathOutputBox1[30]); // 18_1
                arrRst.Add(arrPathOutputBox1[31]); // 18_2
                arrRst.Add(arrPathOutputBox1[32]); // 18_3
            }
            else if (strMsg == "2번째 컨베이어 분기 : 4 로 컨베이어 분기 명령 전송")
            {
                arrRst.Add(arrPathOutputBox1[33]); // 19
                arrRst.Add(arrPathOutputBox1[34]); // 19_1
                arrRst.Add(arrPathOutputBox1[35]); // 19_2
                arrRst.Add(arrPathOutputBox1[36]); // 19_3
            }
            else if (strMsg == "2번째 컨베이어 분기 : 6 로 컨베이어 분기 명령 전송")
            {
                arrRst.Add(arrPathOutputBox1[33]); // 19
                arrRst.Add(arrPathOutputBox1[37]); // 20
                arrRst.Add(arrPathOutputBox1[38]); // 20_1
                arrRst.Add(arrPathOutputBox1[39]); // 20
                arrRst.Add(arrPathOutputBox1[40]); // 20_3
            }
            else
            {
                arrRst.Add(arrPathOutputBox1[33]); // 19
                arrRst.Add(arrPathOutputBox1[37]); // 20
                arrRst.Add(arrPathOutputBox1[41]); // 21
                arrRst.Add(arrPathOutputBox1[42]); // 22
            }

            return arrRst;
        }



        // Use this for initialization
        void Awake()
		{
            arrPathInputTote1 = (arrPahtList[0].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathInputTote2 = (arrPahtList[1].transform.GetComponentsInChildren<BezierCurve>()).ToList();

            arrPathInputBox1 = (arrPahtList[2].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathInputBox2 = (arrPahtList[3].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathInputBox3 = (arrPahtList[4].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathInputBox4 = (arrPahtList[5].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathInputBox5 = (arrPahtList[6].transform.GetComponentsInChildren<BezierCurve>()).ToList();

            arrPathOutputBox1 = (arrPahtList[7].transform.GetComponentsInChildren<BezierCurve>()).ToList();
            arrPathOutputBox2 = (arrPahtList[8].transform.GetComponentsInChildren<BezierCurve>()).ToList();


            foreach (BezierCurve path in arrPathInputTote1)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputTote2)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputBox1)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputBox2)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputBox3)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputBox4)
            {
                path.moveSpeed = 3;
            }
            foreach (BezierCurve path in arrPathInputBox5)
            {
                path.moveSpeed = 3;
            }






            foreach (BezierCurve path in arrPathOutputBox1)
            {
                path.moveSpeed = 2;
            }

            foreach (BezierCurve path in arrPathOutputBox2)
            {
                path.moveSpeed = 2;
            }
        }

		// Update is called once per frame
		void Update()
		{
            
		}
	}
}

