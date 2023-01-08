using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KingdomStatsScript : MonoBehaviour
{
    [SerializeField]
    List<Sprite> militarySprites, economySprites, diplomacySprites, approvalSprites, foodSprites;
    [SerializeField]
    SpriteRenderer militarySpriteRenderer, economySpriteRenderer, diplomacySpriteRenderer, approvalSpriteRenderer, foodSpriteRenderer;
    [SerializeField]
    List<StatType> statList;
    [SerializeField]
    TextMeshProUGUI militaryT, economyT, diplomacyT, approvalT, foodT;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Initialising StatList");
        militaryT.SetText("5");
        economyT.SetText("5");
        diplomacyT.SetText("5");
        approvalT.SetText("5");
        foodT.SetText("5");
        statList = new List<StatType>() {
            new StatType("military", 5, militarySprites, militarySpriteRenderer, militaryT),
            new StatType("economy", 5, economySprites, economySpriteRenderer, economyT),
            new StatType("diplomacy", 5, diplomacySprites, diplomacySpriteRenderer, diplomacyT),
            new StatType("approval", 5, approvalSprites, approvalSpriteRenderer, approvalT),
            new StatType("food", 5, foodSprites, foodSpriteRenderer, foodT)};
    }
    
    
    public void ChangeStats(string stat, int Amount){
        if(stat == "military") {
            Debug.Log("Changing Military by " + Amount);
            
            int newAmount = CheckStatBoundaries(statList[0], Amount);
            StartCoroutine(ChangeStatColour(statList[0], newAmount));
        } else if(stat == "economy") {
            Debug.Log("Changing Economy by " + Amount);
            int newAmount = CheckStatBoundaries(statList[1], Amount);
            StartCoroutine(ChangeStatColour(statList[1], newAmount));
        } else if(stat == "diplomacy") {
            Debug.Log("Changing Diplomacy by " + Amount);
            int newAmount = CheckStatBoundaries(statList[2], Amount);
            StartCoroutine(ChangeStatColour(statList[2], newAmount));
        } else if(stat == "approval") {
            Debug.Log("Changing Approval by " + Amount);
            int newAmount = CheckStatBoundaries(statList[3], Amount);
            StartCoroutine(ChangeStatColour(statList[3], newAmount));
        } else if(stat == "food") {
            Debug.Log("Changing Food by " + Amount);
            int newAmount = CheckStatBoundaries(statList[4], Amount);
            StartCoroutine(ChangeStatColour(statList[4], newAmount));
        }
    }

    private int CheckStatBoundaries(StatType stat, int amount) {
        int newStatAmount = stat.statAmount + amount;
        int newAmount = amount;
        if (newStatAmount > 10) {
            Debug.Log("Stat Increasing Over 10, Setting to 10");
            newAmount = 10 - stat.statAmount;
            stat.statAmount = 10;
        } else if (newStatAmount < 0) {
            newAmount = 0 - stat.statAmount;
            stat.statAmount = 0;
        } else
        {
            stat.statAmount += amount;
        }
        return newAmount;
    }
    private IEnumerator ChangeStatColour(StatType stat, int amount) {
        if (amount > 0) {
            Debug.Log("Turning stat green");
            stat.spriteRenderer.color = Color.green;
        } else {
            Debug.Log("Turning stat red");
            stat.spriteRenderer.color = Color.red;
        }
        if (stat.statAmount > 0) {
            yield return new WaitForSeconds(1f);
            Debug.Log("Turning stat white");
            stat.spriteRenderer.color = Color.white;
        }
        
    }
    public void UpdateStatSprites () {
        foreach (var stat in statList)
        {
            stat.spriteRenderer.sprite = stat.spriteList[stat.statAmount];
            stat.statNumber.SetText(stat.statAmount.ToString());
        }

    }

    public string CheckForZeroStat() {
        foreach (var stat in statList)
        {
            if(stat.statAmount < 1) {
                Debug.Log("Found stat at zero: " + stat.statName);
                return(stat.statName);
            }

        }
        return "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
