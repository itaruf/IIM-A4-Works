using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;

    [SerializeField] public UnityEvent _onPlaySFX;
    [SerializeField] public UnityEvent _onPlayVFX;

    [SerializeField] public AudioReference _sfxRef;
    [SerializeField] public AudioSource _sfx;

    // Events
    public event UnityAction OnPlaySFX;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        OnPlaySFX += _sfx.Play;
        _sfxRef.Instance.SoundCallBack(OnPlaySFX);

        collision.GetComponent<IHealth>()?.TakeDamage(Power);

        collision.GetComponent<ITouchable>()?.Touch(Power);

        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        OnPlaySFX += _sfx.Play;
        _sfxRef.Instance.SoundCallBack(OnPlaySFX);

        collision.collider.GetComponent<IHealth>()?.TakeDamage(Power);

        collision.collider.GetComponent<ITouchable>()?.Touch(Power);

        gameObject.SetActive(false);
    }

    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }
}
