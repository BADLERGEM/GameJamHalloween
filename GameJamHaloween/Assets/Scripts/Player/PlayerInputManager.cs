using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;  //SINGLETON

    private PlayerControls _playerControls; //INPUT SYSTEM
    private Vector2 _movementInput; //STORES MOVEMENT INPUT DATA
    
    private Vector2 _cameraInput;   //STORES MOUSE INPUT DATA
    private float _horizontalMovement;
    private float _verticalMovement;
    private float _moveAmount;

    public Vector2 CameraInput => _cameraInput;
    public float MoveAmount => _moveAmount;
    public float HorizontalMovement => _horizontalMovement;
    public float VerticalMovement => _verticalMovement;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
        }

        //SUBSCRIBING AN ANONYMOUS METHOD THAT PUTS INPUT DATA INTO _movementInput AND _cameraInput VARIABLES
        _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
        _playerControls.CameraRotation.Rotation.performed += i => _cameraInput = i.ReadValue<Vector2>();

        _playerControls.Enable();   //ENABLING INPUT SYSTEM
    }
    private void Update()
    {
        HandleMovementInput();
    }
    public void HandleMovementInput()
    {
        _verticalMovement = _movementInput.y;
        _horizontalMovement = _movementInput.x;

        //LATER WILL BE NEEDED TO DO SPRINT ETC.
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_verticalMovement) + Mathf.Abs(_horizontalMovement));
    }
}
