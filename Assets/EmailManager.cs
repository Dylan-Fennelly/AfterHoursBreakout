using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
 
    public TextMeshPro emailText;
    public SafeCombination safeCombinationData;
    public EmailData emailData;

    private void Start()
    {
        if (emailData != null && emailText != null && safeCombinationData != null)
        {
            string formattedEmailText = emailData.emailText.Replace("[Default Value]", safeCombinationData.combination);
            emailText.text = formattedEmailText;
        }
        else
        {
            string formattedEmailText = emailData.emailText.Replace("[Default Value]", "1234");
        }
    }
}
