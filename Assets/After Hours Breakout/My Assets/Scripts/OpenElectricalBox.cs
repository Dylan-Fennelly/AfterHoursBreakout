using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;
using GD;

public class OpenElectricalBox : OpenDoor
{
    [SerializeField]
    private GameEvent openElectricalBoxEvent;
    [Button]
    public override void Interact()
    {
        base.Interact();
        openElectricalBoxEvent.Raise();
    }
}
