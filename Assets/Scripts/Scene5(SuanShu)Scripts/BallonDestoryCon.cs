//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallonDestoryCon : MonoBehaviour
//{

//    bool IsBroken = false;

//    void Update()
//    {
//        if (IsBroken)
//        {
//            transform.GetChild(0).gameObject.SetActive(true);

//            transform.GetChild(1).gameObject.SetActive(true);
//            transform.GetChild(2).gameObject.SetActive(true);
//            transform.GetChild(3).gameObject.SetActive(true);
//            transform.GetChild(4).gameObject.SetActive(true);
//            Destroy(this.gameObject, 4);
//            Play("BallonDestoryAudio");
//            IsBroken = false;
//        }

//    }

//    public void setIsBroken(bool isBroken)
//    {
//        this.IsBroken = isBroken;
//    }

//    public void Play(string str)
//    {
//        AudioClip clip = AudioSourceManager.Instance.GetAudioSource(str);//调用Resources方法加载AudioClip资源
//        PlayAudioClip(clip);
//    }

//    public void PlayAudioClip(AudioClip clip)
//    {
//        if (clip == null)
//            return;
//        AudioSource source = (AudioSource)this.gameObject.GetComponent("AudioSource");
//        source.clip = clip;
//        source.Play();

//    }
//}

//public class CopyOfBallonDestoryCon : MonoBehaviour
//{

//    bool IsBroken = false;

//    void Update()
//    {
//        if (IsBroken)
//        {
//            transform.GetChild(0).gameObject.SetActive(true);

//            transform.GetChild(1).gameObject.SetActive(true);
//            transform.GetChild(2).gameObject.SetActive(true);
//            transform.GetChild(3).gameObject.SetActive(true);
//            transform.GetChild(4).gameObject.SetActive(true);
//            Destroy(this.gameObject, 4);
//            Play("BallonDestoryAudio");
//            IsBroken = false;
//        }

//    }

//    public void setIsBroken(bool isBroken)
//    {
//        this.IsBroken = isBroken;
//    }

//    public void Play(string str)
//    {
//        AudioClip clip = AudioSourceManager.Instance.GetAudioSource(str);//调用Resources方法加载AudioClip资源
//        PlayAudioClip(clip);
//    }

//    public void PlayAudioClip(AudioClip clip)
//    {
//        if (clip == null)
//            return;
//        AudioSource source = (AudioSource)this.gameObject.GetComponent("AudioSource");
//        source.clip = clip;
//        source.Play();

//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonDestoryCon : MonoBehaviour
{

    bool IsBroken = false;
    bool IsBlackBallon;
    void Update()
    {
        if (IsBroken && !IsBlackBallon)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            Destroy(this.gameObject, 3);
            AudioSourceManager.Instance.Play(GameObject.Find("BallonDestory").gameObject, "BallonDestoryAudio");
            IsBroken = false;
        }

        if (IsBroken && IsBlackBallon)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            Destroy(this.gameObject, 3);
            AudioSourceManager.Instance.Play(GameObject.Find("BallonDestory").gameObject , "AnswerAudio");
            IsBroken = false;
        }
    }

    public void setIsBroken(bool isBroken, bool isBlackBallon)
    {
        this.IsBroken = isBroken;
        this.IsBlackBallon = isBlackBallon;
    }

    //public void Play(string str)
    //{
    //    AudioClip clip = AudioSourceManager.Instance.GetAudioSource(str);//调用Resources方法加载AudioClip资源
    //    PlayAudioClip(clip);
    //}

    //public void PlayAudioClip(AudioClip clip)
    //{
    //    if (clip == null)
    //        return;
    //    AudioSource source = (AudioSource)this.gameObject.GetComponent("AudioSource");
    //    source.clip = clip;
    //    source.Play();

    //}
}
