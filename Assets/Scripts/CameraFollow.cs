using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
	
    //Goals: Change so camera follows only if player reaches a certain point offscreen
	// Update is called once per frame
	void Update () {
        CameraMovement();
    }

    void CameraMovement()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
