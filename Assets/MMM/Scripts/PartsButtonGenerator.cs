using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartsButtonGenerator : MonoBehaviour {

    public TopPartsButton TopButtonPrefab;
    public BodyPartsButton BodyButtonPrefab;

    [SerializeField]
    private Transform _topContentTransform;
    [SerializeField]
    private Transform _bodyContentTransform;
    

    // Use this for initialization
    void Start () {
        //クリアした数
        int clearNum = StageID.Instance.SaveList.Count;    
        //クリアした数を10で割った余りの数
        int remainderNum = clearNum % 10;
        //クリア数を10で割った商
        int quotientNum = clearNum / 10;

        //クリア回数が0ではなく　かつ 10で割り切れたら
        if (clearNum != 0 && remainderNum == 0)
        {

            //商が偶数なら
            if ((quotientNum % 2) == 0)
            {
                //この中でTOPパーツボタンを生成する
                TopPartsButton topPartsButton = Instantiate(TopButtonPrefab);
                //Scroll ViewのContentを親にする
                topPartsButton.transform.SetParent(_topContentTransform, false);
                //初期化
                string topPartsNum = (quotientNum  / 2).ToString();
                topPartsButton.Initialize("Top00", "Top." + topPartsNum);
            }
            //商が奇数なら
            else
            {
                //この中でBODYパーツボタンを生成する
                BodyPartsButton bodyPartsButton = Instantiate(BodyButtonPrefab);
                //Scroll ViewのContentを親にする
                bodyPartsButton.transform.SetParent(_bodyContentTransform, false);
                //初期化
                string bodyPartsNum = ((quotientNum + 1)/2).ToString();
                bodyPartsButton.Initialize("Body00", "Body."+bodyPartsNum);
            }
        }
                       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
