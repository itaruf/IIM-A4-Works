using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShield : MonoBehaviour
{
    [SerializeField] bool isActive;

    public bool IsActive { get => isActive; set => isActive = value; }

    public void Shield()
    {
        IsActive = !IsActive;
        Debug.Log("Shield Activated");
    }

    public void CancelShield()
    {
        IsActive = !IsActive;
        Debug.Log("Shield Deactivated");
    }
}
