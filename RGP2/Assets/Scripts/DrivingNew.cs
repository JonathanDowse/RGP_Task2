using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingNew : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
   


    bool gamePaused;
    public GameObject pauseScreen;

    public GameObject wheelR;
    public GameObject wheelL;
    private void Start()
    {
        gamePaused = false;
        pauseScreen.SetActive(false);
    }



    private void Update()
    {

        if (gamePaused == false)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            { rb.AddForce(-transform.right * thrust); }

            if (Input.GetKey(KeyCode.S))
            { rb.AddForce(transform.right * thrust); }


            if (Input.GetKey(KeyCode.LeftShift))
                rb.AddForce(transform.forward * thrust * 2, ForceMode.Acceleration);


            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(0, -0.25f, 0 );
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(0, 0.25f, 0 );
                }




            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Rotate(0, -0.25f, 0);
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Rotate(0, 0.25f, 0 );
                }

            }

        }

        if (pauseScreen.activeInHierarchy == true)
        {
            gamePaused = true;
        }

        else if (pauseScreen.activeInHierarchy == false)
        {
            gamePaused = false;
        }

    }

    void FixedUpdate()
    {

    }
}