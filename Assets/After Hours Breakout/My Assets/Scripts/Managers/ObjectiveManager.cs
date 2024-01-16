using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI objectiveText;
    [SerializeField]
    private ObjectiveList objectiveList;
    
    public void SetEscapeText()
    {
        objectiveText.text = objectiveList.EscapeText;
    }
    public void SetGetKeyText()
    {
        if(objectiveText.text.Equals(""))
        objectiveText.text = objectiveList.getKeyText;
    }
    public void SetTurnOnPower()
    {
        if(!(objectiveText.text.Equals(objectiveList.unlockSafe)&&
            objectiveText.text.Equals(objectiveList.findCombination)&& 
            objectiveText.text.Equals(objectiveList.EscapeText)))
        {
             objectiveText.text = objectiveList.turnOnPower;
        }
       
    }
    public void SetUnlockSafe()
    {
        if(!(objectiveText.text.Equals(objectiveList.EscapeText)&&
            objectiveText.text.Equals(objectiveList.getKeyText)&&
            objectiveText.text.Equals(objectiveList.turnOnPower)&&
            objectiveText.text.Equals(objectiveList.findCombination)))
        {
            objectiveText.text = objectiveList.unlockSafe;
        }
        
    }
    public void SetFindCombination()
    {
        if (!(objectiveText.text.Equals(objectiveList.EscapeText)&& objectiveText.text.Equals(objectiveList.findCombination)))
        {
            objectiveText.text = objectiveList.findCombination;
        }
        
    }
    public void SetBlank()
    {
        objectiveText.text = "";
    }
    
}
