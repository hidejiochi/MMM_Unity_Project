using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

public class PropGenerator : MonoBehaviour
{

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
    void Start ()
	{
		for (float y = 0; y <= _maxSquare.y; y++) {
			for (float x = 0; x <= _maxSquare.x; x++) {
				//座標位置
				Vector3 pos = _squareStartPosition + new Vector3 (x * _squareLength, 0, y * _squareLength);			
				//マス目位置
				Vector2 square = new Vector2 (x, y);			
				//マス目の情報クラスを生成
				SquareInfo squareInfo = new SquareInfo () {
					pos = pos,
					hasGameObject = null
				};
				//ディクショナリーに要素を追加
				SquareManager.Instance.SquareDictionary.Add (square, squareInfo);

				//壁を配置する条件
				if ((y == 0 || y == 11) || x == 0 || x == 11)
                {
					GameObject wallObj = Instantiate (WallPrefab) as GameObject;
					wallObj.transform.position = pos;
					//マネージャーに情報を加える
					SquareManager.Instance.AddGameObject (new Vector2 (x, y), wallObj);	
				}

				//Squareの配置
				//指定した位置がリスト内に含まれていれば
				if (_squarePositionList.Contains (pos)) {
					//生成
					GameObject squareObj = Instantiate (SquarePrefab) as GameObject;                    
                    //位置を設定
                    squareObj.transform.position = pos;
					//マネージャーに情報を加える
					SquareManager.Instance.AddGameObject (new Vector2 (x, y), squareObj);	
				}
                if (_cubePositionList.Contains(pos))
                {
                    //生成
                    GameObject cubeObj = Instantiate(CubePrefab) as GameObject;
                    //位置を設定
                    cubeObj.transform.position = pos;
                    //マネージャーに情報を加える
                    SquareManager.Instance.AddGameObject(new Vector2(x, y), cubeObj);
                }
                if (_helixPositionList.Contains(pos))
                {
                    //生成
                    GameObject helixObj = Instantiate(HelixPrefab) as GameObject;
                    //位置を設定
                    helixObj.transform.position = pos;
                    //マネージャーに情報を加える
                    SquareManager.Instance.AddGameObject(new Vector2(x, y), helixObj);
                }
                if (_pipePositionList.Contains(pos))
                {
                    //生成
                    GameObject pipeObj = Instantiate(PipePrefab) as GameObject;
                    //位置を設定
                    pipeObj.transform.position = pos;
                    //マネージャーに情報を加える
                    SquareManager.Instance.AddGameObject(new Vector2(x, y), pipeObj);
                }
                if (_solidPositionList.Contains(pos))
                {
                    //生成
                    GameObject solidObj = Instantiate(SolidPrefab) as GameObject;
                    //位置を設定
                    solidObj.transform.position = pos;
                    //マネージャーに情報を加える
                    SquareManager.Instance.AddGameObject(new Vector2(x, y), solidObj);
                }
                if (_torusPositionList.Contains(pos))
                {
                    //生成
                    GameObject torusObj = Instantiate(TorusPrefab) as GameObject;
                    //位置を設定
                    torusObj.transform.position = pos;
                    //マネージャーに情報を加える
                    SquareManager.Instance.AddGameObject(new Vector2(x, y), torusObj);
                }
            }
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
