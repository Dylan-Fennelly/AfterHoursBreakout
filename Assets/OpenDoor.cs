using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class OpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    protected Animator animator;
    //Use odin to make a button that trggers the function in the editer
    [Button]
    public virtual void Interact()
    {
        animator.SetBool("doorOpened", true);
    }
}
