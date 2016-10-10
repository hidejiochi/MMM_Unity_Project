using UnityEngine;
using System.Collections;

public class GameDefine
{
    /// <summary>
    /// ジェムの色 
    /// </summary>
    public enum GemType
    {
        CUBE,
        HELIX,
        PIPE,
        SOLID,
        TOURUS
    }

    /// <summary>
    /// マス目の状態 
    /// </summary>
    public enum SquareState
    {
        //何も乗っていない空の状態
        EMPTY,
        //ジェムが乗っている
        GEM,
        //壁が乗っている
        WALL
    }
}