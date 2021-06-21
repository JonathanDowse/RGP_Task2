using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;                                                                                        // ensuring that it uses the unity version of vector 3 rather than the system version
using Vector2 = UnityEngine.Vector2;                                                                                        // ensuring that it uses the unity version of vector 3 rather than the system version

public class PlayerSimpleMove : MonoBehaviour
{

    public Sprite drowned, drowned2, hit;                                                                                   // declaring public sprites that can have images assigned to them within unity 
    public Sprite upRed, downRed, leftRed, rightRed;                                                                        // declaring public sprites that can have images assigned to them within unity 
    public Sprite upPurple, downPurple, leftPurple, rightPurple;                                                            // declaring public sprites that can have images assigned to them within unity 
    public Sprite upEvil, downEvil, leftEvil, rightEvil;                                                                    // declaring public sprites that can have images assigned to them within unity 
    public Sprite upGreen, downGreen, leftGreen, rightGreen;                                                                // declaring public sprites that can have images assigned to them within unity 
    public Sprite upWhite, downWhite, leftWhite, rightWhite;                                                                // declaring public sprites that can have images assigned to them within unity 
    public Sprite upOrange, downOrange, leftOrange, rightOrange;                                                            // declaring public sprites that can have images assigned to them within unity 
    public AudioClip hop, roadKill, drown;                                                                                  // declaring public audio clip variables to assign audio files to within unity
    private AudioSource audioSource;                                                                                        // creating an AudioSource variable called "audioSource"
    public bool playerAlive = true;                                                                                         // declaring a public bool valled "playerAlive" with a true value
    public float camBase;                                                                                                   // declaring a float with an empty value for the bottom of the screen based on the camera view (done later)
    public bool onLog = false;                                                                                              // declaring public bool "onLog" for conditions that will be later assigned
    public bool inWater = false;                                                                                            // declaring public bool "inWater" for conditions that will be later assigned
    public float logDir = 0f;                                                                                               // declaring a public float called "logDir" which will later be used for moving the player on logs
    public string frogColour;                                                                                               // declaring an empty string called "frogColour" which will be used later
    public LayerMask layermask;                                                                                             // declaring a public layermask called "layermask" to assign physics layers to raycasts

    void Start()
    {
        PlayerPrefs.SetInt("dead", 0);                                                                                      // setting the playerprefs "dead" to a value of 0
        frogColour = PlayerPrefs.GetString("colour");                                                                       // assigning the value of playerprefs "colour" to the string frogColour
        audioSource = GetComponent<AudioSource>();                                                                          // assigning the "audioSource" variable to the attached Audio Source component
        UpSprite();                                                                                                         // calling function
    }

    void Update()
    {
        if(playerAlive)                                                                                                     // if playerAlive bool is true...
        {
            camBase = Camera.main.transform.position.y - 5.5f;                                                              // assigning float "camBase" to the value of the bottom of the visible scene (done with equation) 

            if (Input.GetKeyDown(KeyCode.W) && playerAlive == true)                                                         // if player presses the "W" key and "playerAlive" equals true...
            {
                transform.position = transform.position + new Vector3(0, 1, 0);                                             // alter the gameobject's transform position to the next positive unit on the Y axis...
                UpSprite();                                                                                                 // calling function...                                                     
                PlayJumpSound();                                                                                            // calling function
            }

            else if (Input.GetKeyDown(KeyCode.S) && transform.position.y >= camBase + 1.0f && playerAlive == true)          // otherwise if player presses the "S" key and gameobject's Y position is greater than bottom of screen and "playerAlive" is true...
            {
                transform.position = transform.position + new Vector3(0, -1, 0);                                            // alter the gameobject's transform position to the next negative unit on the Y axis...
                DownSprite();                                                                                               // calling function...
                PlayJumpSound();                                                                                            // calling function
            }

            else if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -7 && playerAlive == true)                       // otherwise if player presses the "A" key and gameobject's X position is greater than the left side of screen and "playerAlive" is true...                     
            {
                transform.position = transform.position + new Vector3(-1, 0, 0);                                            // alter the gameobject's transform position to the next negative unit on the X axis...
                LeftSprite();                                                                                               // calling function...                                     
                PlayJumpSound();                                                                                            // calling function
            }

            else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 7 && playerAlive == true)                        // otherwise if player presses the "D" key and gameobject's X position is lesser than the right side of screen and "playerAlive" is true...             
            {
                transform.position = transform.position + new Vector3(1, 0, 0);                                             // alter the gameobject's transform position to the next positive unit on the X axis...
                RightSprite();                                                                                              // calling function...
                PlayJumpSound();                                                                                            // calling function
            }

            if (transform.position.x >= 8.1 || transform.position.x <= -8.1)                                                // if player gameobject's X position is greater than the right side of the screen or less than the left side of the screen...
            {
                playerAlive = false;                                                                                        // "playerAlive" is false, killing the player
            }
        }

        if (playerAlive == false)                                                                                           // if "playerAlive" equals false...
        {
            PlayerPrefs.SetInt("dead", 1);                                                                                  // set playerprefs "dead" to 1 so the death screen sprite becomes visible
        }

        if (Input.GetKeyDown(KeyCode.R) && playerAlive == false)                                                            // if "playerAlive" is false and the player presses the "R" key...                                           
        {
            PlayerPrefs.SetInt("dead", 0);                                                                                  // set playerprefs "dead" to 0 to ensure the death screen goes away again...
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);                                                     // restarts the current scene, restarting the game's loop                                               
        }

        if (Input.GetKeyDown(KeyCode.Escape))                                                                               // if player presses the "Escape" key at any time...
        {
            SceneManager.LoadScene("Menu");                                                                                 // load this project's "Menu" scene
        }
    }
                                                                                                                            // --------------- start section coded by Trent Naylor
    public void FixedUpdate()
    {
        if(playerAlive)                                                                                                     // if "playerAlive" is true...
        {
            transform.Translate(Vector2.right * Time.deltaTime * logDir, Space.World);                                      // move the frog's gameobject left or right depending on the output of this equation

                                                                                                                            //Lets do a raycast here after we have moved, after the logs have moved etc
                                                                                                                            //This should be the safest time to do a pinpoint collision detection under us.
                                                                                                                            //we will get an array of coliders and make a decision based on the content of the array.

                                                                                                                            // Cast a ray and collect all the colliders we hit
                                                                                                                            //Make sure our layer mask ignores the player
            Ray2D myRay = new Ray2D(transform.position + new Vector3(0f, 0.5f, 0f), -Vector2.up);
            var hit = Physics2D.RaycastAll(myRay.origin, myRay.direction, 0.1f, layermask);

            Debug.DrawRay(transform.position + new Vector3(0f, 0.5f, 0f), -Vector2.up * 0.1f);
            if (hit.Length > 0)
            {
                onLog = false;                                                                                              //reset this so its a clean test below.
                inWater = false;                                                                                            //reset as well

                foreach (RaycastHit2D h in hit)                                                                             //bunch of colliders in here, just do some tag testing now.
                {
                    if (h.transform.tag == "LogR" || h.transform.tag == "LogL")
                    {
                        if (h.transform.tag == "LogR")
                            logDir = -2f;
                        else logDir = 2f;

                        onLog = true;
                    }
                    if (h.transform.tag == "Drown")
                    {
                        inWater = true;
                    }
                    if(h.transform.tag == "Safe")                                                                           //Grass/Roads etc must be tagged this to reset everything instead of OnTrigger Exit
                    {
                        logDir = 0;
                        onLog = false;
                        inWater = false;
                    }
                }
            }
            if(onLog)                                                                                                       //Assune we are safe here
            {
                inWater = false;
            }
            if (!onLog && inWater)                                                                                          //Not on log but in water, player is killed
            {
                PlayerDrowned();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(playerAlive)
        {
            if (collision.tag == "Mobile" )                                                                                 // if player collides with any gameobjects with the "Mobile" tag and player isnt declared dead yet
            {
                PlayerRoadKill();
                playerAlive = false;
            }
        }
    }
                                                                                                                            // --------------- end section coded by Trent Naylor
    void PlayerDrowned()                                                                                                    // called function...
    {
        print("Died in water");
        playerAlive = false;
        tag = "Dead";                                                                                                       // changes player's gameobject tag to "Dead"...
        GetComponent<SpriteRenderer>().sortingOrder = 3;                                                                    // makes sure frog sprites are above water but under the logs...
        DrownFrame0();                                                                                                      // calling function...
        audioSource.Stop();                                                                                                 // Stops audio component from playing...
        audioSource.clip = drown;                                                                                           // assigns new "drown" audio file to component...
        audioSource.Play();                                                                                                 // plays component file
    }

    private void PlayerRoadKill()                                                                                           // called function...
    {
        print("Died by car");
        playerAlive = false;
        tag = "Dead";
        GetComponent<SpriteRenderer>().sortingOrder = 3;                                                                    // makes sure frog sprites are above the road but under the cars...   
        this.GetComponent<SpriteRenderer>().sprite = hit;                                                                   // changes the active sprite on the gameobject to the "hit" sprite...
        PlayRoadKillSound();                                                                                                // calling function
    }

    void PlayJumpSound()                                                                                                    // called function...
    {
        audioSource.Stop();                                                                                                 // Stops audio component from playing...
        audioSource.clip = hop;                                                                                             // assigns new "hop" audio file to component...
        audioSource.Play();                                                                                                 // plays component file
    }

    void PlayRoadKillSound()                                                                                                // called function...
    {
        audioSource.Stop();                                                                                                 // Stops audio component from playing...
        audioSource.clip = roadKill;                                                                                        // assigns new "roadKill" audio file to component...
        audioSource.Play();                                                                                                 // plays component file
    }

    void DrownFrame0()                                                                                                      // called function...
    {
        this.GetComponent<SpriteRenderer>().sprite = drowned;                                                               // assigning assigned sprite variable to gameobject's active sprite...
        Invoke("DrownFrame1", 0.4f);                                                                                        // calling function after a short delay
    }

    void DrownFrame1()                                                                                                      // called function...
    {
        this.GetComponent<SpriteRenderer>().sprite = drowned2;                                                              // assigning assigned sprite variable to gameobject's active sprite...     
        Invoke("DrownFrame0", 0.4f);                                                                                        // calling function after a short delay
    }

    void UpSprite()                                                                                                         // called function...
    {
        if(frogColour == "purple")                                                                                          // this function simply assigns the active sprite to whichever value the variable "frogColour" gets from the "colour" playerprefs...
        {                                                                                                                   // this function only accomodates for the "up" directional sprites
            GetComponent<SpriteRenderer>().sprite = upPurple;
        }

        if (frogColour == "red")
        {
            GetComponent<SpriteRenderer>().sprite = upRed;
        }

        if (frogColour == "white")
        {
            GetComponent<SpriteRenderer>().sprite = upWhite;
        }

        if (frogColour == "orange")
        {
            GetComponent<SpriteRenderer>().sprite = upOrange;
        }

        if (frogColour == "green")
        {
            GetComponent<SpriteRenderer>().sprite = upGreen;
        }

        if (frogColour == "evil")
        {
            GetComponent<SpriteRenderer>().sprite = upEvil;
        }
    }

    void DownSprite()                                                                                                       // called function...
    {
        if (frogColour == "purple")                                                                                         // this function simply assigns the active sprite to whichever value the variable "frogColour" gets from the "colour" playerprefs...
        {                                                                                                                   // this function only accomodates for the "down" directional sprites
            GetComponent<SpriteRenderer>().sprite = downPurple;
        }

        if (frogColour == "red")
        {
            GetComponent<SpriteRenderer>().sprite = downRed;
        }

        if (frogColour == "white")
        {
            GetComponent<SpriteRenderer>().sprite = downWhite;
        }

        if (frogColour == "orange")
        {
            GetComponent<SpriteRenderer>().sprite = downOrange;
        }

        if (frogColour == "green")
        {
            GetComponent<SpriteRenderer>().sprite = downGreen;
        }

        if (frogColour == "evil")
        {
            GetComponent<SpriteRenderer>().sprite = downEvil;
        }
    }

    void LeftSprite()                                                                                                       // called function...
    {
        if (frogColour == "purple")                                                                                         // this function simply assigns the active sprite to whichever value the variable "frogColour" gets from the "colour" playerprefs...
        {                                                                                                                   // this function only accomodates for the "left" directional sprites
            GetComponent<SpriteRenderer>().sprite = leftPurple;
        }

        if (frogColour == "red")
        {
            GetComponent<SpriteRenderer>().sprite = leftRed;
        }

        if (frogColour == "white")
        {
            GetComponent<SpriteRenderer>().sprite = leftWhite;
        }

        if (frogColour == "orange")
        {
            GetComponent<SpriteRenderer>().sprite = leftOrange;
        }

        if (frogColour == "green")
        {
            GetComponent<SpriteRenderer>().sprite = leftGreen;
        }

        if (frogColour == "evil")
        {
            GetComponent<SpriteRenderer>().sprite = leftEvil;
        }
    }

    void RightSprite()                                                                                                      // called function...
    {
        if (frogColour == "purple")                                                                                         // this function simply assigns the active sprite to whichever value the variable "frogColour" gets from the "colour" playerprefs...
        {                                                                                                                   // this function only accomodates for the "left" directional sprites
            GetComponent<SpriteRenderer>().sprite = rightPurple;    
        }

        if (frogColour == "red")
        {
            GetComponent<SpriteRenderer>().sprite = rightRed;
        }

        if (frogColour == "white")
        {
            GetComponent<SpriteRenderer>().sprite = rightWhite;
        }

        if (frogColour == "orange")
        {
            GetComponent<SpriteRenderer>().sprite = rightOrange;
        }

        if (frogColour == "green")
        {
            GetComponent<SpriteRenderer>().sprite = rightGreen;
        }

        if (frogColour == "evil")
        {
            GetComponent<SpriteRenderer>().sprite = rightEvil;
        }
    }
}
