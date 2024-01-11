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
    [Button]
    public void FocusOnPoint()
    {
        changeCamera();
    }
    [Button]
    public void FocusOnPlayer()
    {
        changeCameraBack();
    }

    private void changeCameraBack()
    {
        playerCamera.Priority++;
        focusCamera.Priority--;

    }

    //Transitions the ciew to the selected camera
    private void changeCamera()
    {
        playerCamera.Priority -- ;
        focusCamera.Priority ++;
    }

}
