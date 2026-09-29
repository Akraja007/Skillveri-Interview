using UnityEngine;

namespace Skillveri
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(GroundCheckSensor))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerInputController playerInput;
        private GroundCheckSensor _groundCheckSensor;
        private Rigidbody _rigidbody;

        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float jumpForce = 10f;
        private void Awake()
        {
            playerInput = PlayerInputController.Instance;
            _rigidbody = GetComponent<Rigidbody>();
            _groundCheckSensor = GetComponent<GroundCheckSensor>();
        }

        void OnEnable()
        {
            playerInput.OnJump += OnJump;
        }

        void OnDisable()
        {
            playerInput.OnJump -= OnJump;
        }

        void FixedUpdate()
        {
            MoveAndLook();
        }

        public void MoveAndLook()
        {
            Vector3 moveInput = playerInput.MoveDirection;
            if (moveInput.sqrMagnitude < 0.01f) return;

            Vector3 direction =
                Vector3.forward * moveInput.y +
                Vector3.right * moveInput.x;


            Vector3 targetPosition = _rigidbody.position + moveSpeed * Time.fixedDeltaTime * direction;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _rigidbody.Move(targetPosition, targetRotation);
        }

        public void OnJump()
        {   
            if(_groundCheckSensor.TryDetect(out _))
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}