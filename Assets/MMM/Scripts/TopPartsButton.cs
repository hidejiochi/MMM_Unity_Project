﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TopPartsButton : MonoBehaviour 
{

    [SerializeField]
    private Button _button;

    [SerializeField]
    private Text _text;

    public void Initialize(string buttonText)
    {
        //テキストの文字を変更
        _text.text = buttonText;

    }
}
