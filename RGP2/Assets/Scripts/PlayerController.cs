using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
     
    public GameObject pauseScreen;
    public AudioSource pauseSound;

    // Start is called before the first frame update
    void Start()
    {
        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseTask();

        }
    }

    private void FixedUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vet")
        {
            EnterVet();
        }

        if (other.gameObject.tag == "Dog")
        {
            EnterDog();
        }



    }

    void PauseTask()
    {
        if (!pauseScreen.activeInHierarchy)
        {
            pauseSound.Play();
            pauseScreen.SetActive(true);
        }
        else
        {
            pauseSound.Play();
            pauseScreen.SetActive(false);
        }
    }


    void EnterVet()
    {

    }

    void LeaveVet()
    {

    }

    void EnterDog()
    {

    }

    void HasDog()
    {

    }

}
