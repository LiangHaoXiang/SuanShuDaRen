using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour {


    public static AudioSourceManager instance;

    public static AudioSourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (AudioSourceManager)FindObjectOfType(typeof(AudioSourceManager));
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public AudioClip GetAudioSource(string audioName)
    {
        return Instantiate(Resources.Load(("Audio/" + audioName), typeof(AudioClip))) as AudioClip;
    }

    public void Play(GameObject whichObject, string str)
    {
        AudioClip clip = GetAudioSource(str);//调用Resources方法加载AudioClip资源
        PlayAudioClip(whichObject, clip);
    }

    public void PlayAudioClip(GameObject whichObjectPlay, AudioClip clip)
    {
        if (clip == null)
            return;
        AudioSource source = (AudioSource)whichObjectPlay.gameObject.GetComponent("AudioSource");
        source.clip = clip;
        source.Play();

    }

}

