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

    public GenericEventPlayer genericEventPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Main Game Loop");
        Debug.Log("Setting Start Stats");
        kingdomStats.UpdateStatSprites();
        Debug.Log("Importing Generic Events");
        genericEvents = EventJSONReader.GenerateEventsFromJSON(genericEventsJSON);

        // Play back story
        Debug.Log("genericEvents.events[0].description");
        Debug.Log(genericEvents.events[0].description);
        // Three Generic Events
        genericEventPlayer.PlayEvent(genericEvents.events[0]);
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

    // Update is called once per frame
    void Update()
    {

    }
}
