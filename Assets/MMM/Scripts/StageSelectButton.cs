using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private Text _text;

    public void Initialize(string sceneName, string buttonText)
    {
        //飛ばすシーンを設定
        _sceneName = sceneName;
        //テキストの文字を変更
        _text.text = buttonText;
        //ボタンを押した時
        _button.onClick.AddListener(() => {
            //押されたボタンの名前を設定
            GameManager.Instance.StageNumber = int.Parse(buttonText);
            //シーンを遷移
            SceneManager.LoadScene(_sceneName);
        });
        //_sceneNameがSaveListに含まれているか
        if (StageID.Instance.ClearList.Contains(_sceneName) == true)
        {
            //色を変更する
            _button.image.color = Color.green;
        }
    }
}