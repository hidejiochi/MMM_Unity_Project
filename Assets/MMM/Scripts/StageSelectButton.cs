using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(_sceneName);
        });
    }
}