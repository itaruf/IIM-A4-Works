using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EntityRotation : MonoBehaviour
{
    public Vector2 AimPosition { get; set; }

    public static Quaternion AimPositionToZRotation(Vector3 entityPosition, Vector3 aimPosition)
    {
        Vector3 diff = (aimPosition - entityPosition).normalized;
        return Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
    }

    private void LateUpdate()
    {
        transform.rotation = AimPositionToZRotation(transform.position, AimPosition);
    }

}
