using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GenericEventPlayer : MonoBehaviour
{
    
    GameObject advisor;
    [SerializeField]
    GameObject eventCanvas, button1, button2;

    [SerializeField]
    TextMeshProUGUI eventDescription, button1Description, button2Description;

    public void PlayGenericEvent(Event eventToPlay)
    {
        eventCanvas.SetActive(true);
        button1.SetActive(false); 
        button2.SetActive(false);
        
    }
}
