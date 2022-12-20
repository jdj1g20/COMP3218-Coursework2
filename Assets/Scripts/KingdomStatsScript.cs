using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KingdomStatsScript : MonoBehaviour
{
    [SerializeField]
    List<Sprite> militarySprites, economySprites, diplomacySprites, approvalSprites;
    [SerializeField]
    SpriteRenderer militarySpriteRenderer, economySpriteRenderer, diplomacySpriteRenderer, approvalSpriteRenderer;
    [SerializeField]
    List<StatType> statList;
    [SerializeField]
    TextMeshProUGUI militaryT, economyT, diplomacyT, approvalT;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Initialising StatList");
        militaryT.SetText("5");
        economyT.SetText("5");
        diplomacyT.SetText("5");
        approvalT.SetText("5");
        statList = new List<StatType>() {
            new StatType("military", 5, militarySprites, militarySpriteRenderer, militaryT),
            new StatType("economy", 5, economySprites, economySpriteRenderer, economyT),
            new StatType("diplomacy", 5, diplomacySprites, diplomacySpriteRenderer, diplomacyT),
            new StatType("approval", 5, approvalSprites, approvalSpriteRenderer, approvalT)};
    }
    
    
    public void ChangeStats(string stat, int Amount){
        if(stat == "Military") {
            statList[0].statAmount += Amount;
        } else if(stat == "Economy") {
            statList[1].statAmount += Amount;
        } else if(stat == "Diplomacy") {
            statList[2].statAmount += Amount;
        } else if(stat == "Approval") {
            statList[4].statAmount += Amount;
        }
    }
    public void UpdateStatSprites () {
        foreach (var stat in statList)
        {
            stat.spriteRenderer.sprite = stat.spriteList[stat.statAmount];
            stat.statNumber.SetText(stat.statAmount.ToString());
        }

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
