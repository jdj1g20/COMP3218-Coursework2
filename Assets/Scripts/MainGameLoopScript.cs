using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset genericEventsJSON;
    public TextAsset mainEventsJSON;
    public KingdomStatsScript kingdomStats;
    Events genericEvents;
    Events mainEvents;
    List<Event> eventsOrder;
    int eventNo = 0;
    public GenericEventPlayer genericEventPlayer;
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

    private void StartGameLoop() {
        Debug.Log("Starting Main Game Loop");
        Debug.Log("Setting Start Stats");
        
        kingdomStats.UpdateStatSprites();
        Debug.Log("Importing Generic Events");
        genericEvents = EventJSONReader.GenerateEventsFromJSON(genericEventsJSON);

        // Play back story
        
        // Construct eventsOrder with generic and main events:
        eventsOrder = ConstructChronology();

        // Three Generic Events
        genericEventPlayer.PlayEvent(eventsOrder[eventNo]);
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
        if (eventNo < eventsOrder.Count) {
            Debug.Log("Starting next event");
            genericEventPlayer.PlayEvent(eventsOrder[eventNo]);
            eventNo++;
        } else {
            Debug.Log("Reached end of event list");
        }
        
    }
}
