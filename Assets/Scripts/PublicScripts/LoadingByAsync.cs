using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingByAsync : MonoBehaviour
{
    AsyncOperation async;   //异步对象
    public int progress = 0;    //读取场景的进度，它的取值范围在0 - 1 之间。

    public static LoadingByAsync instance;
    public static LoadingByAsync Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (LoadingByAsync)FindObjectOfType(typeof(LoadingByAsync));
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start () {
        //若当前是场景4，就异步加载到选的目标游戏场景
        if (SceneManager.GetActiveScene().name.Equals("Scene4(Loading)"))
        {
            StartCoroutine(DelayLoading());
        }
    }
	
	void Update () {
        //async.progress 的取值范围在0.1 - 1之间， 但是它不会等于1
        if (async != null)
            progress = (int)(async.progress * 100);
    }

    public IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(0.3f);
        yield return Load_Scene(UIManager.targetScene);
    }

    //注意这里返回值一定是 IEnumerator
    public IEnumerator Load_Scene(string sceneName)
    {
        //异步读取场景。
        async = SceneManager.LoadSceneAsync(sceneName);

        yield return async;
    }
}
