using UnityEngine;
using System.Collections;

/// <summary>
/// マス目の情報クラス 
/// </summary>
public class SquareInfo
{
    //マス目の状態
    public GameDefine.SquareState State { get; private set; }
    //マスが所有しているゲームオブジェクト
    public GameObject HasGameObject { get; private set; }
    //マス目の位置(ワールド座標)
    public Vector3 Pos { get; private set; }
    //マス目位置
    public Vector2 MySquare { get; private set; }

    /// <summary>
    /// 生成時に実行されるコンストラクタ
    /// </summary>
    /// <param name="pos">Position.</param>
    public SquareInfo(Vector3 pos, Vector2 square)
    {
        Pos = pos;
        HasGameObject = null;
        State = GameDefine.SquareState.EMPTY;
        MySquare = square;
    }

    /// <summary>
    /// マス目にゲームオブジェクトをセットする 
    /// </summary>
    /// <param name="obj">Object.</param>
    public void SetGameObject(GameObject obj)
    {
        if (obj == null)
        {
            State = GameDefine.SquareState.EMPTY;
        }
        else if (obj.tag == "Gem")
        {
            State = GameDefine.SquareState.GEM;
        }
        else if (obj.tag == "Wall")
        {
            State = GameDefine.SquareState.WALL;
        }
        else
        {
            Debug.LogWarningFormat("無効なゲームオブジェクトがセットされた可能性があります GameObjectの名前:{0}", obj.name);
        }
        HasGameObject = obj;
    }
}