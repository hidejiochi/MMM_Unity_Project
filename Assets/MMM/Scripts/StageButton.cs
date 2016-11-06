using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private string _sceneName;

    /// <summary>
    /// Initialize this instance.
    /// </summary>
    private void Start()
    {
        _button.onClick.AddListener(() => {
            SceneManager.LoadScene(_sceneName);
        });
    }
}