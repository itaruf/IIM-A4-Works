using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBullet
{
    event UnityAction playSFX;
    event UnityAction playVFX;
}

