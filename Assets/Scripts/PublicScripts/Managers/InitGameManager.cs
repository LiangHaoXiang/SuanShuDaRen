using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGameManager : MonoBehaviour {

    [HideInInspector]
    public int id = 0;      //题目ID
    [HideInInspector]
    public int num1;
    [HideInInspector]
    public int num2;
    [HideInInspector]
    public string operatorStr;
    [HideInInspector]
    public int level = 1; //关卡等级

    public static InitGameManager instance;
    public static InitGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (InitGameManager)FindObjectOfType(typeof(InitGameManager));
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 初始化游戏
    /// </summary>
    /// <param name="ballonNumber">气球固定数量</param>
    /// <param name="level">关卡等级</param>
    /// <param name="maxGameTime">不同等级关卡的时间</param>
    /// <param name="isSmall">不同等级关卡的气球是否缩小</param>
    /// <param name="isRotate">不同等级关卡的气球是否旋转</param>
    public void GameAgain(int ballonNumber, int level, float maxGameTime, bool isSmall, bool isRotate)
    {
        StartCoroutine(InitGameObject(ballonNumber, isSmall, isRotate));

        AnswerManager.Instance.isOnGame = true;
        ChooseQuestionStyle(level);
        StartCoroutine(InitUI(maxGameTime));
        //设置正确答案
        AnswerManager.Instance.SetAnswer(num1, num2, operatorStr);
    }



    /// <summary>
    /// //初始化游戏场景中的所有物体
    /// </summary>
    /// <param name="createBallonNumber"></param>
    IEnumerator InitGameObject(int createBallonNumber, bool isSmall, bool isRotate)
    {
        yield return ObjectManager.Instance.BeginCreate(createBallonNumber);
        yield return BalletManager.Instance.WaitFire();

        if (isSmall)
        {
            foreach (GameObject T in ObjectManager.instance.ballonObject)//气球变大
            {
                iTween.ScaleTo(T, iTween.Hash("scale", new Vector3(0.6f, 0.6f, 0.6f), "time", 1f));
            }
        }
        if (isRotate)
        {
            foreach (GameObject T in ObjectManager.instance.ballonObject)
            {
                iTween.RotateBy(T, iTween.Hash("y", 12, "time", 12f, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
            }
        }
    }
   
    IEnumerator InitUI(float maxGameTime)
    {
        //显示屏幕上面的等级，第几波
        UIManager.Instance.titleLevel.sprite = UIManager.Instance.sprites2[level];
        //出题面板
        StartCoroutine(QuestionManager.Instance.DelayShowQuestion(id, num1, num2, operatorStr));
        //预备时间
        BeginTimeManager.Instance.ResetReadyTime();
        yield return TimeManager.Instance.DelaySetBegin(maxGameTime);   //允许开始计时
        if (UIManager.Instance.timeShow != null)
            UIManager.Instance.timeShow.text = TimeManager.Instance.GetMaxTime().ToString();
    }
    /// <summary>
    /// 选择出题方式，题库or随机
    /// </summary>
    /// <param name="level"></param>
    void ChooseQuestionStyle(int level)
    {
        switch (level)
        {
            case 1:
                if (JsonManager.instance.AR_Calculate_Test1.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test1[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test1[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test1[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test1[0].operation;
                    JsonManager.instance.AR_Calculate_Test1.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 2:
                if (JsonManager.instance.AR_Calculate_Test2.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test2[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test2[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test2[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test2[0].operation;
                    JsonManager.instance.AR_Calculate_Test2.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 3:
                if (JsonManager.instance.AR_Calculate_Test3.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test3[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test3[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test3[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test3[0].operation;
                    JsonManager.instance.AR_Calculate_Test3.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 4:
                if (JsonManager.instance.AR_Calculate_Test4.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test4[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test4[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test4[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test4[0].operation;
                    JsonManager.instance.AR_Calculate_Test4.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 5:
                if (JsonManager.instance.AR_Calculate_Test5.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test5[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test5[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test5[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test5[0].operation;
                    JsonManager.instance.AR_Calculate_Test5.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 6:
                if (JsonManager.instance.AR_Calculate_Test6.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test6[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test6[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test6[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test6[0].operation;
                    JsonManager.instance.AR_Calculate_Test6.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
            case 7:
                if (JsonManager.instance.AR_Calculate_Test7.Count > 0)
                {
                    id = JsonManager.instance.AR_Calculate_Test7[0].ID;
                    num1 = JsonManager.instance.AR_Calculate_Test7[0].num1;
                    num2 = JsonManager.instance.AR_Calculate_Test7[0].num2;
                    operatorStr = JsonManager.instance.AR_Calculate_Test7[0].operation;
                    JsonManager.instance.AR_Calculate_Test7.RemoveAt(0);
                }
                else
                {
                    id++;
                    RandomManager.Instance.RandomQuestion();
                    num1 = RandomManager.Instance.GetNum1();
                    num2 = RandomManager.Instance.GetNum2();
                    operatorStr = RandomManager.Instance.GetOperatorStr();
                }
                break;
        }
    }

    public void ResetID()
    {
        id = 0;
    } 

} 
