using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{

    private int id;
    private int num1;
    private int num2;
    private string operatorStr;
    public static RandomManager instance;
    public static RandomManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (RandomManager)FindObjectOfType(typeof(RandomManager));
            }
            return instance;
        }
    }

    /*
       当题库无题时，选择产生随机数的方式
        */
    public void RandomQuestion()
    {

        System.Random random = new System.Random();
        int oS;
        oS = random.Next(0, 4);

        switch (oS)
        {
            case 0:
                operatorStr = "+";
                num1 = random.Next(0, 99);
                num2 = random.Next(0, 100 - num1);

                break;
            case 1:
                operatorStr = "-";
                num1 = random.Next(0, 100);
                num2 = random.Next(0, num1);

                break;
            case 2:
                operatorStr = "*";
                num1 = random.Next(0, 100);
                num2 = random.Next(0, Num2Multiplication(num1) + 1);

                break;
            case 3:
                operatorStr = "/";
                num1 = random.Next(0, 100);
                num2 = Num2Division(num1);

                break;
            default:
                break;

        }


    }

    /*
     得到乘法模式的下的第二个数
         
         */
    int Num2Multiplication(int num)
    {
        int result = 1;
        while (result * num < 100)
        {
            result++;
        }

        result --;
        return result;

    }
    /*
    得到除法模式的下的第二个数

        */
    int Num2Division(int num)
    {
        System.Random random = new System.Random();
        int number = 0;
        int[] result = new int[100];
        int singleResult = 1;
        for (int i = 0; i <= num; i++)
        {
            if (num % singleResult == 0)
            {
                result[number] = singleResult;
                number++;

            }
            singleResult++;

        }
        int numberOut = random.Next(0, number);

        return result[numberOut];


    }
    /*
     获取num1
         */
    public int GetNum1()
    {
        return this.num1;

    }
    /*
     获取num2
         */
    public int GetNum2()
    {
        return this.num2;

    }
    /*
     获取operatorStr
         */
    public string GetOperatorStr()
    {
        return this.operatorStr;

    }



    public Color RandomColor()
    {
        System.Random r = new System.Random();
        int x = r.Next(1, 3);
        Color color = Color.red;

        switch (x)
        {
            case 1:
                color = Color.red;
                break;
            case 2:
                color = Color.blue;
                break;
            //case 3:
            //    color = Color.cyan;
            //    break;
            //case 4:
            //    color = Color.black;
            //    break;
            //case 5:
            //    color = Color.green;
            //    break;
            //case 6:
            //    color = Color.magenta;
            //    break;
            default:
                break;
        }
        return color;
    }
}
