using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator1 : MonoBehaviour
{
    public Transform Target;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        var dir = Target.position - transform.position;
      
        var angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (dir.x > -0.65 && dir.x < 0.65 && dir.y > -0.65 && dir.y < 0.65 && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this.gameObject);
        }
       
    }
}
