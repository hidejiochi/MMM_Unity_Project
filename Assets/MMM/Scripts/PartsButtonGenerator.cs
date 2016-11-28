using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartsButtonGenerator : MonoBehaviour {

    public TopPartsButton TopButtonPrefab;
    public ClothesPartsButton ClothesButtonPrefab; 
    public BodyPartsButton BodyButtonPrefab;
    public TailPartsButton TailButtonPrefab; 

    [SerializeField]
    private Transform _topContentTransform;
    [SerializeField]
    private Transform _clothesContentTransform; 
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

        //この中でCLOTHESパーツボタンを生成する
        ClothesPartsButton clothesParts0Button = Instantiate(ClothesButtonPrefab);
        //Scroll ViewのContentを親にする
        clothesParts0Button.transform.SetParent(_clothesContentTransform, false);
        clothesParts0Button.Initialize("clothes_0", "Clothes.0");

        //この中でBODYパーツボタンを生成する
        BodyPartsButton bodyParts0Button = Instantiate(BodyButtonPrefab);
        //Scroll ViewのContentを親にする
        bodyParts0Button.transform.SetParent(_bodyContentTransform, false);
        bodyParts0Button.Initialize("body_0" , "Body.0" );

        //この中でTAILパーツボタンを生成する
        TailPartsButton tailParts0Button = Instantiate(TailButtonPrefab);
        //Scroll ViewのContentを親にする
        tailParts0Button.transform.SetParent(_tailContentTransform, false);
        tailParts0Button.Initialize("tail_0" , "Tail.0");


        for (int i = 0; i < StageID.Instance.ClearList.Count; i++)
        {
            //クリアId
            var clearId = StageID.Instance.ClearList[i];
            //クリアした数
            int clearNum = i + 1;

            //クリア回数が5 または -5の値が20で割り切れる時
            if (clearNum == 5 || ((clearNum-5) % 20) == 0)
            {
                //この中でTOPパーツボタンを生成する
                TopPartsButton topPartsButton = Instantiate(TopButtonPrefab);
                //Scroll ViewのContentを親にする
                topPartsButton.transform.SetParent(_topContentTransform, false);
                //初期化
                string topPartsNum = ((clearNum + 15) / 20).ToString();
                topPartsButton.Initialize("top_" + topPartsNum, "Top." + topPartsNum);
            }
            //クリア回数が10 または +10の値が20で割り切れる時
            if (clearNum == 10 || ((clearNum + 10) % 20) == 0)
            {
                //この中でCLOTHESパーツボタンを生成する
                ClothesPartsButton clothesPartsButton = Instantiate(ClothesButtonPrefab);
                //Scroll ViewのContentを親にする
                clothesPartsButton.transform.SetParent(_clothesContentTransform, false);
                //初期化
                string clothesPartsNum = ((clearNum + 10)/20).ToString();
                clothesPartsButton.Initialize("clothes_" + clothesPartsNum, "Clothes."+clothesPartsNum);
            }
            //クリア回数が15 または +5の値が20で割り切れる時
            if (clearNum == 15 || ((clearNum + 5) % 20) == 0)
            {
                //この中でBODYパーツボタンを生成する
                BodyPartsButton bodyPartsButton = Instantiate(BodyButtonPrefab);
                //Scroll ViewのContentを親にする
                bodyPartsButton.transform.SetParent(_bodyContentTransform, false);
                //初期化
                string bodyPartsNum = ((clearNum + 5) / 20).ToString();
                bodyPartsButton.Initialize("body_" + bodyPartsNum, "Body." + bodyPartsNum);
            }
            //クリア回数が20で割り切れる時
            if ((clearNum % 20) == 0)
            {
                //この中でTAILパーツボタンを生成する
                TailPartsButton tailPartsButton = Instantiate(TailButtonPrefab);
                //Scroll ViewのContentを親にする
                tailPartsButton.transform.SetParent(_tailContentTransform, false);
                //初期化
                string tailPartsNum = (clearNum / 20).ToString();
                tailPartsButton.Initialize("tail_" + tailPartsNum, "Tail." + tailPartsNum);
            }
        }
                       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
