using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoopScript : MonoBehaviour
{
    public TextAsset genericEventsJSON;
    public TextAsset mainEventsJSON;
    Events genericEvents;
    Events mainEvents;
    // Start is called before the first frame update
    void Start()
    {
        genericEvents = EventJSONReader.GenerateEventsFromJSON(genericEventsJSON);

        // Play back story

        // Three Generic Events

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
