using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager : MonoBehaviour {

    public static JsonManager instance;
    public static JsonManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (JsonManager)FindObjectOfType(typeof(JsonManager));
            }
            return instance;
        }
    }

    #region 题库的属性
    [HideInInspector]
    public List<TestItem1> AR_Calculate_Test1;
    [HideInInspector]
    public List<TestItem2> AR_Calculate_Test2;
    [HideInInspector]
    public List<TestItem3> AR_Calculate_Test3;
    [HideInInspector]
    public List<TestItem4> AR_Calculate_Test4;
    [HideInInspector]
    public List<TestItem5> AR_Calculate_Test5;
    [HideInInspector]
    public List<TestItem6> AR_Calculate_Test6;
    [HideInInspector]
    public List<TestItem7> AR_Calculate_Test7;
    [Serializable]
    public class TestItem1  //题目拥有的属性
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem2
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem3
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem4
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem5
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem6
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }
    [Serializable]
    public class TestItem7
    {
        public int ID;          //题号
        public int num1;
        public int num2;
        public string operation;//运算法则
    }

    [Serializable]
    public class Test
    {
        public List<TestItem1> AR_Calculate_Test_Level1;
        public List<TestItem2> AR_Calculate_Test_Level2;
        public List<TestItem3> AR_Calculate_Test_Level3;
        public List<TestItem4> AR_Calculate_Test_Level4;
        public List<TestItem5> AR_Calculate_Test_Level5;
        public List<TestItem6> AR_Calculate_Test_Level6;
        public List<TestItem7> AR_Calculate_Test_Level7;
    }
    #endregion


    string json;

    void Awake()
    {
        instance = this;

        #region ???
        //#if UNITY_ANDROID
        //        Debug.Log("这里是安卓设备^_^");
        //#endif

        //#if UNITY_IPHONE
        //        Debug.Log("这里是苹果设备>_<");
        //#endif

        //#if UNITY_STANDALONE_WIN
        //        json = File.ReadAllText("H:\\云孩科技/Json/AR_Calculate_Test.txt");  //读取json数据
        //        JsonTest1(json);
        //        JsonTest2(json);
        //        JsonTest3(json);
        //        JsonTest4(json);
        //        JsonTest5(json);
        //        JsonTest6(json);
        //        JsonTest7(json);
        //#endif

        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    Debug.Log("what");
        //}
        //if (Application.platform == RuntimePlatform.WindowsEditor)
        //{
        //    json = File.ReadAllText("H:\\云孩科技/Json/AR_Calculate_Test.txt");  //读取json数据
        //    JsonTest1(json);
        //    JsonTest2(json);
        //    JsonTest3(json);
        //    JsonTest4(json);
        //    JsonTest5(json);
        //    JsonTest6(json);
        //    JsonTest7(json);
        //}

        //json = File.ReadAllText(Application.streamingAssetsPath + "/AR_Calculate_Test.txt");  //读取json数据
        //json = File.ReadAllText(Application.dataPath + "/AR_Calculate_Test.txt");  //读取json数据
        //json = File.ReadAllText(Application.persistentDataPath + "/AR_Calculate_Test.txt");  //读取json数据
        #endregion

        SelectJson();

        ReadAllJsonToStoreInLists();
    }
    /// <summary>
    /// 随机抽取Json题库
    /// </summary>
    public void SelectJson()
    {
        System.Random r = new System.Random();
        int x = r.Next(1, 6);

        TextAsset textAsset = new TextAsset();

        textAsset = Resources.Load("Json/AR_Calculate_Test" + x) as TextAsset;

        json = textAsset.text;
    }
    /// <summary>
    /// 读取题库所有等级的题目
    /// </summary>
    public void ReadAllJsonToStoreInLists()
    {
        JsonTest1(json);
        JsonTest2(json);
        JsonTest3(json);
        JsonTest4(json);
        JsonTest5(json);
        JsonTest6(json);
        JsonTest7(json);
    }

    public void ClearJsonLists()
    {
        AR_Calculate_Test1.Clear();
        AR_Calculate_Test2.Clear();
        AR_Calculate_Test3.Clear();
        AR_Calculate_Test4.Clear();
        AR_Calculate_Test5.Clear();
        AR_Calculate_Test6.Clear();
        AR_Calculate_Test7.Clear();
    }

    public void JsonTest1(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test1 = item.AR_Calculate_Test_Level1;    //获取类的对象拥有的属性列表
        }
    }

    public void JsonTest2(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test2 = item.AR_Calculate_Test_Level2;    //获取类的对象拥有的属性列表
        }
    }
    public void JsonTest3(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test3 = item.AR_Calculate_Test_Level3;    //获取类的对象拥有的属性列表
        }
    }
    public void JsonTest4(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test4 = item.AR_Calculate_Test_Level4;    //获取类的对象拥有的属性列表
        }
    }
    public void JsonTest5(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test5 = item.AR_Calculate_Test_Level5;    //获取类的对象拥有的属性列表
        }
    }
    public void JsonTest6(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test6 = item.AR_Calculate_Test_Level6;    //获取类的对象拥有的属性列表
        }
    }
    /// <summary>
    /// 无尽模式题库
    /// </summary>
    /// <param name="json"></param>
    public void JsonTest7(string json)
    {
        if (json != string.Empty)
        {
            Test item = JsonUtility.FromJson<Test>(json);     //反序列化后存储到类或结构体
            AR_Calculate_Test7 = item.AR_Calculate_Test_Level7;    //获取类的对象拥有的属性列表
        }
    }
}
