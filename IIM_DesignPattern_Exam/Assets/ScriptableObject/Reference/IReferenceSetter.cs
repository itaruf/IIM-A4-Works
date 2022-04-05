using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReferenceSetter<T>
{
    void SetInstance(T newInstance);
}
