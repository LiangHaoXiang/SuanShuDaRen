using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void LoadScenesEventHandler(string sceneName);     //声明委托
    public event LoadScenesEventHandler LoadScenesEvent;            //声明事件

    public float gameRecord = -10000.0f;   //最高记录

    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        LoadScenesEvent += new LoadScenesEventHandler(LoadScene);  //订阅事件
        LoadScenesEvent("Scene3(Main)");     //调用事件
    }

    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Load_Scene(sceneName, 4.2f)); //从场景1等待5s后加载到场景2
    }
    /// <summary>
    /// 加载新场景
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="time">等待时间</param>
    /// <returns></returns>
    IEnumerator Load_Scene(string sceneName,float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
    /// <summary>
    /// 有些东西需要停止就停止
    /// </summary>
    public void SomethingStop()
    {
        BalletManager.Instance.setIsFire(false);
        TimeManager.Instance.setIsBegin(false);
    }
    /// <summary>
    /// 比较记录，得出是否有新纪录产生
    /// </summary>
    public bool CompareRecord()
    {
        //若上次有记录，则给赋值，没有则说明是第一次进入游戏，gameRecord默认为-10000
        if (PlayerPrefs.HasKey("record"))
            gameRecord = GetRecord();
        float temp = PlayerPrefs.GetFloat("result");
        if (gameRecord < temp) //若刷新记录，则保存并返回true
        {
            gameRecord = temp;
            SaveRecord();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 保存记录
    /// </summary>
    public void SaveRecord()
    {
        PlayerPrefs.SetFloat("record", gameRecord);
        PlayerPrefs.Save();
    }
    /// <summary>
    /// 获取记录
    /// </summary>
    /// <returns></returns>
    public float GetRecord()
    {
        return PlayerPrefs.GetFloat("record");
    }
}
