using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Driving : MonoBehaviour
{
    private Rigidbody rb;
    public float hInput = 0.0f;
    public float vInput = 0.0f;

    public float speed = 1000;
    public float turnRate = 1000000000;

    Quaternion targetRotation;

    private Transform myTransform;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetRotation = Quaternion.identity;

        myTransform = transform;
    }


    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {
        Rotation(hInput, vInput);
        Movement(hInput, vInput);
    }

    void Rotation(float horizontal, float vertical)
    {
        float angle = Mathf.Atan2(hInput, vInput) * Mathf.Rad2Deg;
        float step = turnRate * Time.deltaTime;

        if (horizontal != 0 || vertical != 0)
        {
            targetRotation.eulerAngles = new Vector3(0, 0, angle);

            myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, targetRotation, step * 10);
        }
    }

    void Movement(float horizontal, float vertical)
    {
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            rb.AddForce(myTransform.forward * speed * Time.deltaTime);
        }
    }
}