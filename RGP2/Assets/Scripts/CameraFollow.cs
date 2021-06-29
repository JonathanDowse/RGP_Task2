using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    private void Update()
    {
        this.transform.position = new Vector3(playerTransform.position.x, 130, playerTransform.position.z);
    }

}
