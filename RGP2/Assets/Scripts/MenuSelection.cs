using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    public AudioClip bump, select, move;                                              // assigning public audioclips so they can have audio files assigned to them within unity                                                            
    public AudioSource menuAudioSource;                                            // creating an AudioSource variable called "audioSource"


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))                                        // if the player presses the "W" key...                                     
        {
            if (transform.position.y == 0.95f)                                  // if the gameobject's Y position equals -0.25...
            {
                transform.position = new Vector3(0, -0.95f, 0);            // alter the gameobject's transform position to the button below
                MoveSFX();
            }

            else if (transform.position.y == -0.95)                             // otherwuse if Y position equals -1.75...
            {
                BumpSFX();                                                      // call function
            }
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))                                        // if the player presses the "W" key...                              
        {
            if (transform.position.y == -0.95f)                                  // if the gameobject's Y position equals -3.25...
            {
                transform.position = new Vector3(0, 0.95f, 0);            // alter the gameobject's transform position to the button above
            }

            else if (transform.position.y == 0.95f)                             // otherwise if Y position equals -1.75...
            { 
                BumpSFX();                                                      // call function
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))                                   // if player presses "Return" key...
        {
            if (transform.position.y == -0.95f)                                  // if gameobject's Y position equals -3.25...
            {
                SelectSFX();                                                    // call function..
                Application.Quit();                                             // end the whole application/close program
            }

            else if (transform.position.y == 0.95f)                             // if gameobject's Y position equals -1.75...
            {
                SelectSFX();                                                    // call function...
                SceneManager.LoadScene("0");                              // load the project's "Options" scene
            }

        }
    }

    void BumpSFX()                                                              // called function
    {
        menuAudioSource.Stop();                                                     // Stops audio component from playing...                                                                                   
        menuAudioSource.clip = bump;                                                // assigns "select" audio file to audiosource's "clip" component...                                                                                
        menuAudioSource.Play();                                                     // play assigned audiosource clip
    }

    void SelectSFX()                                                            // called function
    {
        menuAudioSource.Stop();                                                     // Stops audio component from playing...
        menuAudioSource.clip = select;                                              // assigns "select" audio file to audiosource's "clip" component...
        menuAudioSource.Play();                                                     // play assigned audiosource clip

        for (int i = 0; i < 10; i++)                                            // for loop to create the slightest delay so player can hear the menu selection sound effect
        {

        }
    }

    void MoveSFX()
    {
        menuAudioSource.Stop();
        menuAudioSource.clip = move;
        menuAudioSource.Play();
    }

}
