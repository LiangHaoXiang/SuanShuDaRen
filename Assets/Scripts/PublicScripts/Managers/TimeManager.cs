using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float totalTime = 0; //游戏总时间

    public float currentLevelTime = 0;  //当前关卡用时

    private float gameTime = 20.0f;
    private float maxGameTime;  //每题最大时间
    private bool IsBegin = false;

    public static TimeManager instance;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (TimeManager)FindObjectOfType(typeof(TimeManager));
            }
            return instance;

        }
 
    }

    private void Awake()
    {
        instance = this;
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            if (gameTime > 0 && IsBegin)
            {
                gameTime -= Time.deltaTime;
                totalTime += Time.deltaTime;
                currentLevelTime += Time.deltaTime;
                UIManager.Instance.ShowTime(gameTime);
                UIManager.Instance.ShowTimeSlider(gameTime);
            }

            if (gameTime <= 0 && ResultManager.Instance.isGameOver == false)
            {
                ResultManager.Instance.GameOver();
            }
        }

	}
    /// <summary>
    /// 重置时间值，给最大值
    /// </summary>
    /// <param name="maxTime"></param>
    /// <returns></returns>
    public IEnumerator ResetTime(float maxTime)
    {
        yield return null;
        this.gameTime = maxTime;    

        if (UIManager.Instance.timeSlider != null)
        {
            Transform sliderFillArea = UIManager.Instance.timeSlider.transform.GetChild(0).FindChild("Fill Area").GetChild(0);
            UIManager.Instance.timeSlider.maxValue = maxTime;
            UIManager.Instance.timeSlider.value = maxTime;
        }

    }

    public void setIsBegin(bool isBegin)
    {
        this.IsBegin = isBegin;
    }

    public float GetTime()
    {
        return gameTime;
    }

    public void SetTime(float time)
    {
        if (time >= maxGameTime)
        {
            time = maxGameTime;
        }
        gameTime = time;
    }

    public void SetMaxGameTime(float time)
    {
        maxGameTime = time;
    }

    public float GetMaxTime()
    {
        return maxGameTime;
    }

    public IEnumerator DelaySetBegin(float maxGameTime)
    {
        SetMaxGameTime(maxGameTime);
        yield return ResetTime(maxGameTime);
        yield return new WaitForSeconds(2.0f);
        setIsBegin(true);
        yield return new WaitForSeconds(0.1f);
        ResultManager.Instance.isGameOver = false;
    }
    /// <summary>
    /// 重置当前关卡时间
    /// </summary>
    public void ResetCurrentLevelTime()
    {
        currentLevelTime = 0;
    }
    /// <summary>
    /// 重置总时间
    /// </summary>
    public void ResetTotalTime()
    {
        totalTime = 0;
    }
}
