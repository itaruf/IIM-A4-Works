using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference<T> : ScriptableObject, IReferenceSetter<T>
{
    T _instance;

    public T Instance => _instance;

    void IReferenceSetter<T>.SetInstance(T newInstance)
    {
        _instance = newInstance;
    }
}
