using UnityEngine;
using System.Collections;
using System.Linq;

public class MyoRotate : MonoBehaviour
{

    /// <summary>回転対象</summary>
    public GameObject Cube;
    /// <summary>回転速度</summary>
    public float Speed = 0.01f;

    Rect _rect = new Rect(450, 1130, 900, 250);


    void Update()
    {
        //タッチ数取得(Linq使えた)
        int touchCount = Input.touches
            .Count(t => t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled);

        if (touchCount == 1)
        {
            Touch _touch = Input.GetTouch(0);
            Vector2 newVec = new Vector2(_touch.position.x,  _touch.position.y);

            //Rectとタッチの位置を判定
            if (newVec.x >= _rect.xMin &&
            newVec.x < _rect.xMax &&
            newVec.y >= _rect.yMin &&
            newVec.y < _rect.yMax)
            {

                Touch t = Input.touches.First();
                switch (t.phase)
                {
                    case TouchPhase.Moved:

                        //移動量に応じて角度計算
                        float xAngle = 0;
                        float yAngle = -t.deltaPosition.x * Speed * 10;
                        float zAngle = 0;

                        //回転
                        Cube.transform.Rotate(xAngle, yAngle, zAngle);

                        break;
                }
            }
        }
    }
}
