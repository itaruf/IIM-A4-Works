using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] ControlShakeReference _controlShakeReference;

    public Health Health => _health;

    private void Awake()
    {
        _health.OnDamage += Shake;
    }

    private void OnDestroy()
    {
        _health.OnDamage -= Shake;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<ICollectable>()?.Collected();
    }

    void Shake(int value)
    {
        _controlShakeReference.Instance.LaunchScreenShake();
    }
}


