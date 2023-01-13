using UnityEngine;
using System.Collections.Generic;

public class ShowBonusTime : MonoBehaviour
{
    [SerializeField] private List<GameObject> _doublingScoreBonusIcon;
    private void Update() 
    {
        SetActiveBonusIcon(ref DoublingScore._isDoublingScore, _doublingScoreBonusIcon[0]);
    }

    private void SetActiveBonusIcon(ref bool isDoingBonus, GameObject bonusIcon)
    {
        if(isDoingBonus){
            bonusIcon.SetActive(true);
            isDoingBonus = false;
        }
    }
}
