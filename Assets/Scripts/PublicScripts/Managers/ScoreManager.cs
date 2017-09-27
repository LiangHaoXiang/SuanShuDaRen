using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

    public int totalScore = 0;  //总分

    public int currentLevelScore = 0;   

    public static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
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
            if (UIManager.Instance.scoreText != null)
                UIManager.Instance.ShowScoreText(currentLevelScore);
        }
    }

    public void SetScore(int scoreNumber)
    {
        currentLevelScore = scoreNumber;
    }

    public int GetScore()
    {
        return currentLevelScore;
    }
    /// <summary>
    /// 重置当前关卡分数
    /// </summary>
    public void ResetCurrentLevelScore()
    {
        currentLevelScore = 0;
    }

    /// <summary>
    /// 重置总分数
    /// </summary>
    public void ResetTotalScore()
    {
        totalScore = 0;
    }

    public void SetsScoreInPlayerPrefs(int core)
    {
        PlayerPrefs.SetInt("Score", core);
    }

    public int GetsScoreInPlayerPrefs()
    {
        return PlayerPrefs.GetInt("Score");
    }

}
