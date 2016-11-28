using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartsButtonGenerator : MonoBehaviour {

    public TopPartsButton TopButtonPrefab;
    public BodyPartsButton BodyButtonPrefab;
    public TailPartsButton TailButtonPrefab; 

    [SerializeField]
    private Transform _topContentTransform;
    [SerializeField]
    private Transform _bodyContentTransform;
    [SerializeField]
    private Transform _tailContentTransform; 


    // Use this for initialization
    void Start () {

        //この中でTOPパーツボタンを生成する
        TopPartsButton topParts0Button = Instantiate(TopButtonPrefab);
        //Scroll ViewのContentを親にする
        topParts0Button.transform.SetParent(_topContentTransform, false);
        topParts0Button.Initialize("top_0", "Top.0" );

        //この中でBODYパーツボタンを生成する
        BodyPartsButton bodyParts0Button = Instantiate(BodyButtonPrefab);
        //Scroll ViewのContentを親にする
        bodyParts0Button.transform.SetParent(_bodyContentTransform, false);
        bodyParts0Button.Initialize("body_0" , "Body.0" );

        //この中でBODYパーツボタンを生成する
        TailPartsButton tailParts0Button = Instantiate(TailButtonPrefab);
        //Scroll ViewのContentを親にする
        tailParts0Button.transform.SetParent(_tailContentTransform, false);
        tailParts0Button.Initialize("tail_0" , "Tail.0");


        //クリアした数
        int clearNum = StageID.Instance.ClearList.Count;    
        //クリアした数を10で割った余りの数
        int remainderNum = clearNum % 10;
        //クリア数を10で割った商
        int quotientNum = clearNum / 10;

        //クリア回数が0ではなく　かつ 10で割り切れたら
        if (clearNum != 0 && remainderNum == 0)
        {

            //商+2が3で割り切れたら
            if (((quotientNum+2) % 3) == 0)
            {
                //この中でTOPパーツボタンを生成する
                TopPartsButton topPartsButton = Instantiate(TopButtonPrefab);
                //Scroll ViewのContentを親にする
                topPartsButton.transform.SetParent(_topContentTransform, false);
                //初期化
                string topPartsNum = ((quotientNum + 2) / 3).ToString();
                topPartsButton.Initialize("top_" + topPartsNum, "Top." + topPartsNum);
            }
            //商+1が3で割り切れたら
            if (((quotientNum + 1) % 3) == 0)
            {
                //この中でBODYパーツボタンを生成する
                BodyPartsButton bodyPartsButton = Instantiate(BodyButtonPrefab);
                //Scroll ViewのContentを親にする
                bodyPartsButton.transform.SetParent(_bodyContentTransform, false);
                //初期化
                string bodyPartsNum = ((quotientNum + 1)/3).ToString();
                bodyPartsButton.Initialize("body_" + bodyPartsNum, "Body."+bodyPartsNum);
            }
            //商が3で割り切れたら
            if ((quotientNum % 3) == 0)
            {
                //この中でBODYパーツボタンを生成する
                TailPartsButton tailPartsButton = Instantiate(TailButtonPrefab);
                //Scroll ViewのContentを親にする
                tailPartsButton.transform.SetParent(_tailContentTransform, false);
                //初期化
                string tailPartsNum = (quotientNum  / 3).ToString();
                tailPartsButton.Initialize("tail_" + tailPartsNum, "Tail." + tailPartsNum);
            }
        }
                       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
