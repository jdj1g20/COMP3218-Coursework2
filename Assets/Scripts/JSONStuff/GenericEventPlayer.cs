using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenericEventPlayer : MonoBehaviour
{
    
    GameObject advisor;
    [SerializeField]
    GameObject eventCanvas, eventDescriptionBox, button1, button2;
    [SerializeField]
    TextRevealScript eventText;
    [SerializeField]
    TextMeshProUGUI button1Text, button2Text;

    [SerializeField]
    TextMeshProUGUI eventDescription, button1Description, button2Description;

    Event currentEvent;
    float waitAfterDescription = 1f;

    void Start() {
        //eventText = eventDescriptionBox.GetComponent<TextRevealScript>();
        //button1Text = button1.GetComponent<TextRevealScript>();
        //button2Text = button2.GetComponent<TextRevealScript>();
    }
    public IEnumerator PlayGenericEvent(Event eventToPlay)
    {
        currentEvent = eventToPlay;
        Debug.Log("Starting event");
        eventCanvas.SetActive(true);
        button1.SetActive(false); 
        button2.SetActive(false);

        StartCoroutine(eventText.NewTextToDisplay(eventToPlay.description));
        yield return new WaitForSeconds(eventToPlay.description.Length * 0.1f + waitAfterDescription);

        button1.SetActive(true);
        button2.SetActive(true);

        button1Text.text = eventToPlay.decision1Desc;
        button2Text.text = eventToPlay.decision2Desc;
    }

    public void SelectedButton1(){
        StartCoroutine(Button1Select());
    }

    public void SelectedButton2(){
        StartCoroutine(Button2Select());
    }
    public IEnumerator Button1Select(){
        Debug.Log("Chosen Decision 1");
        yield return new WaitForSeconds(0.3f);
        button1.SetActive(false);
        button2.SetActive(false);
        string eventString = currentEvent.decision1.description + "\n";
        if(currentEvent.decision1.stat1Amount > 0) {
            eventString += "Increasing ";
        } else {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision1.stat1 + " By " + Mathf.Abs(currentEvent.decision1.stat1Amount) + "\n";

        if(currentEvent.decision1.stat2Amount > 0) {
            eventString += "Increasing ";
        } else {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision1.stat2 + " By " + Mathf.Abs(currentEvent.decision1.stat2Amount);

        StartCoroutine(eventText.NewTextToDisplay(eventString));
        yield return new WaitForSeconds(eventString.Length * 0.1f + waitAfterDescription);
    }

    public IEnumerator Button2Select(){
        Debug.Log("Chosen Decision 2");
        yield return new WaitForSeconds(0.3f);
        button1.SetActive(false);
        button2.SetActive(false);

        string eventString = currentEvent.decision2.description + "\n";
        if(currentEvent.decision2.stat1Amount > 0) {
            eventString += "Increasing ";
        } else {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision2.stat1 + " By " + Mathf.Abs(currentEvent.decision2.stat1Amount) + "\n";

        if(currentEvent.decision2.stat2Amount > 0) {
            eventString += "Increasing ";
        } else {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision2.stat2 + " By " + Mathf.Abs(currentEvent.decision2.stat2Amount);

        StartCoroutine(eventText.NewTextToDisplay(eventString));
        yield return new WaitForSeconds(eventString.Length * 0.1f + waitAfterDescription);
    }

    
}
