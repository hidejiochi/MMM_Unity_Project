using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MyoController : MonoBehaviour
{
	private Animator myAnimator;
	private Tween _moveTween;
	Vector3 targetPos = Vector3.zero;
	Vector2 fromSquare = Vector2.zero; 
    Vector2 targetSquare = Vector2.zero;
    public float _Length = 1f;
	[SerializeField]
	private Vector2 _currentSquare;

	private GameObject gem;
	Vector3 gemPos = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
		this.myAnimator = GetComponent<Animator> ();
		gem = GameObject.FindWithTag ("Gem");          
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) ||
		    Input.GetKeyDown (KeyCode.RightArrow) ||
		    Input.GetKeyDown (KeyCode.UpArrow) ||
		    Input.GetKeyDown (KeyCode.DownArrow)) {
			this.myAnimator.SetBool ("Walk", true);
		} else {
			this.myAnimator.SetBool ("Walk", false);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {            
			this.Move (MoveDirection.Up, 1);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {            
			this.Move (MoveDirection.Down, 1);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {            
			this.Move (MoveDirection.Right, 1);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {            
			this.Move (MoveDirection.Left, 1);
		}                                              
	}

	public void Move (MoveDirection direction, int num)
	{        
		//移動中なら
		if (_moveTween != null && _moveTween.IsPlaying ()) {
			//この先の処理を実行せずにリターン
			return;
		}        
		//1マス先の位置
		Vector2 targetSquare_1 = default(Vector2);
		//2マス先の位置
		Vector2 targetSquare_2 = default(Vector2);
		//1マス先の情報
		SquareInfo sqInfo_1 = null;
		//2マス先の情報
		SquareInfo sqInfo_2 = null;

		//動く方向による値の代入
		switch (direction) {
		case MoveDirection.Up:                
			//目標移動位置
			targetPos = transform.localPosition + new Vector3 (0, 0, _Length * num);
			//1つ上のマス目
			targetSquare_1 = _currentSquare + new Vector2 (0, 1);
			//2つ上のマス目
			targetSquare_2 = _currentSquare + new Vector2 (0, 2);
			//回転
			transform.DORotate (new Vector3 (0, 0, 0), 0.5f);                  
			break;

		case MoveDirection.Down:
			//目標移動位置
			targetPos = transform.localPosition + new Vector3 (0, 0, -_Length * num);                
			//1つ上のマス目
			targetSquare_1 = _currentSquare + new Vector2 (0, -1);
			//2つ上のマス目
			targetSquare_2 = _currentSquare + new Vector2 (0, -2);
			//回転
			transform.DORotate (new Vector3 (0, 180, 0), 0.5f);
			break;

		case MoveDirection.Right:
			//目標移動位置
			targetPos = transform.localPosition + new Vector3 (_Length * num, 0, 0);
			//1つ右のマス目
			targetSquare_1 = _currentSquare + new Vector2 (1, 0);
			//2つ右のマス目
			targetSquare_2 = _currentSquare + new Vector2 (2, 0);
			//回転
			transform.DORotate (new Vector3 (0, 90f, 0), 0.5f);
			break;

		case MoveDirection.Left:
			//目標移動位置
			targetPos = transform.localPosition + new Vector3 (-_Length * num, 0, 0);
			//1つ左のマス目
			targetSquare_1 = _currentSquare + new Vector2 (-1, 0);
			//2つ左のマス目
			targetSquare_2 = _currentSquare + new Vector2 (-2, 0);
			//回転
			transform.DORotate (new Vector3 (0, -90f, 0), 0.5f);
			break;
		}
		//1つ上のマス目の情報を取得
		sqInfo_1 = SquareManager.Instance.GetSquareInfomation (targetSquare_1);
		//2つ上のマス目の情報を取得
		sqInfo_2 = SquareManager.Instance.GetSquareInfomation (targetSquare_2);
		//動けるかどうかを判定
		if (CanMove (sqInfo_1, sqInfo_2)) {
			//移動アニメーションの実行
			_moveTween = transform.DOLocalMove (targetPos, 1.0f).SetEase (Ease.Linear)
			//移動が終了した時に走る処理
					.OnComplete (() => {
				//自分のマス目位置を更新
				_currentSquare = targetSquare_1;                 
			});
		}
	}

	/// <summary>
	/// キャラクターを動かせるかどうかの判定 
	/// </summary>
	/// <returns><c>true</c> if this instance can move the specified sqr_1 sqr_2; otherwise, <c>false</c>.</returns>
	/// <param name="sqr_1">Sqr 1.</param>
	/// <param name="sqr_2">Sqr 2.</param>
	private bool CanMove (SquareInfo sqInfo_1, SquareInfo sqInfo_2)
	{
		//進行方向の2つ先に何かオブジェクトが存在する時
		if (sqInfo_2 != null) {
			//1つ先に何もない時
			if (sqInfo_1.State == GameDefine.SquareState.EMPTY) {
				return true;
			}
			//1つ先がジェムで2つ先に空の時
			if (sqInfo_1.State == GameDefine.SquareState.GEM &&
			    sqInfo_2.State == GameDefine.SquareState.EMPTY) {
                //Gemを動かす処理
                GameObject gem = sqInfo_1.HasGameObject;
                SquareManager.Instance.Move(sqInfo_1.MySquare , sqInfo_2.MySquare , gem);
                _moveTween = gem.transform.DOLocalMove(sqInfo_2.Pos, 1.0f).SetEase(Ease.Linear);

                return true;
			}
		}
		//壁に向かって動こうとしている時
		else {
			return false;
		}
		//それ以外の時
		return false;
	}
}