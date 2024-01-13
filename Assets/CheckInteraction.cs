using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameEvent safe;
    public void Interact()
    {
        safe.Raise();
    }
}
