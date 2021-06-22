using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;
    private GameObject myArrow;

    // Start is called before the first frame update
    void Start()
    {
        myArrow = this.transform.Find("Arrow").gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        var dir = Target.position - transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Target == null)
        {
            Destroy(myArrow);
        }
       
    }
}