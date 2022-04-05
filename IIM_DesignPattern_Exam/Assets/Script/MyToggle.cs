using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un évènement pour les designers pour qu'ils puissent set la couleur du sprite eux même
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;

    public bool IsActive { get; private set; }

    private void Awake()
    {
    }
    public void Touch(int power)
    {
        IsActive = !IsActive;

        if (IsActive)
            _onToggleOn?.Invoke();
        else
            _onToggleOff?.Invoke();
    }
}
