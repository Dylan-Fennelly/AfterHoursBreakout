using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public NavMeshSurface surface;

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

    private void BakeNavMesh()
    {
        Console.WriteLine("Baking NavMesh");
        surface.BuildNavMesh();
        Console.WriteLine("NavMesh Baked");
    }
}
