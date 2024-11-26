using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerSystem
{
    public class InputListener : MonoBehaviour
    {
        private PlayerControls _playerControls;

        [SerializeField] private Movement movement;

        private void Start()
        {
            _playerControls = new();

            _playerControls.MainActionMap.Newaction.started += OnMoveInput;
            _playerControls.MainActionMap.Newaction.performed += OnMoveInput;
            _playerControls.MainActionMap.Newaction.canceled += OnMoveInput;

            _playerControls.MainActionMap.Enable();
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            movement.SetDirection(input);
        }
    }
}