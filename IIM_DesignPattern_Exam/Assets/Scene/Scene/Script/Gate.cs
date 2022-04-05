using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    [SerializeField] List<MyToggle> toggles;
   
    public void CheckState()
    {
        foreach (MyToggle myToggle in toggles)
        {
            if (!myToggle.IsActive) {
                return;
            }
        }
        gameObject.SetActive(false);
    }
}
