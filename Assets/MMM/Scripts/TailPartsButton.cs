using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TailPartsButton : MonoBehaviour
{

    [SerializeField]
    private Button _button;

    public Button Button
    {
        get
        {
            return _button;
        }
    }

    [SerializeField]
    private Text _text;

    public void Initialize(string tailPartsID, string buttonText)
    {
        //テキストの文字を変更
        _text.text = buttonText;
        
    }       
}