using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorBehavior : MonoBehaviour
{
    [SerializeField] CursorReference _cursorRef;
    [SerializeField] CameraReference _camera;
    [SerializeField] InputActionReference _moveCursor;

    void Awake()
    {
        (_cursorRef as IReferenceSetter<CursorBehavior>).SetInstance(this);
    }

    public void Update()
    {
        var newPosition = _camera.Instance.ScreenToWorldPoint(_moveCursor.action.ReadValue<Vector2>());
        newPosition.z = 0;

        transform.position = newPosition;
    }

}
