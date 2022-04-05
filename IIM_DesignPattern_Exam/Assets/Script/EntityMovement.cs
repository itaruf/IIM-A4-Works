using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed=1;

    public Vector2 Direction { get; private set; }

    public void PrepareDirection(Vector2 v) => Direction = v.normalized;

    void FixedUpdate()
    {
        // Update Movement
        //transform.Translate(Direction * Time.deltaTime * _speed, Space.World);
        _rb.MovePosition(_rb.position + (Direction * _speed));
    }


}
