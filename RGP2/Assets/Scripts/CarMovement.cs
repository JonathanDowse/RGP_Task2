using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject pauseScreen;
    bool gamePaused;
    public float acceleration;
    public float steering;
    public Rigidbody rb;
    public GameObject wheelL;
    public GameObject wheelR;
    public float maxSpeed = 60f;
    private Vector3 pausedVelocity;
    private float pausedAngularVelocity;
    private float rotationHolder;
    private Vector3 angleVelocity;


    void Start()
    {
        gamePaused = false;

    }

    private void Update()
    {
        if (pauseScreen.activeInHierarchy)
        {
            //pausedVelocity = rb.velocity;
            //pausedAngularVelocity = rb.angularVelocity;
            //rb.isKinematic = true;
            
            gamePaused = true;
        }
        else if (!pauseScreen.activeInHierarchy)
        {
            //rb.isKinematic = false;
            //rb.velocity = pausedVelocity;
            //rb.angularVelocity = pausedAngularVelocity;
            gamePaused = false;
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (gamePaused == false)
        {
            float h = -Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 speed = transform.up * (v * acceleration);
            rb.AddForce(speed);



            float direction = Vector3.Dot(rb.velocity, rb.transform.TransformPoint(Vector3.up));
            if (direction >= 0.0f)
            {
              //  rotationHolder = h * steering * (rb.velocity.magnitude / 10.0f);
              //  angleVelocity = new Vector3(0f, 0f, rotationHolder);
              //  Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
              //  rb.MoveRotation(rb.rotation * deltaRotation);
                //rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0));
            }
            else
            {
              //  rotationHolder = h * steering * (rb.velocity.magnitude / 10.0f);
              //  angleVelocity = new Vector3(0f, 0f, -rotationHolder);
              //  Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
              //  rb.MoveRotation(rb.rotation * deltaRotation);
                //rb.rotation -= h * steering * (rb.velocity.magnitude / 10.0f);
                //rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
            }

            Vector3 forward = new Vector3(0.0f, 0.5f, 0.0f);
            float steeringRightAngle;
            if (rb.angularVelocity.magnitude > 0)
            {
                steeringRightAngle = -90;
            }
            else
            {
                steeringRightAngle = 90;
            }

            Vector3 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
           // Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

            float driftForce = Vector3.Dot(rb.velocity, rb.transform.TransformPoint(rightAngleFromForward.normalized)/4);

            Vector3 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


           // Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

            rb.AddForce(rb.transform.TransformPoint(relativeForce));
        }

     
    }
}
