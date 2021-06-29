using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driving : MonoBehaviour
{
    public float turnSpeed = 10f;
    public float moveSpeed = 10f;

    private float leftRight = 0f;
    private float forward = 0f;
    public GameObject playerObj;

    bool gamePaused;
    public GameObject pauseScreen;

    public GameObject wheelR;
    public GameObject wheelL;

    private void Start()
    {
        gamePaused = false;
        pauseScreen.SetActive(false);
    }

    void ProcessInput()
    {
        leftRight = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");
    }

    private void Update()
    {
        ProcessInput();
        
        if (pauseScreen.activeInHierarchy == true)
        {
            gamePaused = true;
        }

        else if (pauseScreen.activeInHierarchy == false)
        {
            gamePaused = false;
        }


   
        

        if (Input.GetKey(KeyCode.Escape))
        {

        }

    }

    private void FixedUpdate()
    {
        if (gamePaused == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {

                playerObj.transform.Rotate(Vector3.up, leftRight * turnSpeed * Time.deltaTime/3);
                playerObj.transform.Translate(-forward * moveSpeed * Time.deltaTime, 0, 0);
            }


            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {

                playerObj.transform.Rotate(Vector3.up, -leftRight * turnSpeed * Time.deltaTime / 3);
                playerObj.transform.Translate(-forward * moveSpeed * Time.deltaTime / 4, 0, 0);
            }
        }
    }
}
