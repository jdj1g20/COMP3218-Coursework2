using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatType
{
    public string statName;
    public int statAmount;
    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;

    public StatType (string statName, int statAmount, List<Sprite> spriteList, SpriteRenderer spriteRenderer) {
        this.statName = statName;
        this.statAmount = statAmount;
        this.spriteList = spriteList;
        this.spriteRenderer = spriteRenderer;
    }
}
