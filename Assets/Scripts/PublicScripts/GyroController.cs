using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour {

	void Start () {
        SensorHelper.ActivateRotation();
	}
	
	void Update () {
        this.transform.rotation = SensorHelper.rotation;
	}
}
