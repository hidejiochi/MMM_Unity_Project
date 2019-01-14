using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextStageButton : MonoBehaviour
{
    //追記
    [SerializeField]
    private Text _buttonText;
    [SerializeField]
    private Button _button;
    [SerializeField]
    private string _sceneName;

    /// <summary>
    /// Initialize this instance.
    /// </summary>
    private void Start()
    {
        //シーンの名前を取得
        string sceneName = SceneManager.GetActiveScene().name;
        //数値に変換して1足す
        int nextStageNum = int.Parse(sceneName) + 1;
        //分岐
        
        {
            //ボタンが押された時の処理
            _button.onClick.AddListener(() => {
                SceneManager.LoadScene(nextStageNum.ToString());
            });
        }
    }
}
