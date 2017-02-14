using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaySoundClear : SingletonMonoBehaviour<PlaySoundClear>
{

    private AudioSource SoundClear;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        SoundClear = GetComponent<AudioSource>();
    }

    public void playSoundClear() 
    {
        SoundClear.PlayOneShot(SoundClear.clip);
    }
}
