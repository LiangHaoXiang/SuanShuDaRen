using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerManager : MonoBehaviour {


    //这个类为判断答案是正确的，正确之后，停止时间的计时，并且重新进行一下一个关卡

    //public char[] answer = new char[] { '6', 'c' };
    public int answer = -1;
    //public int count = 0;
    public int scoreNumber = 0;
    public bool isOnGame;   //在场景5的游戏状态

    StringBuilder answerText = new StringBuilder();

    public static AnswerManager instance;

    public static AnswerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (AnswerManager)FindObjectOfType(typeof(AnswerManager));
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
        //if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        //{
        //    if (isOnGame)
        //    {
        //        if (answer[count] == 'c')
        //        {
        //            ResultManager.Instance.YouAreRight();
        //            AudioSourceManager.Instance.Play(GameObject.Find("GetScoureAudio").gameObject, "Unbelieve");
        //            count = 0;
        //            isOnGame = false;
        //        }
        //    }
        //}

    }

    public void IsAnswerRight(string number)
    {
        if (isOnGame)
        {
            //if ((answer[count] == number.ToCharArray()[0]) )
            if ((answer == int.Parse(number)))
            {
                if (20f <= TimeManager.Instance.GetTime() && TimeManager.Instance.GetTime() < 30f)
                {
                    //if (answer[count + 1] == 'c')
                    //{
                    scoreNumber += 12;

                    ScoreManager.Instance.SetScore(scoreNumber);
                    //}
                }
                else if (5f <= TimeManager.Instance.GetTime() && TimeManager.Instance.GetTime() < 20f)
                {
                    //if (answer[count + 1] == 'c')
                    //{
                    scoreNumber += 10;
                    ScoreManager.Instance.SetScore(scoreNumber);
                    //}
                }
                else
                {
                    //if (answer[count + 1] == 'c')
                    //{
                    scoreNumber += 8;
                    ScoreManager.Instance.SetScore(scoreNumber);
                    //}
                }
                //在答题框显示正确的答案
                AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "ShowTheAnswer");

                answerText.Append(number);
                //答题面板实时显示射中的答案
                UIManager.Instance.resultText.text = answerText.ToString();
                //count++;
                ResultManager.Instance.YouAreRight();
                AudioSourceManager.Instance.Play(GameObject.Find("GetScoureAudio").gameObject, "Unbelieve");
                isOnGame = false;
            }
            else
            {

                AudioSourceManager.Instance.Play(GameObject.Find("GetScoureAudio").gameObject, "Wrong");
                scoreNumber -= 5;
                ScoreManager.Instance.SetScore(scoreNumber);
                ResultManager.Instance.YouAreWrong();
                isOnGame = false;
            }
        }
    }

    public void SetAnswer(int num1,int num2,string operatorStr)
    {
        #region 原来
        //char[] rightAnswerChar; //存放计算结果再加个c字符
        //char[] tempChar;    //临时字符数组，存放计算结果
        //switch (operatorStr)
        //{
        //    case "+":
        //        tempChar = (num1 + num2).ToString().ToCharArray();
        //        break;
        //    case "-":
        //        tempChar = (num1 - num2).ToString().ToCharArray();
        //        break;
        //    case "*":
        //        tempChar = (num1 * num2).ToString().ToCharArray();
        //        break;
        //    case "/":
        //        tempChar = (num1 / num2).ToString().ToCharArray();
        //        break;
        //    default:
        //        tempChar = new char[0];
        //        break;
        //}

        //rightAnswerChar = new char[tempChar.Length + 1];//结果数组长度总比临时字符数组长1
        //for (int i = 0; i < tempChar.Length; i++)
        //{
        //    rightAnswerChar[i] = tempChar[i];
        //}
        //rightAnswerChar[tempChar.Length] = 'c';

        //answer = rightAnswerChar;
#endregion

        switch (operatorStr)
        {
            case "+":
                answer = num1 + num2;
                break;
            case "-":
                answer = num1 - num2;
                break;
            case "*":
                answer = num1 * num2;
                break;
            case "/":
                answer = num1 / num2;
                break;
            default:
                answer = -1;
                break;
        }
    }

    public void ClearScoreNumber()
    {
        scoreNumber = 0;
    }
    //清除答题文本信息
    public void ClearAnswerText()
    {
        answerText.Remove(0, answerText.Length);
    }

}
