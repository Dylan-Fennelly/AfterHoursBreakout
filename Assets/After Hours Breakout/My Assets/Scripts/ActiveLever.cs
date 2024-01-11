using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveLever : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Animator animator;
    [Button]
    public void Interact()
    {
        if(animator.GetBool("Button1Active")==true&& animator.GetBool("Button2Active") == true&& animator.GetBool("Button3Active") == true)
        {
            animator.SetBool("HandleFlipped", true);
        }
        else
        {
            return;
        }
    }
}
