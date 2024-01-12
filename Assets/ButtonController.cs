using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour, IInteractable
{
    [SerializeField]
    private StringGameEvent safeButton;
    [SerializeField]
    private string buttonNumber;
    
    public void Interact()
    {
        safeButton.Raise(buttonNumber);
    }
}
