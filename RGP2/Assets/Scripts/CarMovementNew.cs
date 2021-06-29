using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementNew : MonoBehaviour
{
    public float maxTorque;
    public float maxSteeringAngle;
    public GameObject wheelR;
    public GameObject wheelL;

    private void FixedUpdate()
    {
        float motor = maxTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
