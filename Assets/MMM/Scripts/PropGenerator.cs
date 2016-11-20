using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PropGenerator : MonoBehaviour
{
    public GameObject WallPrefab;
    public GameObject SquarePrefab;
    public GameObject CrossPrefab;
    public GameObject CubePrefab;
    public GameObject HeartPrefab;
    public GameObject PyramidPrefab;
    public GameObject PipePrefab;
    public GameObject SolidPrefab;
    public GameObject StarPrefab;
    public GameObject TorusPrefab;
    public GameObject MyoPrefab;

    [SerializeField]
    private Vector2 _myoInitialSquare;

    /// <summary>
    /// (0,0)のマス目の位置 
    /// </summary>
    [SerializeField]
    private Vector3 _squareStartPosition = new Vector3(-11f, 0, -11f);
    /// <summary>
    /// 11 x 11のマス目 
    /// </summary>
    [SerializeField]
    private Vector2 _maxSquare = new Vector2(11, 11);
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
    private List<Vector3> _crossPositionList;

    [SerializeField]
    private List<Vector3> _cubePositionList;

    [SerializeField]
    private List<Vector3> _heartPositionList;

    [SerializeField]
    private List<Vector3> _pyramidPositionList;

    [SerializeField]
    private List<Vector3> _pipePositionList;

    [SerializeField]
    private List<Vector3> _solidPositionList;

    [SerializeField]
    private List<Vector3> _starPositionList;

    [SerializeField]
    private List<Vector3> _torusPositionList;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        //キャラの生成
        GameObject myoObj = Instantiate(MyoPrefab);
        myoObj.transform.position = SquareConvertToPosition(_myoInitialSquare);
        MyoController myoController = myoObj.GetComponent<MyoController>();
        myoController.CurrentSquare = _myoInitialSquare;
        myoController.GameButtonInitialize();
        //ブロックの生成
        for (float y = 0; y <= _maxSquare.y; y++)
        {
            for (float x = 0; x <= _maxSquare.x; x++)
            {
                //座標位置
                Vector3 pos = _squareStartPosition + new Vector3(x * _squareLength, 0, y * _squareLength);
                //マス目位置
                Vector2 square = new Vector2(x, y);
                //マス目の情報クラスを生成
                SquareInfo squareInfo = new SquareInfo(pos, square);
                //ディクショナリーに要素を追加
                SquareManager.Instance.SquareDictionary.Add(square, squareInfo);

                //壁を配置する条件
                if ((y == 0 || y == _maxSquare.y) || x == 0 || x == _maxSquare.x)
                {
                    CreatePrefab(WallPrefab, pos, new Vector2(x, y));
                }
                //Squareの配置
                //指定した位置がリスト内に含まれていれば
                if (_squarePositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(SquarePrefab, pos, new Vector2(x, y));

                }
                if (_crossPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(CrossPrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_cubePositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(CubePrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_heartPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(HeartPrefab, pos, new Vector2(x, y));
                    Gem gem = obj.GetComponent<Gem>();
                    //マネージャーに加える
                    GemManager.Instance.Add(gem);
                }
                if (_pyramidPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(PyramidPrefab, pos, new Vector2(x, y));
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
                if (_starPositionList.Contains(pos))
                {
                    GameObject obj = CreatePrefab(StarPrefab, pos, new Vector2(x, y));
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
    /// Squares the convert to position.
    /// </summary>
    /// <returns>The convert to position.</returns>
    /// <param name="square">Square.</param>
    private Vector3 SquareConvertToPosition(Vector2 square)
    {
        return _squareStartPosition + new Vector3(square.x * _squareLength, 0, square.y * _squareLength);
    }

    //==============Inspector拡張の記述開始================//

#if UNITY_EDITOR
    [SerializeField]
    private Transform _editorParent;

    [CustomEditor(typeof(PropGenerator))]               //!< 拡張するときのお決まりとして書いてね
    public class PropGeneratorEditor : Editor           //!< Editorを継承するよ！
    {
        /// <summary>
        /// この関数は１秒間に何回も呼ばれます 
        /// </summary>
        public override void OnInspectorGUI()
        {
            //インスペクタの表示を上書きしない
            DrawDefaultInspector();
            //PropGeneratorのインスタンスを取得
            PropGenerator p = target as PropGenerator;
            //EditorParentがnullなら作成する
            if (p._editorParent == null)
            {
                GameObject parentObj = new GameObject();
                parentObj.name = "【Editor Parent】";
                p._editorParent = parentObj.transform;
            }
            //再生したら削除
            if (EditorApplication.isPlaying)
            {
                GameObject parentObj = GameObject.Find("【Editor Parent】");
                if (parentObj != null)
                {
                    Destroy(parentObj);
                }
                return;
            }
            //シリアライズフィールドを更新
            serializedObject.Update();
            //EditorParent内のゲームオブジェクトを全部削除
            foreach (Transform t in p._editorParent)
            {
                if (t.gameObject == null)
                {
                    continue;
                }
                GameObject.DestroyImmediate(t.gameObject);
            }
            //EditorParent以下にゲームオブジェクトを生成する
            //キャラの生成
            GameObject myoObj = PrefabUtility.InstantiatePrefab(p.MyoPrefab) as GameObject;
            myoObj.transform.SetParent(p._editorParent);
            myoObj.transform.position = p.SquareConvertToPosition(p._myoInitialSquare);
            //ブロックの生成
            for (float y = 0; y <= p._maxSquare.y; y++)
            {
                for (float x = 0; x <= p._maxSquare.x; x++)
                {
                    //座標位置
                    Vector3 pos = p._squareStartPosition + new Vector3(x * p._squareLength, 0, y * p._squareLength);
                    //壁を配置する条件
                    if ((y == 0 || y == p._maxSquare.y) || x == 0 || x == p._maxSquare.x)
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.WallPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    //Gemの配置
                    //指定した位置がリスト内に含まれていれば配置する
                    if (p._squarePositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.SquarePrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._crossPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.CrossPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._cubePositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.CubePrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._heartPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.HeartPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._pyramidPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.PyramidPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._pipePositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.PipePrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._solidPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.SolidPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._starPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.StarPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                    if (p._torusPositionList.Contains(pos))
                    {
                        //生成
                        GameObject obj = UnityEditor.PrefabUtility.InstantiatePrefab(p.TorusPrefab) as GameObject;
                        //親に設定
                        obj.transform.SetParent(p._editorParent);
                        //位置を設
                        obj.transform.position = pos;
                    }
                }
            }
            /* -- カスタム表示 -- */
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
    //==============Inspector拡張の記述終了================//
}
