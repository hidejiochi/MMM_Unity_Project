using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;


public class MyoController : MonoBehaviour
{
    private Animator myAnimator;
    private GameObject nextStageButton;
    private Tween _moveTween;
    Vector3 targetPos = Vector3.zero;
    public float _Speed = 1f;
    public float _roSpeed = 1f;
    public float _Length = 1f;
    [SerializeField]
    private Vector2 _currentSquare;

    public Vector2 CurrentSquare
    {
        set { _currentSquare = value; }
        get { return _currentSquare; }
    }

    [SerializeField]
    private string stageId;
    [SerializeField]
    private MyoControlButton _upButton;
    [SerializeField]
    private MyoControlButton _downButton;
    [SerializeField]
    private MyoControlButton _rightButton;
    [SerializeField]
    private MyoControlButton _leftButton;

    Vector2 gemSquareUp_1 = default(Vector2);
    Vector2 gemSquareUp_2 = default(Vector2);
    Vector2 gemSquareDown_1 = default(Vector2);
    Vector2 gemSquareDown_2 = default(Vector2);
    SquareInfo GEMsqInfoUp_1 = null;
    SquareInfo GEMsqInfoUp_2 = null;
    SquareInfo GEMsqInfoDown_1 = null;
    SquareInfo GEMsqInfoDown_2 = null;
    Vector2 gemSquareRight_1 = default(Vector2);
    Vector2 gemSquareRight_2 = default(Vector2);
    Vector2 gemSquareLeft_1 = default(Vector2);
    Vector2 gemSquareLeft_2 = default(Vector2);
    SquareInfo GEMsqInfoRight_1 = null;
    SquareInfo GEMsqInfoRight_2 = null;
    SquareInfo GEMsqInfoLeft_1 = null;
    SquareInfo GEMsqInfoLeft_2 = null;



    private bool isUpButtonDown = false;
    private bool isDownButtonDown = false;
    private bool isRightButtonDown = false;
    private bool isLeftButtonDown = false;
    private bool isActionButtonDown = false;
    private bool isGemRemoving = false;

    private IEnumerator LateAction(float second, Action action)
    {
        yield return new WaitForSeconds(second);
        action();
    }
                
    // Use this for initialization

    void Awake() 
    {
        this.myAnimator = GetComponent<Animator>();
        stageId = SceneManager.GetActiveScene().name;
        this.nextStageButton = GameObject.Find("NextStageButton");
    }

    /// <summary>
    /// Games the button initialize.
    /// </summary>
    public void GameButtonInitialize()
    {
        //ボタンの初期化
        GameObject.Find("UpButton").GetComponent<MyoControlButton>().Initialize(GetMyUpButtonDown, GetMyUpButtonUp, GetMyUpButtonExit);
        GameObject.Find("DownButton").GetComponent<MyoControlButton>().Initialize(GetMyDownButtonDown, GetMyDownButtonUp, GetMyDownButtonExit);
        GameObject.Find("RightButton").GetComponent<MyoControlButton>().Initialize(GetMyRightButtonDown, GetMyRightButtonUp, GetMyRightButtonExit);
        GameObject.Find("LeftButton").GetComponent<MyoControlButton>().Initialize(GetMyLeftButtonDown, GetMyLeftButtonUp, GetMyLeftButtonExit);
    }

    /// <summary>
    /// Sets the animation.
    /// </summary>
    public void SetAnimation(string animationName)
    {
        myAnimator.SetTrigger(animationName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow)
            || this.isUpButtonDown || this.isDownButtonDown || this.isRightButtonDown || this.isLeftButtonDown)
        {
            this.myAnimator.SetBool("Walk", true);
        }
        else
        {
            this.myAnimator.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.S) || this.isActionButtonDown)
        {
            //配列
            string[] aniState = new string[] { "Box", "Wait", "Salute", "Wave", "Stretch", "Stomp", "Jump", "Fall" };
            //アニメーションの名前を取り出す
            string stateName = aniState[UnityEngine.Random.Range(0, aniState.Length)];
            this.myAnimator.SetTrigger(stateName);
            this.isActionButtonDown = false;
        }


        if (Input.GetKey(KeyCode.UpArrow) || this.isUpButtonDown)
        {
            if (isGemRemoving)
            {
                return;
            }
            this.Move(MoveDirection.Up, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow) || this.isDownButtonDown)
        {
            if (isGemRemoving)
            {
                return;
            }
            this.Move(MoveDirection.Down, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) || this.isRightButtonDown)
        {
            if (isGemRemoving)
            {
                return;
            }
            this.Move(MoveDirection.Right, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || this.isLeftButtonDown)
        {
            if (isGemRemoving)
            {
                return;
            }
            this.Move(MoveDirection.Left, 1);
        }

    }
    //===押してたボタンの範囲外に指がいってしまった時===//
    public void GetMyLeftButtonExit()
    {
        this.isLeftButtonDown = false;
    }

    public void GetMyDownButtonExit()
    {
        this.isDownButtonDown = false;
    }

    public void GetMyRightButtonExit()
    {
        this.isRightButtonDown = false;
    }

    public void GetMyUpButtonExit()
    {
        this.isUpButtonDown = false;
    }

    //上ボタンを押し続けた場合の処理
    public void GetMyUpButtonDown()
    {
        this.isUpButtonDown = true;
    }
    //上ボタンを離した場合の処理
    public void GetMyUpButtonUp()
    {
        this.isUpButtonDown = false;
    }

    //下ボタンを押し続けた場合の処理
    public void GetMyDownButtonDown()
    {
        this.isDownButtonDown = true;
    }
    //下ボタンを離した場合の処理
    public void GetMyDownButtonUp()
    {
        this.isDownButtonDown = false;
    }
    //左ボタンを押し続けた場合の処理
    public void GetMyLeftButtonDown()
    {
        this.isLeftButtonDown = true;
    }
    //左ボタンを離した場合の処理
    public void GetMyLeftButtonUp()
    {
        this.isLeftButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理
    public void GetMyRightButtonDown()
    {
        this.isRightButtonDown = true;
    }
    //右ボタンを離した場合の処理
    public void GetMyRightButtonUp()
    {
        this.isRightButtonDown = false;
    }

    //アクションボタンを押し続けた場合の処理
    public void GetMyActionButtonDown()
    {
        this.isActionButtonDown = true;
    }
    //アクションボタンを離した場合の処理
    public void GetMyActionButtonUp()
    {
        this.isActionButtonDown = false;
    }

    public void Move(MoveDirection direction, int num)
    {
        //移動中なら
        if (_moveTween != null && _moveTween.IsPlaying())
        {
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
        switch (direction)
        {
            case MoveDirection.Up:
                //目標移動位置
                targetPos = transform.localPosition + new Vector3(0, 0, _Length * num);
                //1つ上のマス目
                targetSquare_1 = _currentSquare + new Vector2(0, 1);
                //2つ上のマス目
                targetSquare_2 = _currentSquare + new Vector2(0, 2);
                //回転
                transform.DORotate(new Vector3(0, 0, 0), _roSpeed);
                break;

            case MoveDirection.Down:
                //目標移動位置
                targetPos = transform.localPosition + new Vector3(0, 0, -_Length * num);
                //1つ下のマス目
                targetSquare_1 = _currentSquare + new Vector2(0, -1);
                //2つ下のマス目
                targetSquare_2 = _currentSquare + new Vector2(0, -2);
                //回転
                transform.DORotate(new Vector3(0, 180, 0), _roSpeed);
                break;

            case MoveDirection.Right:
                //目標移動位置
                targetPos = transform.localPosition + new Vector3(_Length * num, 0, 0);
                //1つ右のマス目
                targetSquare_1 = _currentSquare + new Vector2(1, 0);
                //2つ右のマス目
                targetSquare_2 = _currentSquare + new Vector2(2, 0);
                //回転
                transform.DORotate(new Vector3(0, 90f, 0), _roSpeed);
                break;

            case MoveDirection.Left:
                //目標移動位置
                targetPos = transform.localPosition + new Vector3(-_Length * num, 0, 0);
                //1つ左のマス目
                targetSquare_1 = _currentSquare + new Vector2(-1, 0);
                //2つ左のマス目
                targetSquare_2 = _currentSquare + new Vector2(-2, 0);
                //回転
                transform.DORotate(new Vector3(0, -90f, 0), _roSpeed);
                break;
        }
        //1つ先のマス目の情報を取得
        sqInfo_1 = SquareManager.Instance.GetSquareInfomation(targetSquare_1);
        //2つ先のマス目の情報を取得
        sqInfo_2 = SquareManager.Instance.GetSquareInfomation(targetSquare_2);

        //動けるかどうかを判定
        if (CanMove(sqInfo_1, sqInfo_2))
        {
            //移動アニメーションの実行
            _moveTween = transform.DOLocalMove(targetPos, _Speed).SetEase(Ease.Linear)
                    //移動が終了した時に走る処理
                    .OnComplete(() => {
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
    private bool CanMove(SquareInfo sqInfo_1, SquareInfo sqInfo_2)
    {
        //進行方向の2つ先に何かオブジェクトが存在する時
        if (sqInfo_2 != null)
        {
            //1つ先に何もない時
            if (sqInfo_1.State == GameDefine.SquareState.EMPTY)
            {
                return true;
            }
            //1つ先がジェムで2つ先に空の時
            if (sqInfo_1.State == GameDefine.SquareState.GEM &&
                sqInfo_2.State == GameDefine.SquareState.EMPTY)
            {
                //Gemを動かす処理
                GameObject gem = sqInfo_1.HasGameObject;
                SquareManager.Instance.Move(sqInfo_1.MySquare, sqInfo_2.MySquare, gem);
                _moveTween = gem.transform.DOLocalMove(sqInfo_2.Pos, _Speed).SetEase(Ease.Linear).OnComplete(() => {
                    //Gem_1の1マス上の位置
                    gemSquareUp_1 = sqInfo_2.MySquare + new Vector2(0, 1);
                    //Gem_1の2マス上の位置
                    gemSquareUp_2 = sqInfo_2.MySquare + new Vector2(0, 2);
                    //Gem_1の1マス下の位置
                    gemSquareDown_1 = sqInfo_2.MySquare + new Vector2(0, -1);
                    //Gem_1の2マス下の位置
                    gemSquareDown_2 = sqInfo_2.MySquare + new Vector2(0, -2);
                    //Gem_1の1マス上の情報を取得
                    GEMsqInfoUp_1 = SquareManager.Instance.GetSquareInfomation(gemSquareUp_1);
                    //Gem_1の2マス上の情報を取得
                    GEMsqInfoUp_2 = SquareManager.Instance.GetSquareInfomation(gemSquareUp_2);
                    //Gem_1の1マス下の情報を取得
                    GEMsqInfoDown_1 = SquareManager.Instance.GetSquareInfomation(gemSquareDown_1);
                    //Gem_1の2マス下の情報を取得
                    GEMsqInfoDown_2 = SquareManager.Instance.GetSquareInfomation(gemSquareDown_2);
                    //Gem_1の1マス上かつ2マス上がGEMのとき
                    if (GEMsqInfoUp_1.State == GameDefine.SquareState.GEM && GEMsqInfoUp_2.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス上の位置にあるGem
                        Gem g_up1 = GEMsqInfoUp_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の2マス上の位置にあるGem
                        Gem g_up2 = GEMsqInfoUp_2.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ上のGem、2つ上のGemのタイプが同じなら
                        if (g.Type == g_up1.Type && g.Type == g_up2.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_up1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_up2.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                //動かしたGemのマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                //Gem_1の1マス上のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareUp_1);
                                //Gem_1の2マス上のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareUp_2);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_up1);
                                GemManager.Instance.Remove(g_up2);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;

                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);
                                    
                                    
                                }
                            }));
                        }
                    }
                    //Gem_1の1マス上かつ１マス下がGEMのとき
                    if (GEMsqInfoUp_1.State == GameDefine.SquareState.GEM && GEMsqInfoDown_1.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス上の位置にあるGem
                        Gem g_up1 = GEMsqInfoUp_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の1マス下の位置にあるGem
                        Gem g_Down1 = GEMsqInfoDown_1.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ上のGem、1つ下のGemのタイプが同じなら
                        if (g.Type == g_up1.Type && g.Type == g_Down1.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_up1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Down1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                //動かしたGemのマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                //Gem_1の1マス上のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareUp_1);
                                //Gem_1の1マス下のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareDown_1);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_up1);
                                GemManager.Instance.Remove(g_Down1);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;

                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);

                                }
                            }));
                        }
                    }
                    //Gem_1の1マス下かつ2マス下がGEMのとき
                    if (GEMsqInfoDown_1.State == GameDefine.SquareState.GEM && GEMsqInfoDown_2.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス下の位置にあるGem
                        Gem g_Down1 = GEMsqInfoDown_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の2マス下の位置にあるGem
                        Gem g_Down2 = GEMsqInfoDown_2.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ下のGem、2つ下のGemのタイプが同じなら
                        if (g.Type == g_Down1.Type && g.Type == g_Down2.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Down1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Down2.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                SquareManager.Instance.RemoveGameObject(gemSquareDown_1);
                                SquareManager.Instance.RemoveGameObject(gemSquareDown_2);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_Down1);
                                GemManager.Instance.Remove(g_Down2);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;

                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);

                                }
                            }));
                        }
                    }
                    //Gem_1の1マス右の位置
                    gemSquareRight_1 = sqInfo_2.MySquare + new Vector2(1, 0);
                    //Gem_1の2マス右の位置
                    gemSquareRight_2 = sqInfo_2.MySquare + new Vector2(2, 0);
                    //Gem_1の1マス左の位置
                    gemSquareLeft_1 = sqInfo_2.MySquare + new Vector2(-1, 0);
                    //Gem_1の2マス左の位置
                    gemSquareLeft_2 = sqInfo_2.MySquare + new Vector2(-2, 0);
                    //Gem_1の1マス右の情報を取得
                    GEMsqInfoRight_1 = SquareManager.Instance.GetSquareInfomation(gemSquareRight_1);
                    //Gem_1の2マス右の情報を取得
                    GEMsqInfoRight_2 = SquareManager.Instance.GetSquareInfomation(gemSquareRight_2);
                    //Gem_1の1マス左の情報を取得
                    GEMsqInfoLeft_1 = SquareManager.Instance.GetSquareInfomation(gemSquareLeft_1);
                    //Gem_1の2マス左の情報を取得
                    GEMsqInfoLeft_2 = SquareManager.Instance.GetSquareInfomation(gemSquareLeft_2);
                    //Gem_1の1マス右かつ2マス右がGEMのとき
                    if (GEMsqInfoRight_1.State == GameDefine.SquareState.GEM && GEMsqInfoRight_2.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス右の位置にあるGem
                        Gem g_Right1 = GEMsqInfoRight_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の2マス右の位置にあるGem
                        Gem g_Right2 = GEMsqInfoRight_2.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ右のGem、2つ右のGemのタイプが同じなら
                        if (g.Type == g_Right1.Type && g.Type == g_Right2.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Right1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Right2.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                //動かしたGemのマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                //Gem_1の1マス右のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareRight_1);
                                //Gem_1の2マス右のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareRight_2);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_Right1);
                                GemManager.Instance.Remove(g_Right2);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;

                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);

                                }
                            }));
                        }
                    }
                    //Gem_1の1マス右かつ１マス左がGEMのとき
                    if (GEMsqInfoRight_1.State == GameDefine.SquareState.GEM && GEMsqInfoLeft_1.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス右の位置にあるGem
                        Gem g_Right1 = GEMsqInfoRight_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の1マス左の位置にあるGem
                        Gem g_Left1 = GEMsqInfoLeft_1.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ右のGem、1つ左のGemのタイプが同じなら
                        if (g.Type == g_Right1.Type && g.Type == g_Left1.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Right1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Left1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                //動かしたGemのマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                //Gem_1の1マス右のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareRight_1);
                                //Gem_1の1マス左のマス目の情報を消去する
                                SquareManager.Instance.RemoveGameObject(gemSquareLeft_1);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_Right1);
                                GemManager.Instance.Remove(g_Left1);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;

                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);

                                }
                            }));
                        }
                    }
                    //Gem_1の1マス左かつ2マス左がGEMのとき
                    if (GEMsqInfoLeft_1.State == GameDefine.SquareState.GEM && GEMsqInfoLeft_2.State == GameDefine.SquareState.GEM)
                    {
                        //動かしたGem
                        Gem g = gem.GetComponent<Gem>();
                        //Gem_1の1マス左の位置にあるGem
                        Gem g_Left1 = GEMsqInfoLeft_1.HasGameObject.GetComponent<Gem>();
                        //Gem_1の2マス左の位置にあるGem
                        Gem g_Left2 = GEMsqInfoLeft_2.HasGameObject.GetComponent<Gem>();
                        //動かしたGemと1つ左のGem、2つ左のGemのタイプが同じなら
                        if (g.Type == g_Left1.Type && g.Type == g_Left2.Type)
                        {
                            //Gemを消している最中
                            isGemRemoving = true;
                            g.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Left1.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                            g_Left2.transform.DORotate(new Vector3(0, 180, 0), 0.5f);

                            StartCoroutine(LateAction(0.5f, () => {
                                //0.5秒後に処理が行われる
                                //音を鳴らす
                                PlaySoundGem.Instance.playSoundGem();
                                SquareManager.Instance.RemoveGameObject(sqInfo_2.MySquare);
                                SquareManager.Instance.RemoveGameObject(gemSquareLeft_1);
                                SquareManager.Instance.RemoveGameObject(gemSquareLeft_2);
                                //マネージャーから消す                               
                                GemManager.Instance.Remove(g);
                                GemManager.Instance.Remove(g_Left1);
                                GemManager.Instance.Remove(g_Left2);
                                //Gemを消している最中判定をfalse
                                isGemRemoving = false;
                                
                                //StageIDの処理
                                if (GemManager.Instance.IsClear())
                                {
                                    PlaySoundClear.Instance.playSoundClear();
                                    GemManager.Instance.OnClear();
                                    StageID.Instance.StageClear(stageId);
                                    this.myAnimator.SetTrigger("Jump");
                                    nextStageButton.transform.DOLocalMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.InOutQuart);

                                }
                            }));
                        }
                    }


                });

                return true;
            }
        }
        //壁に向かって動こうとしている時
        else
        {
            return false;
        }
        //それ以外の時
        return false;
    }
}