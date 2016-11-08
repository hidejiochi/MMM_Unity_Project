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

    [SerializeField]
    private List<string> saveList;

    public List<string> SaveList
    {
        get { return saveList; }
    }

    public void Initialize(string sceneName, string buttonText)
    {
        //飛ばすシーンを設定
        _sceneName = sceneName;
        //テキストの文字を変更
        _text.text = buttonText;
        //ボタンを押した時
        _button.onClick.AddListener(() => {
            SceneManager.LoadScene(_sceneName);
        });
        //_sceneNameがSaveListに含まれているか
        if (SaveList.Contains(_sceneName) == true)
        {
            //色を変更する
            _button.image.color = Color.red;
        }
    }
}