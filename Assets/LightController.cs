using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        // The light starts turned off
        lightComponent.enabled = false;
    }
    public void TurnOn()
    {
        lightComponent.enabled = true;
    }
    
}

