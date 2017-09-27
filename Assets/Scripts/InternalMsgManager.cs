using UnityEngine;
using System.Collections;
using core.Bluetooth;

public class InternalMsgManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GetBleStatus(string status)
    {
        Debug.Log(status);
    }

	void GetBleReply(string msg) {
		Debug.Log (msg);
    }

	void GetBleData(string data) {
		Debug.Log (data);
	}

	void serial_message(string msg) {
		Debug.Log (msg);
	}
}
