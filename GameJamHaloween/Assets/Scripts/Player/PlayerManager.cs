using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private float _horizontalMovementInput;
    private float _verticalMovementInput;
    private Vector3 _velocity;
    private bool _isGrounded;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        HandleGravitation();
        HandleMovement();
    }

    private void GetMovementInput()
    {
        //STORING INPUT DATA FROM INPUT MANAGER
        _horizontalMovementInput = PlayerInputManager.instance.HorizontalMovement;
        _verticalMovementInput = PlayerInputManager.instance.VerticalMovement;
    }

    private void HandleMovement()
    {
        GetMovementInput();

        //SET MOVEMENT DIRECTION THAT DEPENDS ON CAMERA'S DIRECTION
        _moveDirection = transform.forward * _verticalMovementInput + transform.right * _horizontalMovementInput;
        _moveDirection.Normalize(); //œ–≈¬–¿Ÿ¿≈“ ¬≈ “Œ– ¬ “¿ Œ… ∆≈ ≈ƒ»Õ»◊Õ€…
        _moveDirection.y = 0;

        _characterController.Move(_moveDirection * _speed * Time.deltaTime); //APPLY MOVEMENT
    }

    private void HandleGravitation()
    {
        _isGrounded = Physics.CheckSphere(_groundCheckTransform.position, .2f, _groundMask);

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        _velocity.y += -9.81f * Time.deltaTime * 2;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
