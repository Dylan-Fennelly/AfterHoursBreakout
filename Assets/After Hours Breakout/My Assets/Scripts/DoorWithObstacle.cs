using Sirenix.OdinInspector;
using UnityEngine.AI;
using UnityEngine;

public class DoorWithObstacle : OpenDoor
{
    [SerializeField]
    private NavMeshObstacle obstacle;

    [Button]
    public override void Interact()
    {
        base.Interact(); // Call the base class Interact method

        DisableObstacle();
    }

    private void DisableObstacle()
    {
        if (obstacle != null)
        {
            obstacle.enabled = false;
        }
    }
}