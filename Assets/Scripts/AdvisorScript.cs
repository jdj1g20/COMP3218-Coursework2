using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvisorScript : MonoBehaviour
{
    [SerializeField]
    EventPlayer eventPlayer;
    SpriteRenderer sprite;
    public bool fadeIn = false;
    public bool fadeOut = false;
    
    public bool spacePressed = false;
    float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void AdvisorEnterScene()
    {
        // Set advisor to face king
        transform.localScale = new Vector3(102.0827f, 92.52522f, 2.214688f);
        // Set advisor to active
        gameObject.SetActive(true);
        // Fade in advisor
        fadeIn = true;
        spacePressed = false;
    }

    private void AdvisorEnteredScene()
    {
        // Call eventPlayer to start reading event description
        StartCoroutine(eventPlayer.StartInitialEventDescription());
    }

    public void AdvisorLeaveScene()
    {
        Debug.Log("AdvisorLeaveScene");
        // Set advisor to face away from king
        transform.localScale = new Vector3(-102.0827f, 92.52522f, 2.214688f);
        // Start fade out
        spacePressed = false;
        fadeOut = true;    
    }

    private void AdvisorLeftScene()
    {
        // Set advisor to inactive
        gameObject.SetActive(false);
        // End of scene
        eventPlayer.EventEnded();
    }


    // Update is called once per frame
    void Update()
    {
        // When space is detected, set spacePressed to true
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Detected Space Press");
            spacePressed = true;
        }
        // If fading in check if space has been pressed
        if (fadeIn)
        {
            //Debug.Log("Fading in");
            if (spacePressed)
            {
                // Skip to faded in
                sprite.color = new Color(1, 1, 1, 1);
                spacePressed = false;
                fadeIn = false;
                Debug.Log("Advisor Entered Scene (space)");
                AdvisorEnteredScene();
            }
            else
            {
                // Slowly fade in
                sprite.color = new Color(sprite.color.r + speed * Time.deltaTime, sprite.color.g + speed * Time.deltaTime, sprite.color.b + speed * Time.deltaTime, sprite.color.a + speed * Time.deltaTime);
                if (sprite.color.a >= 1 && sprite.color.r >= 1 && sprite.color.b >= 1 && sprite.color.g >= 1)
                {
                    fadeIn = false;
                    Debug.Log("Advisor Entered Scene");
                    AdvisorEnteredScene();
                }
            }
        }
        // If fading out check if space has been pressed
        else if (fadeOut)
        {
            //Debug.Log("Fade out is spacepressed?: " + spacePressed);
            if (spacePressed)
            {
                // Skip to faded out
                sprite.color = new Color(0, 0, 0, 0);
                spacePressed = false;
                fadeOut = false;
                Debug.Log("Advisor Left Scene (space)");
                AdvisorLeftScene();
            }
            else
            {
                // Slowly fade out
                sprite.color = new Color(sprite.color.r - speed * Time.deltaTime, sprite.color.b - speed * Time.deltaTime, sprite.color.g - speed * Time.deltaTime, sprite.color.a - speed * Time.deltaTime);
                if (sprite.color.a <= 0 && sprite.color.r <= 0 && sprite.color.b <= 0 && sprite.color.g <= 0)
                {
                    fadeOut = false;
                    Debug.Log("Advisor Left Scene");
                    AdvisorLeftScene();
                }
            }
        }
    }
}
