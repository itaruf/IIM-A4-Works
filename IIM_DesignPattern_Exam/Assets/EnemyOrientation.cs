using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrientation : MonoBehaviour
{
    [SerializeField] Transform _root;
    [SerializeField] PlayerReference _playerRef;
    [SerializeField] SpriteRenderer _sprite;

    private void Update()
    {
        _sprite.flipX = _playerRef.Instance.transform.position.x < _root.transform.position.x ? true : false;
    }

}
