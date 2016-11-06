using UnityEngine;
using System.Collections;

public class GameDefine
{
    /// <summary>
    /// ジェムの色 
    /// </summary>
    public enum GemType
    {
        CROSS,
        CUBE,
        HEART, 
        PIPE,
        PYRAMID,
        SOLID,
        STAR,
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