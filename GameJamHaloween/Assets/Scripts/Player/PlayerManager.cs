using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private Vector3 _moveDirection;
    private float _horizontalMovementInput;
    private float _verticalMovementInput;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
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
        _moveDirection = _camera.forward * _verticalMovementInput + _camera.right * _horizontalMovementInput;
        _moveDirection.Normalize(); //œ–≈¬–¿Ÿ¿≈“ ¬≈ “Œ– ¬ “¿ Œ… ∆≈ ≈ƒ»Õ»◊Õ€…
        _moveDirection.y = 0;

        _characterController.Move(_moveDirection * _speed * Time.deltaTime); //APPLY MOVEMENT
    }
}
