using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Skillveri
{
    public class PlayerInputController : Singleton<PlayerInputController>
    {
        private InputSystem_Actions inputActions;
        private InputSystem_Actions.PlayerActions playerActions;

        public Action OnJump;
        public Vector2 MoveDirection => playerActions.Move.ReadValue<Vector2>();

        protected override void Awake()
        {   
            base.Awake();
            inputActions = new();
            playerActions = inputActions.Player;
        }

        void OnEnable()
        {
            inputActions.Enable();
            playerActions.Jump.performed += Jump;
        }

        void OnDisable()
        {
            playerActions.Jump.performed -= Jump;
            inputActions.Disable();
        }

        private void Jump(InputAction.CallbackContext context)
        {
            OnJump?.Invoke();
        }

    }
}