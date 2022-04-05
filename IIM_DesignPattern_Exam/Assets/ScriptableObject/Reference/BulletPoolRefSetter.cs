using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolRefSetter : MonoBehaviour
{
    [SerializeField] BulletPool _bulletPool;
    [SerializeField] BulletPoolReference _bulletPoolReference;

    private void Awake()
    {
        (_bulletPoolReference as IReferenceSetter<BulletPool>).SetInstance(_bulletPool);
    }
}
