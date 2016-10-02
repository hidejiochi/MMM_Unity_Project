using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MyoController : MonoBehaviour
{
    private Animator myAnimator;
    private Tween _moveTween;
    Vector3 targetPos = Vector3.zero;    
    Vector2 targetSquare=Vector2. zero;
    public float _Length = 1f;
    [SerializeField]
    private Vector2 _currentSquare;

    private GameObject gem;
    Vector3 gemPos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        this.myAnimator = GetComponent<Animator>();
        gem = GameObject.FindWithTag("Gem");          
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            this.myAnimator.SetBool("Walk", true);
        }
        else
        {
            this.myAnimator.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {            
            this.Move(MoveDirection.Up, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {            
            this.Move(MoveDirection.Down, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {            
            this.Move(MoveDirection.Right, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {            
            this.Move(MoveDirection.Left, 1);
        }                                              
    }
     
    public void Move(MoveDirection direction, int num)
    {        
        if (_moveTween !=null&&_moveTween .IsPlaying())
        {
            return;
        }        
        switch (direction)
        {
            case MoveDirection.Up:                
                targetPos = transform.localPosition + new Vector3(0, 0, _Length * num);
                //1つ上のマス目
                Vector2 targetSquareUp_1 = _currentSquare + new Vector2(0, 1);
                //2つ上のマス目
                Vector2 targetSquareUp_2 = _currentSquare + new Vector2(0, 2);
                //1つ上のマス目の情報を取得
                SquareInfo sqInfoUp_1 = SquareManager.Instance.GetSquareInfomation(targetSquareUp_1);
                //2つ上のマス目の情報を取得
                SquareInfo sqInfoUp_2 = SquareManager.Instance.GetSquareInfomation(targetSquareUp_2);
                //（動く）1つ前に何もない または 1つ前が壁じゃなければ
                if (sqInfoUp_1.hasGameObject == null || sqInfoUp_1.hasGameObject.tag != "Wall" )                    
                {                    
                    _moveTween = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.Linear);
                    _currentSquare += new Vector2(0, (float)num);                    
                }
                //（動く）1つ前がGem　かつ、２つ前がnull
                else if (sqInfoUp_1.hasGameObject.tag == "Gem" && sqInfoUp_1.hasGameObject == null)
                {

                }

                //（止まる）1つ前がnullじゃない または 1つ前が壁
                else if (sqInfoUp_1.hasGameObject != null || sqInfoUp_1.hasGameObject.tag == "Wall")
                {                    
                                      
                }
                //（止まる）1つ前がGem　かつ、２つ前がGem
                else if (sqInfoUp_1.hasGameObject.tag == "Gem" && sqInfoUp_2.hasGameObject.tag == "Gem")
                {

                }
                //（止まる）1つ前がGem　かつ、２つ前が壁
                else if (sqInfoUp_1.hasGameObject.tag == "Gem" && sqInfoUp_2.hasGameObject.tag == "Wall")
                {

                }

                transform.DORotate(new Vector3(0, 0, 0), 0.5f);                  
                break;

            case MoveDirection.Down:
                targetPos = transform.localPosition + new Vector3(0, 0, -_Length * num);                
                Vector2 targetSquare_2 = _currentSquare + new Vector2(0, -1);
                SquareInfo sqInfoDown_1 = SquareManager.Instance.GetSquareInfomation(targetSquare_2);
                if (sqInfoDown_1.hasGameObject == null || sqInfoDown_1.hasGameObject.tag != "Wall")
                {
                    _moveTween = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.Linear);
                    _currentSquare += new Vector2(0, -(float)num);
                }
                else if (sqInfoDown_1.hasGameObject != null || sqInfoDown_1.hasGameObject.tag == "Wall")
                {

                }
                transform.DORotate(new Vector3(0, 180, 0), 0.5f);
                break;

            case MoveDirection.Right:
                targetPos = transform.localPosition + new Vector3(_Length * num, 0, 0);
                Vector2 targetSquare_3 = _currentSquare + new Vector2(1, 0);
                SquareInfo sqInfo_3 = SquareManager.Instance.GetSquareInfomation(targetSquare_3);
                if (sqInfo_3.hasGameObject == null || sqInfo_3.hasGameObject.tag != "Wall")
                {
                    _moveTween = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.Linear);
                    _currentSquare += new Vector2((float)num, 0);
                }
                else if (sqInfo_3.hasGameObject != null || sqInfo_3.hasGameObject.tag == "Wall")
                {

                }
                transform.DORotate(new Vector3(0, 90f, 0), 0.5f);
                break;

            case MoveDirection.Left:
                targetPos = transform.localPosition + new Vector3(-_Length * num, 0, 0);
                Vector2 targetSquare_4 = _currentSquare + new Vector2(-1, 0);
                SquareInfo sqInfo_4 = SquareManager.Instance.GetSquareInfomation(targetSquare_4);
                if (sqInfo_4.hasGameObject == null || sqInfo_4.hasGameObject.tag != "Wall")
                {
                    _moveTween = transform.DOLocalMove(targetPos, 1.0f).SetEase(Ease.Linear);
                    _currentSquare += new Vector2(-(float)num, 0);
                }
                else if (sqInfo_4.hasGameObject != null || sqInfo_4.hasGameObject.tag == "Wall")
                {

                }
                transform.DORotate(new Vector3(0, -90f, 0), 0.5f);
                break;
        }
    }
}