using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalletManager : MonoBehaviour
{
    [HideInInspector]
    public Transform balletObjectShow;      //子弹发射起始点
    [HideInInspector]
    public Transform balletShowOtherDir;    //子弹发射朝向
    int BalletCount = 5;
    public bool isFire = false;
    bool isAddBalletAudio = true;
    float isAddBallettime = 0f;
    public static BalletManager instance;

    public static BalletManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BalletManager)FindObjectOfType(typeof(BalletManager));
            }
            return instance;

        }
        set
        {
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene5(SuanShu)"))
        {
            balletObjectShow = GameObject.Find("BalletGun").transform;
            balletShowOtherDir = GameObject.Find("BalletShowOtherDir").transform;

            isAddBallettime += Time.deltaTime;
            if (isAddBallettime > 1f)
            {
                isAddBalletAudio = true;
            }
            UIManager.Instance.ShowBalletCount(BalletCount);
        }
    }
    /// <summary>
    /// 开火，发射
    /// </summary>
    public void Fire()
    {
        if (isFire && AnswerManager.Instance.isOnGame)
        {
            if (BalletCount == 0)
            {
                Play("NoBallet"); //此处改为咔嚓咔嚓的声音
            }
            if (BalletCount > 0)
            {
                CreateBalletObject(balletShowOtherDir.position);
                BalletCount--;
         
                UIManager.Instance.sightBead.GetComponent<Animation>().Play("RedSightChange");
            }
        }
    }
    /// <summary>
    /// 装弹
    /// </summary>
    public void AddBallet()
    {
        if (isFire && (BalletCount == 0 || BalletCount == 1))
        {

            Invoke("ResrtBalletCount", 1);
            Invoke("DelaySetIsFire", 1);
            isFire = false;
            if (isAddBalletAudio)
            {
                Play("AddBallet");
                isAddBalletAudio = false;
                isAddBallettime = 0;
            }
        }
    }

    void ResrtBalletCount()
    {
        BalletCount = 5;

    }

    void CreateBalletObject(Vector3 balletShootDir)
    {
        GameObject Ballet = Instantiate(Resources.Load("Prefabs/Normal/Ballet", typeof(GameObject))) as GameObject;
        Ballet.transform.position = balletObjectShow.position;
        Ballet.transform.GetChild(0).LookAt(balletShowOtherDir);
        Ballet.GetComponent<BalletObject>().setBalletShootDir(balletShootDir);
    }

    public void Play(string str)
    {
        AudioClip clip = AudioSourceManager.Instance.GetAudioSource(str);//调用Resources方法加载AudioClip资源
        PlayAudioClip(clip);
    }

    public void PlayAudioClip(AudioClip clip)
    {
        if (clip == null)
            return;
        AudioSource source = (AudioSource)balletObjectShow.gameObject.GetComponent("AudioSource");
        source.clip = clip;
        source.Play();

    }

    public IEnumerator WaitFire()
    {
        ResrtBalletCount();
        yield return new WaitForSeconds(2);
        setIsFire(true);
    }

    public void setIsFire(bool isFire)
    {
        this.isFire = isFire;
    }

    public void DelaySetIsFire()
    {
        setIsFire(true);
    }

}

