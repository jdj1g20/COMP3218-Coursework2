using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingdomStatsScript : MonoBehaviour
{
    [SerializeField]
    List<Sprite> militarySprites, economySprites, diplomacySprites, approvalSprites;
    [SerializeField]
    SpriteRenderer militarySpriteRenderer, economySpriteRenderer, diplomacySpriteRenderer, approvalSpriteRenderer;
    [SerializeField]
    List<StatType> statList;

    
    
    
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
             
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        statList = new List<StatType>() {
            new StatType("military", 5, militarySprites, militarySpriteRenderer),
            new StatType("economy", 5, economySprites, economySpriteRenderer),
            new StatType("diplomacy", 5, diplomacySprites, diplomacySpriteRenderer),
            new StatType("approval", 5, approvalSprites, approvalSpriteRenderer)};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
