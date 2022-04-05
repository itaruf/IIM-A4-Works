using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowOrientation : MonoBehaviour
{
    [SerializeField] bool _isPlayer;
    [SerializeField] CursorReference _cursorReference;
    [SerializeField] PlayerReference _playerRef;

    [SerializeField] SpriteRenderer _spriteReference;
    [SerializeField] Transform _rootTransform;
    [SerializeField] Vector2 _noFlipPosition;
    [SerializeField] Vector2 _flipPosition;

    Vector3 PositionToUse => _isPlayer ? _cursorReference.Instance.transform.position : _playerRef.Instance.transform.position;

    public static Quaternion AimPositionToZRotation(Vector3 entityPosition, Vector3 aimPosition)
    {
        Vector3 diff = (aimPosition - entityPosition).normalized;
        return Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
    }

    private void LateUpdate()
    {
        transform.rotation = AimPositionToZRotation(transform.position, PositionToUse);
        _rootTransform.localPosition = _spriteReference.flipX ? _flipPosition : _noFlipPosition;
    }

}
