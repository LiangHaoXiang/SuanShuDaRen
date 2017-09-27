using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minimap : MonoBehaviour {

    public GameObject mainCamera;
    private Vector3 oldCameraRotation;
    private Vector3 nowCameraRotation;
    private Vector3 oldImageRotation;
    private Quaternion pos;
    private float  x,y,z;
    private Vector3 p;

    void Start () {
        oldCameraRotation.y = mainCamera.GetComponent<Transform>().localRotation.eulerAngles.y;
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            oldImageRotation.x = this.GetComponent<RectTransform>().localRotation.eulerAngles.x;
            oldImageRotation.y = this.GetComponent<RectTransform>().localRotation.eulerAngles.y;
            oldImageRotation.z = this.GetComponent<RectTransform>().localRotation.eulerAngles.z;

            nowCameraRotation.y = mainCamera.GetComponent<Transform>().localRotation.eulerAngles.y;

            x = oldImageRotation.x;
            z = oldImageRotation.z - (nowCameraRotation.y - oldCameraRotation.y);
            y = oldImageRotation.y;
            p = new Vector3(x, y, z);
            pos.eulerAngles = p;
            this.GetComponent<RectTransform>().localRotation = pos;

            oldCameraRotation.y = nowCameraRotation.y;

        }
        
        


    }
    

   

   
}
