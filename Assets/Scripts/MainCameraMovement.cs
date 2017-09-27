using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour {
    float a;
    float b;

	void Start () {
		
	}
	
	void Update () {
        a = Input.GetAxis("Horizontal");
        b = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0, a * Time.deltaTime * 60, 0));
        transform.Rotate(new Vector3(-b * Time.deltaTime * 60, 0, 0));
	}
}
