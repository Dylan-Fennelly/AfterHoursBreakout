using GD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithCutscene : DoorWithObstacle
{
    [SerializeField]
    private CameraFocusOnPoint cameraFocuser;
    [SerializeField]
    private float timeToFocusOnPointLocked;
    [SerializeField]
    private float timeToFocusOnPointUnlocked;

    public override void Interact()
    {
        base.Interact();
        cameraFocuser.FocusOnPoint();
        if (isLocked)
        {
            StartCoroutine(RefocusOnPlayer(timeToFocusOnPointLocked));
        }
        else
        {
            StartCoroutine(RefocusOnPlayer(timeToFocusOnPointUnlocked));
        }
    }
    IEnumerator RefocusOnPlayer(float timeToFocusOnPoint)
    {
        yield return new WaitForSeconds(timeToFocusOnPoint);
        cameraFocuser.FocusOnPlayer();
    }
    

}
