using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public void Update() 
	{
		if (Camera.main.transform.position.y == GameObject.Find("Frog").transform.position.y + 3 && Input.GetKeyDown(KeyCode.W) && GameObject.Find("Frog").GetComponent<PlayerSimpleMove>().playerAlive == true)
		// ^^ Checks if frog's position in relation to the camera justifies the camera moving forward, checks if player moves forward and checks if player is alive
		{
			Camera.main.transform.position = transform.position + new Vector3(0, 1, 0);			// moves camera if all above conditions are met which in turn follows the player's frog
		}
	}
}
