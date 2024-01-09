using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class DoorInteraction: MonoBehaviour,IIteractable
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private NavMeshObstacle obstacle;
    //Use odin to make a button that trggers the function in the editer
    [Button]
    public void Interact()
    {
        obstacle.enabled = false;
        animator.SetBool("doorOpened",true);
    }
}
