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
    GameObject currentDestroyArrow;
    public GameObject snacksParent;
    //GameObject closestArrow;
    //private float oldDistance = 9999;
    public GameObject winBackdrop;
    public GameObject winScreen;
    public UnityEngine.UI.Image winBackdropImage;
    public List<AudioSource> songSource;
    public List<GameObject> dogIcons;
    public GameObject arrowParent;


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

        if (dogsSaved > 0)
        {
            if (dogsSaved == 1 )
            {
                dogIcons[0].SetActive(true);
            }

            if (dogsSaved == 2)
            {
                dogIcons[1].SetActive(true);
            }

            if (dogsSaved == 3)
            {
                dogIcons[2].SetActive(true);
            }

            if (dogsSaved == 4)
            {
                dogIcons[3].SetActive(true);
            }

            if (dogsSaved == 5)
            {
                dogIcons[4].SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inVet == true && carryingDog == true)
            {
                dogsSaved = dogsSaved + 1;
                dropOffText.text = "Good Job";
                dogCounter.text = dogsSaved.ToString("0") + "/5";
                vetArrow.SetActive(false);
                arrowParent.SetActive(true);
                
                //for (int i = 0; i < dogArrows.Length; i++)
                //{
                //    dogArrows[i].SetActive(true);
               // }

                //foreach(GameObject data in dogArrows)
                //{
                //    data.SetActive(true);
                //}

                DroppedOff();
            }

            if (nearDog == true && currentDestroyTarget.tag == "Dog")
            {
                currentDestroyArrow = currentDestroyTarget.GetComponent<DogController>().myArrow;
                Destroy(currentDestroyArrow);
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
            winBackdrop.GetComponent<UnityEngine.UI.Image>().color = Color.white;
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
        arrowParent.SetActive(false);
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
                other.gameObject.GetComponent<DogController>().FillIdentity();
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
            other.gameObject.GetComponent<DogController>().ClearIdentity();
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
