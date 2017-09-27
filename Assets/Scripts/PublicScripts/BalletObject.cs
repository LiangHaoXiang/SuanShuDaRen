using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalletObject : MonoBehaviour {

    Vector3 balletShootDir;
    bool IsShoot = false;

	void Update () {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            if (IsShoot)
            {
                // this.transform.LookAt(balletShootDir);
                this.transform.Translate(balletShootDir * Time.deltaTime);
            }

            if ((Mathf.Sqrt((this.transform.position.x * this.transform.position.x)
                + (this.transform.position.y * this.transform.position.y) +
                (this.transform.position.z * this.transform.position.z)) > 15.5f))
            {

                Destroy(this.gameObject);
            }
        }
    }

    public void setBalletShootDir(Vector3 balletShootDir)
    {
        this.balletShootDir = balletShootDir;
        IsShoot = true;
    }
}
