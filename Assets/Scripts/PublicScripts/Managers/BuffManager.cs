using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour {

    public static BuffManager instance;

    public static BuffManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BuffManager)FindObjectOfType(typeof(BuffManager));
            }
            return instance;

        }

    }

    public void LuckyBalloon()
    {
        System.Random r = new System.Random();
        int n = r.Next(1, 4);

        UIManager.Instance.TipsByLuckyBalloon(n);
        switch (n)
        {
            case 1:
                foreach (GameObject T in ObjectManager.instance.ballonObject)//气球变大
                {
                    iTween.ScaleTo(T, iTween.Hash("scale", new Vector3(1.30f, 1.30f, 1.30f), "time", 1f));
                }
                break;
            case 2:
                AnswerManager.Instance.scoreNumber += 5;
                ScoreManager.Instance.SetScore(AnswerManager.Instance.scoreNumber);
                //额外加分
                break;
            case 3:
                float nGameTime = TimeManager.Instance.GetTime();//增加时间
                nGameTime += 5;
                TimeManager.Instance.SetTime(nGameTime);
                break;
            //case 3:
            //    foreach (GameObject T in ObjectManager.instance.ballonObject)
            //    {
            //        iTween.RotateBy(T, iTween.Hash("y", 12, "time", 12f, "looptype", iTween.LoopType.loop, "easetype", iTween.EaseType.linear));
            //    }
            //    break;

            default:
                break;
        }
    }
}
