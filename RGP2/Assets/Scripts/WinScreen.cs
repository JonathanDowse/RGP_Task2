using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public AudioClip bump, select, move;
    public AudioSource winMenuAudio;
    public Text titleText;
    public Text bodyText;
    public float fadeSpeed = 2;
    public UnityEngine.UI.Image menuCover;
    bool fadeComplete;
    public GameObject menuSelector;

    // Start is called before the first frame update
    void Start()
    {
        fadeComplete = false;
        titleText.canvasRenderer.SetAlpha(0);
        bodyText.canvasRenderer.SetAlpha(0);
        menuCover.canvasRenderer.SetAlpha(1);
        Invoke("TitleFade", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeComplete == true)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))                                        // if the player presses the "W" key...                                     
            {
                if (menuSelector.transform.position.y == -0.85f)                                  // if the gameobject's Y position equals -0.25...
                {
                    menuSelector.transform.position = new Vector3(0, -3.25f, 0);            // alter the gameobject's transform position to the button below
                    MoveSFX();
                }

                else if (menuSelector.transform.position.y == -3.25f)                             // otherwuse if Y position equals -1.75...
                {
                    BumpSFX();                                                      // call function
                }
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))                                        // if the player presses the "W" key...                              
            {
                if (menuSelector.transform.position.y == -3.25f)                                  // if the gameobject's Y position equals -3.25...
                {
                    menuSelector.transform.position = new Vector3(0, -0.85f, 0);            // alter the gameobject's transform position to the button above
                }

                else if (menuSelector.transform.position.y == -0.85f)                             // otherwise if Y position equals -1.75...
                {
                    BumpSFX();                                                      // call function
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))                                   // if player presses "Return" key...
            {
                if (menuSelector.transform.position.y == -3.25f)                                  // if gameobject's Y position equals -3.25...
                {
                    // call function..
                    SceneManager.LoadScene("Menu");                                 // end the whole application/close program
                }

                else if (menuSelector.transform.position.y == -0.85f)                             // if gameobject's Y position equals -1.75...
                {
                    // call function...
                    SceneManager.LoadScene("0");                              // load the project's "Options" scene
                }

            }
        }

    }
    void BumpSFX()                                                              // called function
    {
        winMenuAudio.Stop();                                                     // Stops audio component from playing...                                                                                   
        winMenuAudio.clip = bump;                                                // assigns "select" audio file to audiosource's "clip" component...                                                                                
        winMenuAudio.Play();                                                     // play assigned audiosource clip
    }

    void SelectSFX()                                                            // called function
    {
        winMenuAudio.Stop();                                                     // Stops audio component from playing...
        winMenuAudio.clip = select;                                              // assigns "select" audio file to audiosource's "clip" component...
        winMenuAudio.Play();                                                     // play assigned audiosource clip


    }

    void MoveSFX()
    {
        winMenuAudio.Stop();
        winMenuAudio.clip = move;
        winMenuAudio.Play();
    }

    void TitleFade()
    {
        titleText.CrossFadeAlpha(1.0f, fadeSpeed, false);
        Invoke("BodyTextFade", 2f);
    }

    void BodyTextFade()
    {
        bodyText.CrossFadeAlpha(1.0f, fadeSpeed, false);
        Invoke("MenuCoverFade", 2f);
    }

    void MenuCoverFade()
    {
        menuCover.CrossFadeAlpha(0.0f, fadeSpeed, false);
        fadeComplete = true;
    }
}

