using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;

public class PropGenerator : MonoBehaviour
{

    public GameObject MyoPrefab; 
    public GameObject WallPrefab;
	public GameObject SquarePrefab;
	public GameObject CubePrefab;
	public GameObject HelixPrefab;
	public GameObject PipePrefab;
	public GameObject SolidPrefab;
	public GameObject TorusPrefab;
        
    /// <summary>
    /// (0,0)のマス目の位置 
    /// </summary>
    [SerializeField]
	private Vector3 _squareStartPosition = new Vector3 (-11f, 0, -11f);
	/// <summary>
	/// 11 x 11のマス目 
	/// </summary>
	[SerializeField]
	private Vector2 _maxSquare = new Vector2 (11, 11);
	/// <summary>
	/// １マスの長さ
	/// </summary>
	[SerializeField]
	private float _squareLength = 2f;
	/// <summary>
	/// SquarePrefabを配置する位置のリスト 
	/// </summary>
	[SerializeField]
	private List<Vector3> _squarePositionList;

	[SerializeField]
	private List<Vector3> _cubePositionList;

	[SerializeField]
	private List<Vector3> _helixPositionList;

	[SerializeField]
	private List<Vector3> _pipePositionList;

	[SerializeField]
	private List<Vector3> _solidPositionList;

	[SerializeField]
	private List<Vector3> _torusPositionList;
    
    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start ()
	{
		for (float y = 0; y <= _maxSquare.y; y++) {
			for (float x = 0; x <= _maxSquare.x; x++) {
				//座標位置
				Vector3 pos = _squareStartPosition + new Vector3 (x * _squareLength, 0, y * _squareLength);			
				//マス目位置
				Vector2 square = new Vector2 (x, y);
                //マス目の情報クラスを生成
                SquareInfo squareInfo = new SquareInfo(pos, square);
                //ディクショナリーに要素を追加
                SquareManager.Instance.SquareDictionary.Add (square, squareInfo);

				//壁を配置する条件
				if ((y == 0 || y == _maxSquare.y) || x == 0 || x == _maxSquare.x) {
					CreatePrefab (WallPrefab, pos, new Vector2 (x, y));
				}
                //Squareの配置
                //指定した位置がリスト内に含まれていれば
                if (_squarePositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(SquarePrefab, pos, new Vector2(x, y));
                    
                }
                if (_cubePositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(CubePrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_helixPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(HelixPrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_pipePositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(PipePrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_solidPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(SolidPrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_torusPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(TorusPrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
            }
		}
	}

    /// <summary>
    /// プレハブを生成する関数 
    /// </summary>
    /// <param name="obj">Object.</param>
    /// <param name="pos">Position.</param>
    /// <param name="square">Square.</param>
    private GameObject CreatePrefab(GameObject prefab, Vector3 pos, Vector2 square)
    {
        //生成
        GameObject obj = Instantiate(prefab) as GameObject;
        //位置を設
        obj.transform.position = pos;
        //マネージャーに情報を加える
        SquareManager.Instance.AddGameObject(square, obj);
        //生成したゲームオブジェクトを返す
        return obj;


    }


    /// <summary>
    /// Update this instance.
    /// </summary>
    private void Update ()
	{
        
    }
    
}
