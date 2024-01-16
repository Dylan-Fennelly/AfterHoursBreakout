using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickedUp : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameEvent keyPickedUp;
    public void Interact()
    {
        keyPickedUp.Raise();    
    }
}
