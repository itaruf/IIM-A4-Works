using Cinemachine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] AnimationCurve _shakeCurve;

    Coroutine ShakeRoutine { get; set; }

    [Button("TestShake")]
    void TestShake()
    {
        if (Application.isPlaying == false) return;
        LaunchScreenShake();
    }

    public void LaunchScreenShake()
    {
        if(ShakeRoutine!=null)
        {
            StopCoroutine(ShakeRoutine);
            ShakeRoutine = null;
        }
        ShakeRoutine = StartCoroutine(ShakeCoroutine());
        IEnumerator ShakeCoroutine()
        {
            var noise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            float launchTime = Time.fixedTime;
            var shakeDuration = _shakeCurve.keys.Last().time;

            while(Time.fixedTime < launchTime+shakeDuration)
            {
                noise.m_AmplitudeGain = _shakeCurve.Evaluate(Time.fixedTime - launchTime);
                yield return null;
            }

            noise.m_AmplitudeGain = 0;
            ShakeRoutine = null;
            yield break;
        }
    }


}
