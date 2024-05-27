using UnityEngine;

namespace AstronautPlayer
{
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator anim;
        private CharacterController controller;

        public float speed = 6.0f;
        public float turnSpeed = 400.0f;
        private Vector3 moveDirection = Vector3.zero;
        public float gravity = 20.0f;
        [SerializeField] private float jumpForce = 8f;

        private bool isJumping = false;

        [Header("Camera")]
        [SerializeField] private float looksensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;
        [SerializeField] private Camera theCamera;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = gameObject.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            Move();
            CameraRotation();
            CharacterRotation();
            CheckJump();
            ApplyGravity();
            MoveCharacter();
            ResetJumpIfNeeded();
        }

        private void Move()
        {
            float verticalInput = Input.GetAxis("Vertical");

            if (verticalInput != 0)
            {
                anim.SetInteger("AnimationPar", 1);
            }
            else
            {
                anim.SetInteger("AnimationPar", 0);
            }

            if (controller.isGrounded)
            {
                moveDirection = transform.forward * verticalInput * speed;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(0, horizontalInput * turnSpeed * Time.deltaTime, 0);
        }

        private void CameraRotation()
        {
            // 상하 카메라 회전
            float xRotation = Input.GetAxisRaw("Mouse Y");
            float cameraRotationX = xRotation * looksensitivity;
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }

        private void CharacterRotation()
        {
            // 좌우 카메라 회전
            float yRotation = Input.GetAxisRaw("Mouse X");
            Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * looksensitivity;
            transform.Rotate(characterRotationY);
        }

        private void CheckJump()
        {
            // 캐릭터가 바닥에 있으면 점프 가능
            if (controller.isGrounded)
            {
                // 점프 키를 누르면 점프
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isJumping = true;
                    moveDirection.y = jumpForce;

                }
            }
        }

        private void ApplyGravity()
        {
            // 캐릭터가 바닥에 닿아 있지 않으면 중력 적용
            if (!controller.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
        }

        private void MoveCharacter()
        {
            // 이동 방향 적용
            controller.Move(moveDirection * Time.deltaTime);
        }

        private void ResetJumpIfNeeded()
        {
            // 캐릭터가 바닥에 닿아 있으면 점프 상태 초기화
            if (controller.isGrounded && !isJumping)
            {
                moveDirection.y = 0f;
            }

            // 점프가 완료되면 상태 초기화
            if (isJumping && controller.isGrounded)
            {
                isJumping = false;
            }
        }
    }
}
