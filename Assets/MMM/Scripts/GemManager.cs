using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Gemを管理するマネージャークラス 
/// </summary>
public class GemManager : SingletonMonoBehaviour<GemManager>
{
    /// <summary>
    /// ジェムのリスト 
    /// </summary>
    private List<Gem> _gemList = new List<Gem>();

    /// <summary>
    /// これはGemに要素を加える関数ですよ 
    /// </summary>
    /// <param name="gem">Gem.</param>
    public void Add(Gem gem)
    {
        //要素に加える
        _gemList.Add(gem);
    }

    /// <summary>
    /// Remove the specified gem.
    /// </summary>
    /// <param name="gem">Gem.</param>
    public void Remove(Gem gem)
    {
        //リストに含まれていなければ
        if (_gemList.Contains(gem) == false)
        {
            return;
        }
        //要素から消す
        _gemList.Remove(gem);
        //ゲームオブジェクトの削除
        Destroy(gem.gameObject);
    }

    /// <summary>
    /// クリア判定
    /// </summary>
    /// <returns><c>true</c> if this instance is clear; otherwise, <c>false</c>.</returns>
    public bool IsClear()
    {
        //配列の要素が０になったかどうか
        return _gemList.Count == 0;
    }
}