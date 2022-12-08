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
    public bool blackToWhiteTransition = false;
    public bool whiteToBlackTransition = false;
    private bool spacePressed = false;
    float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void AdvisorEnterScene()
    {
        transform.localScale = new Vector3(46.0935f, 41.778f, 1);
        gameObject.SetActive(true);
        fadeIn = true;
        spacePressed = false;
    }

    private void AdvisorEnteredScene()
    {
        StartCoroutine(eventPlayer.StartInitialEventDescription());
    }

    public void AdvisorLeaveScene()
    {
        transform.localScale = new Vector3(-46.0935f, 41.778f, 1);
        fadeOut = true;
        spacePressed = false;
    }

    private void AdvisorLeftScene()
    {
        gameObject.SetActive(false);
        // End of scene
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spacePressed = true;
        }
        if (fadeIn)
        {
            //Debug.Log("Fading in");
            if (spacePressed)
            {
                sprite.color = new Color(1, 1, 1, 1);
                spacePressed = false;
                fadeIn = false;
                Debug.Log("Advisor Entered Scene (space)");
                AdvisorEnteredScene();
            }
            else
            {
                sprite.color = new Color(sprite.color.r + speed * Time.deltaTime, sprite.color.g + speed * Time.deltaTime, sprite.color.b + speed * Time.deltaTime, sprite.color.a + speed * Time.deltaTime);
                if (sprite.color.a >= 1 && sprite.color.r >= 1 && sprite.color.b >= 1 && sprite.color.g >= 1)
                {
                    fadeIn = false;
                    Debug.Log("Advisor Entered Scene");
                    AdvisorEnteredScene();
                }
            }
        }
        else if (fadeOut)
        {
            Debug.Log("fading out");
            if (spacePressed)
            {
                sprite.color = new Color(0, 0, 0, 0);
                spacePressed = false;
                fadeOut = false;
                Debug.Log("Advisor Left Scene (space)");
                AdvisorLeftScene();
            }
            else
            {

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
