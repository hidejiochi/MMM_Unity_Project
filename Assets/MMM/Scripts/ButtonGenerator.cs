using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonGenerator : MonoBehaviour
{

    public StageSelectButton StageSelectButtonPrefab;
    [SerializeField]
    private Transform _contentTransform;
    [SerializeField]
    public List<string> _sceneStringList;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < _sceneStringList.Count; i++)
        {
            //この中でボタンを生成する
            StageSelectButton stageSelectButton = Instantiate(StageSelectButtonPrefab);
            //Scroll ViewのContentを親にする
            stageSelectButton.transform.SetParent(_contentTransform, false);
            //初期化
            string stageStr = _sceneStringList[i];
            string stageNum = (i + 1).ToString();
            stageSelectButton.Initialize(stageStr, stageNum);
        }
    }
}