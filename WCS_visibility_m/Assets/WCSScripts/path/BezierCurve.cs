using System.Net;
using UnityEngine;

namespace WCSScripts.Path
{
    public class BezierCurve : MonoBehaviour
    {
        public Transform startPoint;
        public Transform controlPoint1;
        public Transform endPoint;
        public int pointCount; // 곡선을 구성하는 점의 개수

        public LineRenderer lineRenderer;


        // box moving
        public float moveSpeed;// = 5.0f; // 오브젝트의 이동 속도

        public Vector3[] controlPoints; // 라인 렌더러의 제어점들

        //
        private void Awake()
        {
            //moveSpeed = 3f;

            lineRenderer = GetComponent<LineRenderer>();

            pointCount = 5;

            if (this.name.Contains("curve90"))
            {
                pointCount = 20;
            }
            else if (this.name.Contains("curve67.5"))
            {
                pointCount = 15;
            }
            else if (this.name.Contains("curve45"))
            {
                pointCount = 10;
            }

            lineRenderer.positionCount = pointCount;


            // box moving
            controlPoints = new Vector3[lineRenderer.positionCount];
            //


            DrawQuadraticBezier();
        }

        private void Start()
        {
            //moveSpeed = 3;

            // test
            this.gameObject.SetActive(false);
        }


        private void Update()
        {

        }



        private void DrawQuadraticBezier()
        {
            Debug.Log("pcount:" + pointCount.ToString());

            for (int i = 0; i < pointCount; i++)
            {
                Debug.Log("pccc:" + i.ToString());
                float t = i / (float)(pointCount - 1);
                Vector3 point = CalculateQuadraticBezierPoint(t, startPoint.transform.localPosition, controlPoint1.transform.localPosition, endPoint.transform.localPosition);
                lineRenderer.SetPosition(i, point);

                controlPoints[i] = point;
            }
        }

        private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float u = 1f - t;
            float tt = t * t;
            float uu = u * u;

            Vector3 p = uu * p0 + 2f * u * t * p1 + tt * p2;
            return p;
        }
    }
}

