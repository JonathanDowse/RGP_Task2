using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    GameObject currentDestroyTarget;
    public GameObject snacksParent;
    //GameObject closestArrow;
    //private float oldDistance = 9999;
    public GameObject lossDogCountText;
    public GameObject winBackdrop;
    public GameObject winScreen;


    // Start is called before the first frame update
    void Start()
    {
        if (pauseScreen != null)
        {
            pauseScreen.SetActive(false);
        }
        winScreen.SetActive(false);
        carryingDog = false;
        dogsSaved = 0;
        dogsCarried = 0;
        vetArrow.SetActive(false);
        inVet = false;
        nearDog = false;
        snacksParent.SetActive(false);
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
            if (inVet == true && carryingDog == true)
            {
                dogsSaved = dogsSaved + 1;
                dropOffText.text = "Good Job";
                dogCounter.text = dogsSaved.ToString("0") + "/5";
                vetArrow.SetActive(false);
                //for (int i = 0; i < dogArrows.Length; i++)
                //{
                //    dogArrows[i].SetActive(true);
               // }

                foreach(GameObject data in dogArrows)
                {
                    data.SetActive(true);
                }

                DroppedOff();
            }

            if (nearDog == true && currentDestroyTarget.tag == "Dog")
            {
                Destroy(currentDestroyTarget);
                currentDestroyTarget = null;
                HasDog();
            }

        }

        if (carryingDog == true)
        {
            snacksParent.SetActive(true);
        }

        if (dogsSaved == 5)
        {
            winScreen.SetActive(true);
            winBackdrop.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Invoke("LoadWinScreen", 2f);
        }
    }



    void DroppedOff()
    {
        carryingDog = false;
        nearDog = false;
        snacksParent.SetActive(false);
    }


    void HasDog()
    {
        nearDog = false;
        carryingDog = true;
        vetArrow.SetActive(true);
        dogsCarried = dogsCarried + 1;
        for (int i = 0; i < dogArrows.Length; i++)
        {
            dogArrows[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vet")
        {
            inVet = true;

            if (carryingDog == false)
            {
                vetText.text = "Please return with a stray dog in need";
            }

            else if (carryingDog == true)
            {
                vetText.text = "Please press space to drop off the dog";
            }

        }

        if (other.gameObject.tag == "Dog")
        {
            if (carryingDog == false)
            {
                currentDestroyTarget = other.gameObject;
                nearDog = true;
                vetText.text = "Press space to pick me up";
            }

            else if (carryingDog == true)
            {
                vetText.text = "Please take your current pooch passenger to the vet before you collect me";
            }
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
            nearDog = false;
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

    void LoadWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }    


}
