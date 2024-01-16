using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    //THis will change the colour of the pointlight to green when the safe is unlocked
    [SerializeField]
    private Color green = Color.green;

    public void Change()
    {
        GetComponent<Light>().color = green;  
    }


}
