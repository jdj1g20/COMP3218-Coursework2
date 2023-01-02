using System.Collections.Generic;
using UnityEngine;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset genericEventsJSON;
    public TextAsset mainEventsJSON;
    public KingdomStatsScript kingdomStats;
    Events genericEvents;
    MainEvents mainEvents;
    List<Event> eventsOrder;
    Dictionary<EventMain, int> mainEventsOrder;
    int eventNo = 0;
    int mainEventNo = 0;
    public GenericEventPlayer genericEventPlayer;
    public MainEventPlayer mainEventPlayer;

    public bool playingMainEvent = false;
    public bool playingGenericEvent = false;
    // Start is called before the first frame update
    void Start()
    {
        StartGameLoop();
    }

    public List<Event> ConstructChronology() {
        List<Event> eventsList = new List<Event>() 
        {
            genericEvents.events[0], genericEvents.events[1]
        };

        return eventsList; 
    }

    public Dictionary<EventMain, int> ConstructMainEventChronology() {
        Dictionary<EventMain, int> mainEventsDict = new Dictionary<EventMain, int>() 
        {
            {mainEvents.mainEvents[0], 1}, {mainEvents.mainEvents[1], 2}, {mainEvents.mainEvents[2], 3}
        };

        return mainEventsDict; 
    }

    private void StartGameLoop() {
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
        eventsOrder = ConstructChronology();
        mainEventsOrder = ConstructMainEventChronology();
        // Three Generic Events
        //genericEventPlayer.PlayEvent(genericEvents.events[0]);
        playingGenericEvent = true;
        genericEventPlayer.PlayEvent(eventsOrder[eventNo]);
        //genericEventPlayer.PlayEvent(mainEvents.events[0]);
        eventNo++;
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

    public void EventEnded() {
        playingGenericEvent = false;
        playingMainEvent = false;
        // Every 4 events play main story event
        if (1 == 1) {
            Debug.Log("Starting next main event: " + mainEventNo);
            EventMain eventMain = mainEvents.mainEvents[mainEventNo];
            Debug.Log("Found main event: " + eventMain.description);
            playingMainEvent = true;
            mainEventPlayer.PlayEvent(eventMain);
    
            mainEventNo = mainEventsOrder[eventMain];
            Debug.Log("Setting mainEventNo to " + mainEventNo);
            eventNo ++;
        }
        else if (eventNo < eventsOrder.Count) {
            // Debug.Log("Starting next event");
            // genericEventPlayer.PlayEvent(eventsOrder[eventNo]);
            // eventNo++;
        } else {
            Debug.Log("Reached end of event list");
        }
        
    }
}
