using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPaper : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameEvent readPaper;
    public void Interact()
    {
        readPaper.Raise();
    }
}
