using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    [SerializeField] PhysicEvent2D _radius;

    public List<ICollectable> _itemsInRadius;
    private void Awake()
    {
        
    }
    void Start()
    {
        _itemsInRadius = new List<ICollectable>();
        _radius.TriggerEnter2D += _radius_TriggerEnter2D;
        _radius.TriggerExit2D += _radius_TriggerExit2D;
    }

    private void _radius_TriggerExit2D(Collider2D arg0)
    {
        if (arg0.TryGetComponent(out ICollectable collectable))
        {
            _itemsInRadius.Remove(collectable);
        }
    }

    private void _radius_TriggerEnter2D(Collider2D arg0)
    {
        if (arg0.TryGetComponent(out ICollectable collectable))
        {
            _itemsInRadius.Add(collectable);
            collectable.Collected();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
