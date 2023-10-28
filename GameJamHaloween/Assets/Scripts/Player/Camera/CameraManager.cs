using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _mouseSensivity = 20f;
  
    private float _horizontalRotation;
    private float _verticalRotation;
    private float _Rotation = 0f; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //HIDE THE CURSOR
    }

    private void Update()
    {
        //HOR AND VER INPUTS OF MOUSE WITH SENSIVITY APPLIED
        _horizontalRotation = PlayerInputManager.instance.CameraInput.x * _mouseSensivity * Time.deltaTime;
        _verticalRotation = PlayerInputManager.instance.CameraInput.y * _mouseSensivity * Time.deltaTime;

        //ROTATION AMOUNT CLAMPED IN ORDER TO LOCK VERTICAL ROTATION
        _Rotation -= _verticalRotation;
        _Rotation = Mathf.Clamp(_Rotation, -90f, 90f);

        //APPLYING ROTATION
        transform.localRotation = Quaternion.Euler(_Rotation, 0f, 0f);  //ROTATION OF CAMERA
        _playerTransform.Rotate(Vector3.up * _horizontalRotation);  //ROTATION OF PLAYER
    }
}
