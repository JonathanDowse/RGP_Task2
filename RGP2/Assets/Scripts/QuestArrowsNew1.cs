using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArrowsNew1 : MonoBehaviour
{
    private Vector3 targetPosition;
    private RectTransform arrowRectTrans;
    public GameObject target;

    public List<GameObject> dogs;


    private void Awake()
    {
        arrowRectTrans = transform.Find("Pointer").GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPosition = target.transform.position;
        Vector3 fromPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        fromPosition.z = 0f;
        toPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = (Mathf.Atan2(toPosition.y - fromPosition.y, toPosition.x - fromPosition.x) * Mathf.Rad2Deg) % 360;
        arrowRectTrans.localEulerAngles = new Vector3(0, 0, angle);
    }
}
