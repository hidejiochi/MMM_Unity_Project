using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BodyPartsButton : MonoBehaviour {

    [SerializeField]
    private Button _button;   

    [SerializeField]
    private Text _text;

    public void Initialize(string bodyPartsName, string buttonText)
    {        
        //テキストの文字を変更
        _text.text = buttonText;
        //ボタンを押した時
        _button.onClick.AddListener(() => {
            MyoCustom.ChangeParts("Body"+対応したID);
        });
         
    }
}
