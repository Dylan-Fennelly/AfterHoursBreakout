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

}
