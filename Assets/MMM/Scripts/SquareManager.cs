using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// マス目の情報を管理するマネージャークラス 
/// </summary>
public class SquareManager
{
	#region Singleton Implimentation

	private static SquareManager _instance;

	private SquareManager ()
	{ // Private Constructor

		Debug.Log ("Create SquareManager instance.");
	}

	public static SquareManager Instance {

		get {

			if (_instance == null)
				_instance = new SquareManager ();

			return _instance;
		}
	}

	#endregion

	/// <summary>
	/// マス目とマス目の情報が紐づいたディクショナリー 
	/// </summary>
	private Dictionary<Vector2,SquareInfo> _squareDictionary 
	= new Dictionary<Vector2, SquareInfo> ();

	public Dictionary<Vector2,SquareInfo> SquareDictionary {
		get {
			return _squareDictionary;
		}
	}

	/// <summary>
	/// 指定したマス目の情報を取得する 
	/// </summary>
	/// <param name="square">Square.</param>
	public SquareInfo GetSquareInfomation (Vector2 square)
	{
		SquareInfo info = null;
		if (_squareDictionary.TryGetValue (square, out info) == false) {
			Debug.LogWarningFormat ("マス目の情報を取得できませんでした square:{0}", square);
		}
		return info;
	}

	/// <summary>
	/// 指定したマス目にゲームオブジェクトを設定する
	/// </summary>
	/// <param name="square">Square.</param>
	/// <param name="obj">Object.</param>
	public void AddGameObject (Vector2 square, GameObject obj)
	{
		SquareInfo info = null;
		if (_squareDictionary.TryGetValue (square, out info)) {
			info.SetGameObject (obj);
		}
	}

	/// <summary>
	/// 指定したマス目のゲームオブジェクトの情報を消去する 
	/// </summary>
	/// <param name="square">Square.</param>
	/// <param name="obj">Object.</param>
	public void RemoveGameObject (Vector2 square)
	{
		SquareInfo info = null;
		if (_squareDictionary.TryGetValue (square, out info)) {
			info.SetGameObject (null);
		}
	}

	/// <summary>
	/// ゲームオブジェクトを移動する 
	/// </summary>
	/// <param name="fromSquare">元いたマス目位置</param>
	/// <param name="targetSquare">目標マス目位置</param>
	/// <param name="obj">Object.</param>
	public void Move (Vector2 fromSquare, Vector2 targetSquare, GameObject obj)
	{
		RemoveGameObject (fromSquare);	
		AddGameObject (targetSquare, obj);
	}
}