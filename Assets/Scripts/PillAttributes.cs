using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillAttributes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector2(15, 0) * Time.deltaTime); //rotates pill
	}
}
