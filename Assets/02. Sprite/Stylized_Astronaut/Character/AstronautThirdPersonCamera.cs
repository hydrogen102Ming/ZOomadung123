using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{
    public class AstronautThirdPersonCamera : MonoBehaviour
    {
        private const float Y_ANGLE_MIN = 0.0f;
        private const float Y_ANGLE_MAX = 50.0f;

        public Transform lookAt;
        public float distance = 5.0f;
        public float desiredHeight = 1.5f; // 원하는 높이 값
        public float fieldOfView = 60.0f; // 시야각 값

        private float currentX = 0.0f;
        private float currentY = 45.0f;
        private float sensitivityX = 20.0f;
        private float sensitivityY = 20.0f;

        private Transform camTransform;
        private Camera cam;

        private void Start()
        {
            camTransform = transform;
            cam = GetComponent<Camera>();
            Cursor.visible = false;
        }

        private void Update()
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
            currentY += Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void LateUpdate()
        {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 desiredPosition = lookAt.position + rotation * dir;

            // 높이 조절
            desiredPosition.y += desiredHeight;

            camTransform.position = desiredPosition;
            camTransform.LookAt(lookAt.position);

            // 시야각 조절
            cam.fieldOfView = fieldOfView;
        }
    }
}
