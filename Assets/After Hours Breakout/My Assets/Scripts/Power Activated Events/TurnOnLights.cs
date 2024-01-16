using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    public void TurnOn()
    {
        LightController[] light = FindObjectsOfType<LightController>();
        foreach (LightController l in light)
        {
            l.TurnOn();
        }
    }
}
