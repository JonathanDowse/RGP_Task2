using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject lossBackdrop;
    public GameObject pauseScreen;
    public GameObject lossScreen;
    public Text timerText;
    float timeLeft = 180f;
    private bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        lossScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == false && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
       

        UpdateTimer();

        //timerText.text = timeLeft + " Seconds Left!";
        if (timeLeft <= 0)
        {
            lossScreen.SetActive(true);
            lossBackdrop.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Invoke("LoadLossScreen", 2f);
        }

        if (!pauseScreen.activeInHierarchy)
        {
            gamePaused = false;
        }
        else if (pauseScreen.activeInHierarchy)
        {
            gamePaused = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Snack")
        {
            Destroy(other.gameObject);
            timeLeft = timeLeft + 10f;
        }
    
    }

    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.RoundToInt(timeLeft % 60f);

        string formattedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    void LoadLossScreen()
    {
        SceneManager.LoadScene("LossScreen");
    }
}

