using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isBeginTheGameByNewLevel = true;

    public float levelGameTime = 0; //不同等级关卡的时间
    public bool isSmall = false;    //不同等级关卡的气球是否缩小
    public bool isRotate = false;   //不同等级关卡的气球是否旋转

    public static LevelManager instance;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (LevelManager)FindObjectOfType(typeof(LevelManager));
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
            if (isBeginTheGameByNewLevel)
            {
                StartCoroutine(StartGameByLevel(InitGameManager.Instance.level));
                isBeginTheGameByNewLevel = false;
            }
        }

    }

    public void LevelChange(float levelTime, int luckyBalloonNum, int damBoardNum)
    {

    }

    /// <summary>
    /// 根据不同等级关卡做出不同的反应
    /// </summary>
    /// <param name="level"></param>
    /// <param name="levelGameTime">不同等级关卡的时间</param>
    /// <param name="isRotate">不同等级关卡的气球是否旋转</param>
    /// <returns></returns>
    public IEnumerator StartGameByLevel(int level)
    {
        switch (level)
        {
            case 1:
                UIManager.Instance.TipsByLevel();
                isSmall = false;
                isRotate = false;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 20.0f, isSmall, isRotate);
                break;
            case 2:
                UIManager.Instance.TipsByLevel();
                isSmall = false;
                isRotate = false;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 20.0f, isSmall, isRotate);
                break;
            case 3:
                UIManager.Instance.TipsByLevel();
                isSmall = true;
                isRotate = false;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 25.0f, isSmall, isRotate);
                break;
            case 4:
                UIManager.Instance.TipsByLevel();
                isSmall = true;
                isRotate = false;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 20.0f, isSmall, isRotate);
                break;
            case 5:
                UIManager.Instance.TipsByLevel();
                isSmall = false;
                isRotate = true;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 25.0f, isSmall, isRotate);
                break;
            case 6:
                UIManager.Instance.TipsByLevel();
                isSmall = false;
                isRotate = true;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 20.0f, isSmall, isRotate);
                break;
            case 7:
                UIManager.Instance.TipsByLevel();
                isSmall = true;
                isRotate = true;
                yield return new WaitForSeconds(0.1f);
                InitGameManager.Instance.GameAgain(20, level, 20.0f, isSmall, isRotate);
                break;
            default:
                break;
        }

    }

}