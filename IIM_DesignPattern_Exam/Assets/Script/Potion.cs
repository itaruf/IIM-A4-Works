using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : Item, ICollectable
{
    [SerializeField] PlayerEntity _playerEntity;
    [SerializeField] int restoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ICollectable.Collected()
    {
        _playerEntity.Health.RestoreHealth(restoreAmount);
        Destroy(gameObject);
    }
}
