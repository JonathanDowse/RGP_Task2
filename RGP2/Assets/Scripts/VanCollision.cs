using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanCollision : MonoBehaviour
{
    public Rigidbody2D vanParent;

    float force = 10000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Building")
        {
            Vector3 direction = other.contacts[0].point - other.gameObject.transform.position;

            direction = -direction.normalized;

            vanParent.velocity = -vanParent.velocity;

            vanParent.AddForce(direction * force);
        }
    }


}
