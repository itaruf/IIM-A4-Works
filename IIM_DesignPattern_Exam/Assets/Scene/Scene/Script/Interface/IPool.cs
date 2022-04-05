using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool<T>
{
    void InstantiatePool();
    T GetPooledObject();
}
