using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    public int MaxStageNumber;
    [SerializeField]
    public int StageNumber;
    // Use this for initialization
    private void Start()
    {
        //シーンを跨いでもこのスクリプトがアタッチされたオブジェクトは消えない
        DontDestroyOnLoad(gameObject);
    }

}

