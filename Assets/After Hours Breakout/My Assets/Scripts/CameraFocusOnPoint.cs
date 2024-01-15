using Cinemachine;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusOnPoint : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera playerCamera;
    [SerializeField]
    private CinemachineVirtualCamera focusCamera;
    [SerializeField]
    private SkinnedMeshRenderer PlayerMesh;
    [Button]
    private void Awake()
    {
        PlayerMesh = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SkinnedMeshRenderer>();
    }
    public void FocusOnPoint()
    {
        PlayerMesh.enabled = false;
        changeCamera();
    }
    [Button]
    public void FocusOnPlayer()
    {
        PlayerMesh.enabled = true;
        changeCameraBack();
    }

    private void changeCameraBack()
    {
        playerCamera.Priority=1;
        focusCamera.Priority=0;

    }

    //Transitions the ciew to the selected camera
    private void changeCamera()
    {
        playerCamera.Priority = 0 ;
        focusCamera.Priority =1;
    }

}
