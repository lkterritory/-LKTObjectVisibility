using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace WCSScripts
{
    public class FreeCam : MonoBehaviour
    {

        public ObjSceneMain objMain;

        public GameObject objCenter;

        /// <summary>
        /// Normal speed of camera movement.
        /// </summary>
        public float movementSpeed = 50;

        /// <summary>
        /// Speed of camera movement when shift is held down,
        /// </summary>
        public float fastMovementSpeed = 100f;

        /// <summary>
        /// Sensitivity for free look.
        /// </summary>
        public float freeLookSensitivity = 75;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel.
        /// </summary>
        public float zoomSensitivity = 5f;

        /// <summary>
        /// Amount to zoom the camera when using the mouse wheel (fast mode).
        /// </summary>
        public float fastZoomSensitivity = 50f;

        public float rotationSpeed = 10f;

        /// <summary>
        /// Set to true when free looking (on right mouse button).
        /// </summary>
        private bool looking = false;

        private bool movingMouse = false;

        void Update()
        {
            //var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            var fastMode = false;
            var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

            Vector3 vcRst = transform.position;
            Vector3 vcAngle = transform.localEulerAngles;


            if (objMain.isHome) // 홈 일때는 move 금지 자동 돌기만
            {
                transform.LookAt(objCenter.transform.position); // 시선 설정

                transform.RotateAround(objCenter.transform.position, Vector3.up, rotationSpeed * Time.deltaTime); // 주위를 회전

                return;
            }


            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                vcRst = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                vcRst = transform.position + (transform.right * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                vcRst = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                vcRst = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                vcRst = transform.position + (transform.up * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.E))
            {
                vcRst = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp))
            {
                vcRst = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown))
            {
                vcRst = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
            }

            if (looking)
            {
                float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
                float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
                vcAngle = new Vector3(newRotationY, newRotationX, 0f);
                //            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);

                // 시작 위치에서 목표 위치까지 보간 이동
                //transform.localPosition = Vector3.Lerp(transform.localPosition,
                //    new Vector3(curMove.vec2Posi.x, transform.localPosition.y, curMove.vec2Posi.y), t);

                vcAngle = Vector3.Lerp(transform.localEulerAngles,
                    vcAngle, Time.deltaTime);

                //vcAngle = Vector3.Lerp(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * freeLookSensitivity;

                //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            if (movingMouse)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");



                Debug.Log("mouseX:" + mouseX);
                Debug.Log("mouseY:" + mouseY);


                vcRst = transform.position - (transform.right * mouseX * movementSpeed * Time.deltaTime);

                vcRst = vcRst - (transform.up * mouseY * movementSpeed * Time.deltaTime);






                //vcRst.x += mouseX * movementSpeed;
                //vcRst.y += mouseY * movementSpeed;

            }

            float axis = Input.GetAxis("Mouse ScrollWheel");
            if (axis != 0)
            {
                var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
                vcRst = transform.position + transform.forward * axis * zoomSensitivity;
            }



            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartLooking();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                StopLooking();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                movingMouse = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                movingMouse = false;
            }


            float minY = 3f;
            if (!this.objMain.is1F)
                minY = 11f;
            if (vcRst.y < minY)
            //if (transform.positawion.y < minY)
            {
                vcRst = new Vector3(vcRst.x, minY, vcRst.z);
            }


            //TargetPos = vcRst;
            //targetRotate = Quaternion.Euler(vcAngle);



            transform.position = vcRst;


            if (vcAngle.z != 0f)
            {
                vcAngle = new Vector3(vcAngle.x, vcAngle.y, 0f);
            }
            transform.localEulerAngles = vcAngle;
        }

        void OnDisable()
        {
            StopLooking();
        }

        /// <summary>
        /// Enable free looking.
        /// </summary>
        public void StartLooking()
        {
            //Cursor.lockState = Cursor.lockState.
            looking = true;
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }

        /// <summary>
        /// Disable free looking.
        /// </summary>
        public void StopLooking()
        {
            looking = false;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }


        public float offsetX = 0.0f;            // 카메라의 x좌표
        public float offsetY = 10.0f;           // 카메라의 y좌표
        public float offsetZ = -10.0f;          // 카메라의 z좌표

        public float CameraSpeed = 10.0f;       // 카메라의 속도
        Vector3 TargetPos;                      // 타겟의 위치
        Quaternion targetRotate;                // 타겟의 로테이션

        public void moveFloor(int aFloor)
        {
            if (aFloor == 0)
            {
                TargetPos = new Vector3(123.059f, 34.08912f, 21.38568f);
                targetRotate = Quaternion.Euler(41.157f, -42.117f, 0f);
            }
            else if (aFloor == 1)
            {


                TargetPos = new Vector3(123.8955f, 13f, 33.99925f);
                targetRotate = Quaternion.Euler(33.467f, -54.676f, 0f);

            }
            else
            {
                TargetPos = new Vector3(69.07357f, 20f, 62.07927f);
                targetRotate = Quaternion.Euler(39.397f, -45.655f, 0f);

            }
        }

        private void FixedUpdate()
        {
            if (Mathf.RoundToInt(TargetPos.y) == 0)
            {
                return;
            }

            if (Mathf.RoundToInt(TargetPos.y) == Mathf.RoundToInt(transform.position.y))
            {
                TargetPos = new Vector3(0, 0, 0);

                return;
            }





            // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
            //TargetPos = new Vector3(
            //    Target.transform.position.x + offsetX,
            //    Target.transform.position.y + offsetY,
            //    Target.transform.position.z + offsetZ
            //    );

            // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, Time.deltaTime * CameraSpeed);
        }
    }
}