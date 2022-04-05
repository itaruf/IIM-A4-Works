using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputDispatcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    [SerializeField] EntityMovement _movement;
    [SerializeField] EntityFire _fire;
    [SerializeField] EntityShield _shield;
 
    [SerializeField] InputActionReference _pointerPosition;
    [SerializeField] InputActionReference _moveJoystick;
    [SerializeField] InputActionReference _fireButton;
    [SerializeField] InputActionReference _shieldButton;

    Coroutine MovementTracking { get; set; }
    Vector3 ScreenPositionToWorldPosition(Camera c, Vector2 cursorPosition) => _mainCamera.ScreenToWorldPoint(cursorPosition);


    private void Start()
    {
        // binding
        _fireButton.action.started += FireInput;

        _moveJoystick.action.started += MoveInput;
        _moveJoystick.action.canceled += MoveInputCancel;

        _shieldButton.action.performed += ShieldInput;
        _shieldButton.action.canceled += ShieldCancelInput;
    }

    private void ShieldCancelInput(InputAction.CallbackContext obj)
    {
        _shield.CancelShield();
    }

    private void ShieldInput(InputAction.CallbackContext obj)
    {
        float shield = obj.ReadValue<float>();

        if (shield == 1)
            _shield.Shield();
    }

    private void OnDestroy()
    {
        _fireButton.action.started -= FireInput;

        _moveJoystick.action.started -= MoveInput;
        _moveJoystick.action.canceled -= MoveInputCancel;

        _shieldButton.action.performed -= ShieldInput;
        _shieldButton.action.canceled -= ShieldCancelInput;
    }

    private void MoveInput(InputAction.CallbackContext obj)
    {
        if (MovementTracking != null) return;

        MovementTracking = StartCoroutine(MovementTrackingRoutine());
        IEnumerator MovementTrackingRoutine()
        {
            while (true)
            {
                _movement.PrepareDirection(obj.ReadValue<Vector2>());
                yield return null;
            }
            yield break;
        }
    }

    private void MoveInputCancel(InputAction.CallbackContext obj)
    {
        if (MovementTracking == null) return;
        _movement.PrepareDirection(Vector2.zero);
        StopCoroutine(MovementTracking);
        MovementTracking = null;
    }

    private void FireInput(InputAction.CallbackContext obj)
    {
        if (_shield.IsActive)
            return;

        float fire = obj.ReadValue<float>();
        if(fire==1)
        {
            _fire.FireBullet(2);
        }
    }

}
