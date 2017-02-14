using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaySoundGem : SingletonMonoBehaviour<PlaySoundGem>
{

    private AudioSource SoundGem;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        SoundGem = GetComponent<AudioSource>();
    }

    public void playSoundGem() 
    {
        SoundGem.PlayOneShot(SoundGem.clip);
    }
}
