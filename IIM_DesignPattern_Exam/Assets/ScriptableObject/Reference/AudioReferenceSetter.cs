using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReferenceSetter : MonoBehaviour
{
    [SerializeField] Audio _audio;
    [SerializeField] AudioReference _audioRef;

    void Awake()
    {
        (_audioRef as IReferenceSetter<Audio>).SetInstance(_audio);
    }
}
