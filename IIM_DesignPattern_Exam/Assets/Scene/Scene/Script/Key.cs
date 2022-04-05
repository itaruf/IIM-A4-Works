using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, ICollectable
{
    [SerializeField] GameObject _door;

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
        _door.SetActive(false);
        Destroy(gameObject);
    }
}
