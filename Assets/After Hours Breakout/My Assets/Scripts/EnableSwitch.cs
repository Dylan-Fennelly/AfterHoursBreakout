using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSwitch : MonoBehaviour, IInteractable
{
    private int switchCount = 0;
    [SerializeField]
    private Animator animator;
    public void Interact()
    {
        switch (switchCount)
        {
            case 0:
                animator.SetBool("Button1Active", true);
                switchCount++;
                break;
            case 1:
                animator.SetBool("Button2Active", true);
                switchCount++;
                break;
            case 2:
                animator.SetBool("Button3Active", true);
                switchCount++;
                break;
        }
    }
}
