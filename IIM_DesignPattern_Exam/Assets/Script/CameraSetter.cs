using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] CameraReference _camRef;

    #region EDITOR

    private void Reset()
    {
        _camera = GetComponent<Camera>();
    }

    #endregion

    private void Awake()
    {
        IReferenceSetter<Camera> reference = _camRef;
        reference.SetInstance(_camera);
    }

}
