using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject[] dogArrows;
    int dogsCarried;
    int dogsSaved;
    public Text dogCounter;
    public Text dropOffText;
    public Text vetText;
    public GameObject pauseScreen;
    public AudioSource pauseSound;
    private bool carryingDog;
    public GameObject vetArrow;
    bool inVet;
    bool nearDog;
    


    // Start is called before the first frame update
    void Start()
    {
        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }

        carryingDog = false;
        dogsSaved = 0;
        dogsCarried = 0;
        vetArrow.SetActive(false);
        inVet = false;
        nearDog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseTask();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inVet == true)
            {

            }

        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vet")
        {
            inVet = true;
            
            //EnterVet();
        }

        if (other.gameObject.tag == "Dog")
        {
            if (carryingDog == false)
            {
                vetText.text = "Press space to pick me up";
                if (Input.GetKeyDown(KeyCode.Space) && other.gameObject.tag == "Dog")
                {
                    Destroy(other.gameObject);
                    HasDog();
                }
            }

            else if (carryingDog == true)
            {
                vetText.text = "Please take your current pooch passenger to the vet before you collect me";
            }
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && other.gameObject.tag == "Dog")
        {
            Destroy(other.gameObject);
            HasDog();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vet")
        {
            vetText.text = " ";
            dropOffText.text = " ";
            inVet = false;
        }

        if (other.gameObject.tag == "Dog")
        {
            vetText.text = " ";
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
        if (carryingDog == true)
        {
            vetText.text = "Please press space to drop off the dog";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                dogsSaved = dogsSaved + 1;
                dropOffText.text = "Good Job";
                dogCounter.text = dogsSaved.ToString("0") +"/8";
                vetArrow.SetActive(false);
                for (int i = 0; i < dogArrows.Length; i++)
                {
                    dogArrows[i].SetActive(true);
                }
            }
        }

        else if (carryingDog == false)
        {
            vetText.text = "Please return with a stray dog in need";
        }
    }

    void LeaveVet()
    {

    }

    void EnterDog()
    {
       
    }

    void HasDog()
    {
        carryingDog = true;
        vetArrow.SetActive(true);
        dogsCarried = dogsCarried + 1;
        for (int i = 0; i < dogArrows.Length; i++)
        {
            dogArrows[i].SetActive(false);
        }
    }


    void ArrowOrganise()
    {

    }

}
