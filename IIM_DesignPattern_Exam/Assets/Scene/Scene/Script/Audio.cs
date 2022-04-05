using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Audio : MonoBehaviour
{ 
    [SerializeField] public UnityEvent _onPlaySFX;
    public void SoundCallBack(UnityAction unityAction)
    {
        _onPlaySFX.AddListener(unityAction);
        _onPlaySFX.Invoke();
    } 
}
