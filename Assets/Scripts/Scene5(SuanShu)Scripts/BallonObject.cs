using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallonObject : MonoBehaviour
{

    int id;
    string ballonNumber;
    bool isAnswer = true;
    bool IsBallonDestoryAudio = true;

    float rotation_Y;   //气球旋转角度

    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            if (ballonNumber == "?")
            {
                this.transform.parent.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                //this.transform.GetChild(3).GetComponent<MeshRenderer>().material.color = Color.green;
                //this.transform.GetChild(3).transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            Invoke("DelayPlayAnimation", (int)Random.Range(1, 4));
            this.transform.LookAt(GameObject.Find("MainController").transform);

        }

    }

    void Update()
    {
        rotation_Y = gameObject.transform.parent.localRotation.eulerAngles.y % 360;
        if (90 <= rotation_Y && rotation_Y <= 270)
        {
            gameObject.transform.FindChild("BallonNumber").gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.FindChild("BallonNumber").gameObject.SetActive(true);
        }
    }

    //为气球添加一个碰撞检测方法
    private void OnCollisionEnter(Collision collision)
    {
        
        //当碰撞到气球的物体是子弹时，直接销毁气球
        if (collision.gameObject.tag.CompareTo("Ballet") == 0 && ballonNumber != "?")
        {
            ObjectManager.instance.ballonObject.Remove(transform.parent.gameObject);
            Handheld.Vibrate(); //手机振动
            if (IsBallonDestoryAudio)
            {

                IsBallonDestoryAudio = false;
            }
            
            if (isAnswer)
            {
                AnswerManager.Instance.IsAnswerRight(ballonNumber);
                isAnswer = false;
            }
            transform.parent.GetComponent<BallonDestoryCon>().setIsBroken(true, false);
            GetComponent<SphereCollider>().enabled = false;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag.CompareTo("Ballet") == 0 && ballonNumber == "?")
        {
            ObjectManager.instance.ballonObject.Remove(transform.parent.gameObject);
            Handheld.Vibrate(); //手机振动

            this.GetComponent<SphereCollider>().enabled = false;
            this.transform.parent.GetComponent<BallonDestoryCon>().setIsBroken(true, true);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);

            //调用随机奖励的幸运气球
            BuffManager.Instance.LuckyBalloon();
        }
    }

    public void setBallonNumber(string ballonNumber)
    {
        transform.FindChild("BallonNumber").transform.GetComponent<TextMesh>().text = ballonNumber;

        this.ballonNumber = ballonNumber;
    }

    public void DelayPlayAnimation()
    {
        this.GetComponent<Animation>().Play("BallonIdea" + (int)Random.Range(1, 3));
    }
    

}

