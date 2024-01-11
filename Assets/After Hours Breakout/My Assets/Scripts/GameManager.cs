using GD;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public NavMeshSurface surface;
    public EmptyGameEvent emptyGameEvent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {   
            Destroy(gameObject);
        }
    }
    public void OnDoorOpen()
    {
        BakeNavMesh();
    
    }
    [Button]
    public void turnOnLights()
    {
        emptyGameEvent.Raise(new Empty());
    }
    private void BakeNavMesh()
    {
        Console.WriteLine("Baking NavMesh");
        surface.BuildNavMesh();
        Console.WriteLine("NavMesh Baked");
    }
}
