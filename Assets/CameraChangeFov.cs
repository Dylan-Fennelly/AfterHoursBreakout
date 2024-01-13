using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeFov : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera vcam;

   
    public void Change()
    {
        vcam.m_Lens.FieldOfView = 90;
    }
}
