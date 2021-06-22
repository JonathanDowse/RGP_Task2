using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 1f;

    private void FixedUpdate()
    {
        Vector3 spinner = transform.eulerAngles;
        spinner.z -= rotationSpeed;
        transform.eulerAngles = spinner;
    }
}
