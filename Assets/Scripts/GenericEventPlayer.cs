using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenericEventPlayer : EventPlayer
{
    [SerializeField]
    AdvisorScript advisor;
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
    public bool initialEventDescriptionPlaying = false;
    public bool currentEventEnded = false;
    public KingdomStatsScript kingdomStats;

    void Start()
    {
        //eventText = eventDescriptionBox.GetComponent<TextRevealScript>();
        //button1Text = button1.GetComponent<TextRevealScript>();
        //button2Text = button2.GetComponent<TextRevealScript>();
    }

    public override void PlayEvent(Event eventToPlay)
    {
        currentEvent = eventToPlay;
        Debug.Log("Starting event");
        // Reveal Advisor
        RevealAdvisor();


        currentEventEnded = false;


    }

    public override IEnumerator StartInitialEventDescription()
    {
        yield return (3f);
        eventCanvas.SetActive(true);
        button1.SetActive(false);
        button2.SetActive(false);
        initialEventDescriptionPlaying = true;
        StartCoroutine(eventText.NewTextToDisplay(currentEvent.description));
    }

    private void RevealAdvisor()
    {
        Debug.Log("Revealing Advisor");
        // Set advisor to currentEvent.advisor
        advisor.AdvisorEnterScene();
        //Invoke("StartInitialEventDescription", 5f);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (currentEventEnded)
            {
                kingdomStats.UpdateStatSprites();
                eventCanvas.SetActive(false);
                advisor.AdvisorLeaveScene();
            }
        }
    }


    public override void TextEnded()
    {
        if (initialEventDescriptionPlaying)
        {
            RevealEventChoices();
        }
        else
        {
            currentEventEnded = true;

        }
    }

    public override void RevealEventChoices()
    {
        initialEventDescriptionPlaying = false;
        button1.SetActive(true);
        button2.SetActive(true);
        button1Text.text = currentEvent.decision1Desc;
        button2Text.text = currentEvent.decision2Desc;
    }

    public void SelectedButton1()
    {
        StartCoroutine(Button1Select());
    }

    public void SelectedButton2()
    {
        StartCoroutine(Button2Select());
    }
    public IEnumerator Button1Select()
    {
        Debug.Log("Chosen Decision 1");
        yield return new WaitForSeconds(0.3f);
        button1.SetActive(false);
        button2.SetActive(false);
        string eventString = currentEvent.decision1.description + "\n";
        if (currentEvent.decision1.stat1Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision1.stat1 + " By " + Mathf.Abs(currentEvent.decision1.stat1Amount) + "\n";

        if (currentEvent.decision1.stat2Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision1.stat2 + " By " + Mathf.Abs(currentEvent.decision1.stat2Amount) + "\n";
        eventString += "Press space to continue...";
        
        kingdomStats.ChangeStats(currentEvent.decision1.stat1, currentEvent.decision1.stat1Amount);
        kingdomStats.ChangeStats(currentEvent.decision1.stat2, currentEvent.decision1.stat2Amount);
        StartCoroutine(eventText.NewTextToDisplay(eventString));
    }

    public IEnumerator Button2Select()
    {
        Debug.Log("Chosen Decision 2");
        yield return new WaitForSeconds(0.3f);
        button1.SetActive(false);
        button2.SetActive(false);

        string eventString = currentEvent.decision2.description + "\n";
        if (currentEvent.decision2.stat1Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision2.stat1 + " By " + Mathf.Abs(currentEvent.decision2.stat1Amount) + "\n";

        if (currentEvent.decision2.stat2Amount > 0)
        {
            eventString += "Increasing ";
        }
        else
        {
            eventString += "Decreasing ";
        }
        eventString += currentEvent.decision2.stat2 + " By " + Mathf.Abs(currentEvent.decision2.stat2Amount) + "\n";
        eventString += "Press space to continue...";

        kingdomStats.ChangeStats(currentEvent.decision2.stat1, currentEvent.decision2.stat1Amount);
        kingdomStats.ChangeStats(currentEvent.decision2.stat2, currentEvent.decision2.stat2Amount);

        StartCoroutine(eventText.NewTextToDisplay(eventString));
    }


}
