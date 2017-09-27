using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginTimeManager : MonoBehaviour
{
    float readyTime;
    bool isBegin = false;
    bool isReadyGo = false;
    public static BeginTimeManager instance;

    public static BeginTimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BeginTimeManager)FindObjectOfType(typeof(BeginTimeManager));
            }
            return instance;

        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            if (isBegin)
            {
                readyTime -= Time.deltaTime;
                if (isReadyGo)
                {
                    AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "ReadyGo");
                    UIManager.Instance.ShowReadyTime("Ready");

                    isReadyGo = false;
                }

                if (0f < readyTime && readyTime < 1f)
                {
                    UIManager.Instance.ShowReadyTime("GO!!!");
                }
                else if (readyTime < 0f)
                {
                    UIManager.Instance.CleanReadyTime();
                    isBegin = false;
                }
            }
        }
    }
    

    public void ResetReadyTime()
    {
        this.readyTime = 2f;
        isBegin = true;
        isReadyGo = true;
    }
}
