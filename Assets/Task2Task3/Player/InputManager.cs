using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private Movement _movement;
    [SerializeField] private MouseLook _mouseLook;


    public event Action TimerButtonPressed;

    private InputActions _inputActions;
    private InputActions.GroundMovementActions _groundMovement;

    private Vector2 _horizontalInput;
    private Vector2 _mouseInput;

    #endregion

    #region Methods
    private void Awake()
    {
        _inputActions = new InputActions();

        _groundMovement = _inputActions.GroundMovement;

        _groundMovement.HorizontalMovement.performed += context => _horizontalInput = context.ReadValue<Vector2>();
        _groundMovement.Jump.performed += _ => _movement.OnJumpPressed();

        _groundMovement.MouseX.performed += context => _mouseInput.x = context.ReadValue<float>();
        _groundMovement.MouseY.performed += context => _mouseInput.y = context.ReadValue<float>();

        _groundMovement.StartEndButton.performed += OnStartButtonPressed;
    }

    private void Update()
    {
        _movement.ReceiveInput(_horizontalInput);
        _mouseLook.ReceiveInput(_mouseInput);
    }

    private void OnStartButtonPressed(CallbackContext contest)
    {
        TimerButtonPressed?.Invoke();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
    #endregion
}
