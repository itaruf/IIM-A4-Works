using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityOrientation : MonoBehaviour
{
    [SerializeField] CursorReference _cursorRef;
    [SerializeField] PlayerEntity _player;

    [SerializeField] SpriteRenderer _sprite;

    private void Update()
    {
        _sprite.flipX = _cursorRef.Instance.transform.position.x < _player.transform.position.x ? true : false;
    }

}
