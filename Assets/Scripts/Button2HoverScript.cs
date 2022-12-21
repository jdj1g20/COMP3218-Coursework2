using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Button2HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    SpriteRenderer military, economy, diplomacy, approval;
    [SerializeField]
    GenericEventPlayer eventPlayer;
    
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("Mouse Enter Button2");
        Event currentEvent = eventPlayer.currentEvent;
        string stat1 = currentEvent.decision2.stat1;
        string stat2 = currentEvent.decision2.stat2;
        ChangeStatColourYellow(CheckStat(stat1), CheckStat(stat2));
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("Mouse Exit Button2");
        Event currentEvent = eventPlayer.currentEvent;
        string stat1 = currentEvent.decision2.stat1;
        string stat2 = currentEvent.decision2.stat2;
        ChangeStatColourWhite(CheckStat(stat1), CheckStat(stat2));
        
    }

    private SpriteRenderer CheckStat(string stat) {
        if (stat == "Military") {
            return military;
        } else if (stat == "Economy") {
            return economy;
        } else if (stat == "Diplomacy") {
            return diplomacy;
        } else if (stat == "Approval") {
            return approval;
        }
        Debug.LogError("Can't find Stat (Button1HoverScript)");
        return null;
    }
    private void ChangeStatColourYellow(SpriteRenderer sprite1, SpriteRenderer sprite2){
        if (sprite1 != null) {
            sprite1.color = Color.yellow;
        }
        if (sprite2 != null) {
            sprite2.color = Color.yellow;
        }
        
    }

    private void ChangeStatColourWhite(SpriteRenderer sprite1, SpriteRenderer sprite2){
        if (sprite1 != null) {
            sprite1.color = Color.white;
        }
        if (sprite2 != null) {
            sprite2.color = Color.white;
        }
    }
}
