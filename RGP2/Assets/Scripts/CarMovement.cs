using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject pauseScreen;
    bool gamePaused;
    public float acceleration;
    public float steering;
    public Rigidbody2D rb;
    public GameObject wheelL;
    public GameObject wheelR;
    public float maxSpeed = 60f;
    private Vector3 pausedVelocity;
    private float pausedAngularVelocity;

    void Start()
    {
        gamePaused = false;
        rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if (gamePaused == false)
        {
            float h = -Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 speed = transform.up * (v * acceleration);
            rb.AddForce(speed);

            float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
            if (direction >= 0.0f)
            {
                rb.rotation += h * steering * (rb.velocity.magnitude / 10.0f);
                //rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0f));
            }
            else
            {
                rb.rotation -= h * steering * (rb.velocity.magnitude / 10.0f);
                //rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
            }

            Vector2 forward = new Vector2(0.0f, 0.5f);
            float steeringRightAngle;
            if (rb.angularVelocity > 0)
            {
                steeringRightAngle = -90;
            }
            else
            {
                steeringRightAngle = 90;
            }

            Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
           // Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

            float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized)/4);

            Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


           // Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

            rb.AddForce(rb.GetRelativeVector(relativeForce));
        }

     
    }
}
