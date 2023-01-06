using System.Collections.Generic;
using UnityEngine;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset genericEventsJSON;
    public TextAsset mainEventsJSON;
    public KingdomStatsScript kingdomStats;
    Events genericEvents;
    MainEvents mainEvents;
    List<Event> genericEventsOrder;
    Dictionary<EventMain, int> mainEventsOrder;
    public int eventNo = 0;
    public int mainEventNo = 0;
    
    public int genericEventNo = 0;
    public GenericEventPlayer genericEventPlayer;
    public MainEventPlayer mainEventPlayer;

    public ExpositionFadeScript expositionFadeScript;
    public ExpositionTextRevealScript expositionTextRevealScript;
    public ExpositionTextParser expositionTextParser;
    string[] exposition;
    public bool playingMainEvent = false;
    public bool playingGenericEvent = false;
    public bool playingIntroduction = false;

    public bool displayingIntroduction = false;

    bool finishedIntro = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGameLoop();
    }

    // public List<Event> ConstructChronology() {
    //     List<Event> eventsList = new List<Event>() 
    //     {
    //         genericEvents.events[0], genericEvents.events[1]
    //     };

    //     return eventsList; 
    // }

    // public Dictionary<EventMain, int> ConstructMainEventChronology() {
    //     Dictionary<EventMain, int> mainEventsDict = new Dictionary<EventMain, int>() 
    //     {
    //         {mainEvents.mainEvents[0], 1}, {mainEvents.mainEvents[1], 2}, {mainEvents.mainEvents[2], 3}
    //     };

    //     return mainEventsDict; 
    // }

    private void StartGameLoop() {
        //StartCoroutine(expositionTextRevealScript.NewTextToDisplay("hallo, my nam is jam an i leik potato it is my fav thing in wurld."));
        exposition = expositionTextParser.GetExposition();

        //expositionFadeScript.EndExposition();
        Debug.Log("Starting Main Game Loop");
        Debug.Log("Setting Start Stats");
        
        kingdomStats.UpdateStatSprites();
        Debug.Log("Importing Generic Events");
        genericEvents = EventJSONReader.GenerateEventsFromJSON(genericEventsJSON);
        //genericEvents = EventJSONReader.GenerateEventsFromJSON(mainEventsJSON);

        // Play back story
        mainEvents = MainEventJSONReader.GenerateEventsFromJSON(mainEventsJSON);
        Debug.Log("mainEvents: " + mainEvents + " mainEvents.mainEvents: " + mainEvents.mainEvents.Count);
        // Construct eventsOrder with generic and main events:
        // eventsOrder = ConstructChronology();
        genericEventsOrder = genericEvents.events;
        for (int i=0; i < genericEventsOrder.Count; i++) {
            Event temp = genericEventsOrder[i];
            int random = Random.Range(i, genericEventsOrder.Count);
            genericEventsOrder[i] = genericEventsOrder[random];
            genericEventsOrder[random] = temp;
        }
        
        // mainEventsOrder = ConstructMainEventChronology();
        // Three Generic Events
        //genericEventPlayer.PlayEvent(genericEvents.events[0]);
        playingIntroduction = true;

        Debug.Log("Starting Introduction Exposition: " + exposition[0]);
        StartCoroutine(expositionTextRevealScript.NewTextToDisplay(exposition[0]));

        
        // One Main Story Event

        // Three Generic Events

        // One Main Story Event

        // Three Generic Events

        // One Main Story Event

        // Three Generic Events

        // One Main Story Event

        // Three Generic Events

        // One Main Story Event
    }

    public void FinishedReadingExposition() {
        if (playingIntroduction) {
            Debug.Log("Finished reading introduction, waiting for space");
            playingIntroduction = false;
            displayingIntroduction = true;
            
        }
    }

    public void FinishedHidingExposition() {
        if (!finishedIntro) {
            finishedIntro = true;
            Debug.Log("Finished fading out introduction, starting main game");
            IntroductionExpositionFinished();

        }
    }

   

    void LateUpdate() {
        if (Input.GetKeyDown("space")) {
            if(displayingIntroduction) {
                Debug.Log("Detected space after finishing introduction text, starting fade out");
                displayingIntroduction = false;
                expositionFadeScript.EndExposition();
            }
        }
    }
    

    public void IntroductionExpositionFinished() {
        playingMainEvent = true;
        mainEventPlayer.PlayEvent(mainEvents.mainEvents[mainEventNo]);
        //genericEventPlayer.PlayEvent(mainEvents.events[0]);
        eventNo++;
        
    }

    public void EventEnded() {
        playingGenericEvent = false;
        playingMainEvent = false;
        // Every 4 events play main story event
        if (eventNo % 2 == 0) {
            Debug.Log("Starting next main event: " + mainEventNo);
            EventMain eventMain = mainEvents.mainEvents[mainEventNo];
            Debug.Log("Found main event: " + eventMain.description);
            playingMainEvent = true;
            if (mainEventNo >= 7) {
                Debug.Log("Final Main Event");
                mainEventPlayer.finalEvent = true;
            }
            mainEventPlayer.PlayEvent(eventMain);
            
    
            // mainEventNo = mainEventsOrder[eventMain];
            // Debug.Log("Setting mainEventNo to " + mainEventNo);
            eventNo ++;
        }
        else {
            Debug.Log("Starting next generic event: " + genericEventNo);
            Event genericEvent = genericEventsOrder[genericEventNo];
            Debug.Log("Found generic event: " + genericEvent.description);
            playingGenericEvent = true;
            genericEventPlayer.PlayEvent(genericEvent);

            genericEventNo ++;
            eventNo ++;
        }
        
    }
    public void FinalEventEnded() {
        playingMainEvent = false;
        Debug.Log("Final event ended");
        Debug.Log("Starting final screen with last exposition of event " + mainEventNo);
        
    }
}
