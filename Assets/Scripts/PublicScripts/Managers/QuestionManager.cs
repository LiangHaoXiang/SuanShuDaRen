using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour {

    public static QuestionManager instance;
    public static QuestionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (QuestionManager)FindObjectOfType(typeof(QuestionManager));
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator DelayShowQuestion(int id, int num1,int num2,string operatorStr)
    {
        yield return new WaitForSeconds(2);
        ShowQuestion(id, num1, num2, operatorStr);
    }

    public void ShowQuestion(int id, int number1, int number2, string operationStr)
    {
        //通过UI展示出题目
        StartCoroutine(UIManager.Instance.ShowQuestionPanel(id, number1, number2, operationStr));
    }

}
