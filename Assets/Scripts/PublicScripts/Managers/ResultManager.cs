using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

    public bool isGameOver = false;     //是否游戏结束

    public static ResultManager instance;

    public static ResultManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ResultManager)FindObjectOfType(typeof(ResultManager));
            }
            return instance;

        }

    }

    private void Awake()
    {
        instance = this;
    }

    public void YouAreRight()
    {
        //游戏关卡加一
        //该停止的停止，，停止射击，停止计时
        GameManager.instance.SomethingStop();
        //销毁所有的的气球和其他道具，重新初始化一个新的关卡
        Invoke("DelayYouAreRight", 1.5f);

        UIManager.Instance.ShowReadyTime("Right");
    }

    void DelayYouAreRight()
    {
        ObjectManager.Instance.DestoryBallon();
        Invoke("ResetTheViewEveryTest", 2.0f);
    }


    public void YouAreWrong()
    {
        //该停止的停止，，停止射击，停止计时
        GameManager.instance.SomethingStop();
        UIManager.Instance.ShowReadyTime("Wrong");

        Invoke("WrongToDelayDestoryAndReset", 1.5f);
    }

    void WrongToDelayDestoryAndReset()
    {
        ObjectManager.Instance.DestoryBallon();
        Invoke("ResetTheViewEveryTest", 2.0f);
    }


    /// <summary>
    /// 跳出通关提示框，
    /// </summary>
    public void GamePassed()
    {
        UIManager.Instance.PassLevelPanelShow();
        //并将当前通关分数记入总分中
        AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "GamePass");
        ScoreManager.Instance.totalScore += ScoreManager.Instance.currentLevelScore;
    }
    /// <summary>
    /// 游戏结束 ,一命通关，每一题目30秒，超过时间限制就gg
    /// </summary>
    public void GameOver()
    {
        UIManager.Instance.ShowReadyTime("GameOver");
        //该停止的停止，，停止射击，停止计时
        GameManager.instance.SomethingStop();
        //播放游戏结束音效
        AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "GameOver");
        //并将当前关卡分数记入总分中
        ScoreManager.Instance.totalScore += ScoreManager.Instance.currentLevelScore;
        //跳出游戏结束的提示框
        UIManager.Instance.GameOverPanelShow();

        isGameOver = true;
    }

    /// <summary>
    /// 每一题都重置
    /// </summary>
    public void ResetTheViewEveryTest()
    {
        ClearTheViewEveryTest();
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            //弹出这么关卡的用时情况，还有得分情况和按钮控制一下个关卡的进行
            if (InitGameManager.Instance.level < 7 && InitGameManager.Instance.id < 5)
            {
                InitGameManager.Instance.GameAgain(20, InitGameManager.Instance.level, 20.0f, LevelManager.Instance.isSmall, LevelManager.Instance.isRotate);
            }
            else if(InitGameManager.Instance.level == 7)
            {
                InitGameManager.Instance.GameAgain(20, InitGameManager.Instance.level, 20.0f, LevelManager.Instance.isSmall, LevelManager.Instance.isRotate);
            }
            else//否则若不是无尽模式且题目到达第五题即本关最后一题
            {
                GamePassed();
            }
            
        }
    }
    /// <summary>
    /// 每一题都清除，如果到本关最后一题结束后，顺便清除本关相关数据
    /// </summary>
    public void ClearTheViewEveryTest()
    {
        GameManager.instance.SomethingStop();
        AnswerManager.Instance.isOnGame = false;
        ObjectManager.Instance.DestoryBallon();
        UIManager.Instance.CleanTime();
        UIManager.Instance.CleanReadyTime();
        UIManager.Instance.CleanBalletCount();
        UIManager.Instance.CleanQuestionPanel();
        
        AnswerManager.Instance.ClearAnswerText();

    }

    /// <summary>
    /// 每一关都清除
    /// </summary>
    public void ClearTheViewEveryLevel()
    {
        ClearTheViewEveryTest();
        InitGameManager.Instance.ResetID();
        UIManager.Instance.CleanScoreText();   //清除文本分数
        ScoreManager.Instance.ResetCurrentLevelScore(); //重置当前关卡分数
        AnswerManager.Instance.ClearScoreNumber();  //清除计分
        TimeManager.Instance.ResetCurrentLevelTime();   //重置当前关卡时间
    }



    public void CancelInvokeInitGame()
    {
        CancelInvoke();
    }
}
