using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewestDriving : MonoBehaviour
{
    public Rigidbody playerRB;
    public float speed = 1f;
    bool carTurning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector3(0, 0, 290f * speed);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftApple) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            carTurning = true;
        }


        if (carTurning == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.rotation = Quaternion.Euler(0, 0, Input.GetAxis("Vertical"));

        }
    }
}
