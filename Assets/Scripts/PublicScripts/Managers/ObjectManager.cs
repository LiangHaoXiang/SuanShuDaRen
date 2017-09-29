//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ObjectManager : MonoBehaviour
//{

//    int BallonCount = 0;
//    int createBallonNumber;
//    float BallonToy;
//    float BallonTox;
//    float BallonToz;
//    bool IsCreate = false;
//    public List<GameObject> ballonObject = new List<GameObject>();
//    int[] ballonNumberList = new int[10];     //用于存储气球的Number信息列表
//    int ballonNumber;     //用户存储当前生成气球的标号
//    [HideInInspector]
//    public Transform ballonsCenter;     //所有生成气球围绕的中心
//    [HideInInspector]
//    public Transform ballonTargetPoint; //生成气球的目标位置
//    public static ObjectManager instance;

//    public static ObjectManager Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = (ObjectManager)FindObjectOfType(typeof(ObjectManager));
//            }

//            return instance;
//        }
//    }

//    private void Awake()
//    {
//        instance = this;
//    }

//    void Start()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            ballonNumberList[ballonNumber] = 0;
//        }
//        //初始生成x,y,z的随机数
//        Resultxyz();
//        //初始化ballonNumber的值
//        RandomBallonNum();
//    }

//    void Update()
//    {
//        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
//        {
//            ballonsCenter = GameObject.Find("BallonsCenter").transform;
//            ballonTargetPoint = GameObject.Find("BallonTargetPoint").transform;
//            if (IsCreate)
//            {
//                if (BallonCount <= createBallonNumber)
//                {
//                    if (Mathf.Sqrt(BallonTox * BallonTox + BallonToy * BallonToy + BallonToz * BallonToz) < 2.5f)
//                    {                        
//                        if (ballonNumberList[ballonNumber] < 2)
//                        {
//                            if (BallonCount > 0)
//                                ballonsCenter.Rotate(0, (360 / createBallonNumber), 0);
//                            ballonNumberList[ballonNumber]++;
//                            CreateObject(new Vector3(ballonTargetPoint.position.x + BallonTox,
//                                ballonTargetPoint.position.y + BallonToy, ballonTargetPoint.position.z + BallonToz), ballonNumber);
//                            BallonCount++;
//                            Resultxyz();
//                            RandomBallonNum();
//                        }
//                        else
//                        {
//                            RandomBallonNum();
//                        }
//                    }
//                    else
//                    {
//                        Resultxyz();
//                    }
//                }
//            }

//        }

//        if (BallonCount == createBallonNumber)
//        {
//            IsCreate = false;
//        }
//    }


//    //控制产生气球的条件
//    public IEnumerator BeginCreate(int createBallonNumber)
//    {
//        AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "ObjectShow");
//        IsCreate = true;
//        BallonCount = 0;
//        this.createBallonNumber = createBallonNumber;

//        yield return null;
//    }


//    /// <summary>
//    /// 创建新的气球  
//    /// </summary>
//    /// <param name="ballonPosition"></param>
//    /// <param name="number"></param>
//    public void CreateObject(Vector3 ballonPosition, int number)
//    {
//        int randomShapeNum = RandomBallonShape();
//        if (number > 10)
//        {
//            randomShapeNum = 3;//若气球数字是十位数，则用心形气球
//        }
//        GameObject ballon = Instantiate(Resources.Load("Prefabs/Scene5(SuanShu)/Ballon" + randomShapeNum, typeof(GameObject))) as GameObject;
//        ballon.transform.position = ballonPosition;
//        ballon.transform.parent = GameObject.Find("BallonsCreates").transform;
//        ballonObject.Add(ballon);
//        if (ballonNumberList[0] > 1 && number == 0)
//        {
//            ballon.transform.FindChild("BallonSelf").transform.GetComponent<BallonObject>().setBallonNumber("?");
//            ballon.transform.GetChild(6).GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
//        }
//        else
//        {
//            ballon.transform.FindChild("BallonSelf").transform.GetComponent<BallonObject>().setBallonNumber("" + number);
//            ballon.transform.GetChild(6).GetChild(0).GetComponent<MeshRenderer>().material.color = RandomManager.Instance.RandomColor();

//        }
//    }

//    //随机生成气球距离顶点的范围的三维坐标随机数
//    void Resultxyz()
//    {
//        BallonToy = (float)Random.Range(-2.5f, 2.5f);
//        BallonTox = (float)Random.Range(-0.5f, 0.5f);
//        BallonToz = (float)Random.Range(-0.5f, 0.5f);
//    }

//    //随机生成气球的Number
//    void RandomBallonNum()
//    {
//        ballonNumber = (int)Random.Range(0, 10);
//    }

//    //气球随机形状编号
//    int RandomBallonShape()
//    {
//        return Random.Range(1, 6);
//    }

//    //销毁所有气球
//    public void DestoryBallon()
//    {
//        foreach (GameObject T in ballonObject)
//        {
//            Destroy(T);
//        }

//        ballonObject.Clear();
//        for (int i = 0; i < 10; i++)
//        {
//            ballonNumberList[i] = 0;
//        }
//    }

//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{

    int BallonCount = 0;
    int createBallonNumber;
    float BallonToy;
    float BallonTox;
    float BallonToz;
    bool IsCreate = false;
    int rightAnswerNumber; //用于存储正确的气球答案
    int ballonNumber;     //用户存储当前生成气球的标号
    int randomNumber;     //用于存储气球的随机位置
    [HideInInspector]
    public List<GameObject> ballonObject = new List<GameObject>();
    [HideInInspector]
    public List<int> ballonNumberList = new List<int>(); //用于存储气球的Number信息列表
    [HideInInspector]
    public Transform ballonsCenter;     //所有生成气球围绕的中心
    [HideInInspector]
    public Transform ballonTargetPoint; //生成气球的目标位置
    public static ObjectManager instance;

    public static ObjectManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ObjectManager)FindObjectOfType(typeof(ObjectManager));
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
            ballonsCenter = GameObject.Find("BallonsCenter").transform;
            ballonTargetPoint = GameObject.Find("BallonTargetPoint").transform;
            if (IsCreate)
            {
                if (BallonCount <= createBallonNumber)
                {
                    if (BallonCount > 0)
                        ballonsCenter.Rotate(0, (360 / createBallonNumber), 0);
                    CreateObject(new Vector3(ballonTargetPoint.position.x + BallonTox,
                    ballonTargetPoint.position.y + BallonToy, ballonTargetPoint.position.z + BallonToz), ballonNumber);
                    BallonCount++;
                    Resultxyz();
                    RandomBallonNum();
                }
            }

        }

        if (BallonCount == createBallonNumber)
        {
            IsCreate = false;
        }
    }


    //控制产生气球的条件
    public IEnumerator BeginCreate(int createBallonNumber)
    {
        AudioSourceManager.Instance.Play(GameObject.Find("IntrodutionAudio").gameObject, "ObjectShow");
        rightAnswerNumber = AnswerManager.Instance.GetAnswer();
        BallonCount = 0;
        this.createBallonNumber = createBallonNumber;
        //随机赋值位置
        randomNumber = Random.Range(1, createBallonNumber);
        //初始生成x,y,z的随机数
        Resultxyz();
        //初始化ballonNumber的值
        RandomBallonNum();
        IsCreate = true;
        yield return null;
    }


    /// <summary>
    /// 创建新的气球  
    /// </summary>
    /// <param name="ballonPosition"></param>
    /// <param name="number"></param>
    public void CreateObject(Vector3 ballonPosition, int number)
    {
        int randomShapeNum = RandomBallonShape();

        GameObject ballon = Instantiate(Resources.Load("Prefabs/Scene5(SuanShu)/Ballon" + randomShapeNum, typeof(GameObject))) as GameObject;
        ballon.transform.position = ballonPosition;
        ballon.transform.parent = GameObject.Find("BallonsCreates").transform;
        ballonObject.Add(ballon);
        if (ballonNumber == -1)
        {
            ballon.transform.FindChild("BallonSelf").transform.GetComponent<BallonObject>().setBallonNumber("?");
            //ballon.transform.GetChild(6).GetChild(0).GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            ballon.transform.FindChild("BallonSelf").transform.GetComponent<BallonObject>().setBallonNumber("" + number);
           // ballon.transform.GetChild(6).GetChild(0).GetComponent<MeshRenderer>().material.color = RandomManager.Instance.RandomColor();

        }
    }

    //随机生成气球距离顶点的范围的三维坐标随机数
    void Resultxyz()
    {
        do
        {
            BallonToy = (float)Random.Range(-2.5f, 2.5f);
            BallonTox = (float)Random.Range(-0.5f, 0.5f);
            BallonToz = (float)Random.Range(-0.5f, 0.5f);
        } while (Mathf.Sqrt(BallonTox * BallonTox + BallonToy * BallonToy + BallonToz * BallonToz) >= 2.5f);
    }

    //随机生成气球的Number
    void RandomBallonNum()
    {
        if (ballonNumberList.Count == 0)
        {
            ballonNumber = -1;
        }
        else if (ballonNumberList.Count == randomNumber)
        {
            ballonNumber = rightAnswerNumber;
        }
        else
        {
            do
            {
                ballonNumber = (int)Random.Range(rightAnswerNumber - createBallonNumber, rightAnswerNumber + createBallonNumber);
            } while (ballonNumber < 0 || ballonNumberList.Contains(ballonNumber) || ballonNumber == rightAnswerNumber);
        }
        ballonNumberList.Add(ballonNumber);
    }

    //气球随机形状编号
    int RandomBallonShape()
    {
        if (InitGameManager.Instance.level == 1)
        {
            return 1;
        }
        if (InitGameManager.Instance.level == 2)
        {
            return 2;
        }
        if (InitGameManager.Instance.level == 3)
        {
            return 3;
        }
        if (InitGameManager.Instance.level == 4)
        {
            return 4;
        }
        if (InitGameManager.Instance.level == 5)
        {
            return 5;
        }
        if (InitGameManager.Instance.level >= 6)
        {
            return 5;
        }
        return Random.Range(1, 6);
    }

    //销毁所有气球
    public void DestoryBallon()
    {
        foreach (GameObject T in ballonObject)
        {
            Destroy(T);
        }
        ballonObject.Clear();
        ballonNumberList.Clear();
    }

}








