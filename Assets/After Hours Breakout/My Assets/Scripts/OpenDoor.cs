using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;
using UnityEditor.Build;

public class OpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    private string animatorBoolName = "doorOpened";
    [SerializeField]
    private string animatorTriggerName = "";
    [SerializeField]
    protected bool isLocked = false;
    //Use odin to make a button that trggers the function in the editer
    [Button]
    public virtual void Interact()
    {
        if (isLocked == false)
        {
            animator.SetBool(animatorBoolName, true);
        }
        else if(!string.IsNullOrEmpty(animatorTriggerName))
        {
            animator.SetTrigger(animatorTriggerName);
        }
        
    }
    public void Unlock()
    {
        isLocked = false;
    }
}
