using UnityEngine;

[CreateAssetMenu(fileName = "NewEmailData", menuName = "Email Data", order = 51)]
public class EmailData : ScriptableObject
{
    [TextArea(3, 10)]
    public string emailText = "Replace this with your email text.";

    public SafeCombination safeCombinationData;
}
