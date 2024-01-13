using GD;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDoorController : MonoBehaviour
{
    [SerializeField]
    private GameEvent safeUnlocked;
    [SerializeField]
    private string password = "1234";
    [SerializeField]
    private string input = "";

    public void ButtonPressed(string buttonValue)
    {
        if(buttonValue == "Enter")
        {
            CheckCombination();
            return;
        }
        input += buttonValue;

        if (input.Length > 4)
        {
            CheckCombination();
        }
    }

    private void CheckCombination()
    {
        if(input == password)
        {
            safeUnlocked.Raise();
        }
        else
        {
            input = "";
        }
    }
}
