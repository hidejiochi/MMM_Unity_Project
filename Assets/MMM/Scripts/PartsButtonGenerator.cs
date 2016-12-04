using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PartsButtonGenerator : MonoBehaviour
{

    public TopPartsButton TopButtonPrefab;
    public ClothesPartsButton ClothesButtonPrefab;
    public BodyPartsButton BodyButtonPrefab;
    public TailPartsButton TailButtonPrefab;

    [SerializeField]
    private List<TopPartsButton> _topButtonList;

    [SerializeField]
    private Transform _topContentTransform;
    [SerializeField]
    private Transform _clothesContentTransform;
    [SerializeField]
    private Transform _bodyContentTransform;
    [SerializeField]
    private Transform _tailContentTransform;


    // Use this for initialization
    void Start()
    {

        //この中でTOPパーツボタンを生成する
        TopPartsButton topParts0Button = Instantiate(TopButtonPrefab);
        //Scroll ViewのContentを親にする
        topParts0Button.transform.SetParent(_topContentTransform, false);
        topParts0Button.Initialize("top_0", "Top.0");
        //リストに追加
        _topButtonList.Add(topParts0Button);
        //===初期の色を設定===
        //現在装着しているメッシュと同じIdなら
        if (MyoCustom.Instance.TopMeshRenderer.sharedMesh.name == "top_0")
        {
            topParts0Button.Button.image.color = Color.green;
        }
        else
        {
            topParts0Button.Button.image.color = Color.white;
        }
        //クリックされた時のイベントを登録
        topParts0Button.Button.onClick.AddListener(() => {
            //着せ替えの関数を実行
            MyoCustom.Instance.ChangeParts("top_0");
            //ボタンのリストを回す
            for (int j = 0; j < _topButtonList.Count; j++)
            {
                var btn = _topButtonList[j].Button;
                //選択されたボタンが自分自身のボタンなら
                if (btn == topParts0Button.Button)
                {
                    //選択された時の色を設定する
                    btn.image.color = Color.green;
                }
                else
                {
                    //それ以外の色を選択する
                    btn.image.color = Color.white;
                }
            }
        });

        //この中でCLOTHESパーツボタンを生成する
        ClothesPartsButton clothesParts0Button = Instantiate(ClothesButtonPrefab);
        //Scroll ViewのContentを親にする
        clothesParts0Button.transform.SetParent(_clothesContentTransform, false);
        clothesParts0Button.Initialize("clothes_0", "Clothes.0");

        //この中でBODYパーツボタンを生成する
        BodyPartsButton bodyParts0Button = Instantiate(BodyButtonPrefab);
        //Scroll ViewのContentを親にする
        bodyParts0Button.transform.SetParent(_bodyContentTransform, false);
        bodyParts0Button.Initialize("body_0", "Body.0");

        //この中でTAILパーツボタンを生成する
        TailPartsButton tailParts0Button = Instantiate(TailButtonPrefab);
        //Scroll ViewのContentを親にする
        tailParts0Button.transform.SetParent(_tailContentTransform, false);
        tailParts0Button.Initialize("tail_0", "Tail.0");


        for (int i = 0; i < StageID.Instance.ClearList.Count; i++)
        {
            //クリアId
            var clearId = StageID.Instance.ClearList[i];
            //クリアした数
            int clearNum = i + 1;

            //クリア回数が5 または -5の値が20で割り切れる時
            if (clearNum == 5 || ((clearNum - 5) % 20) == 0)
            {
                //この中でTOPパーツボタンを生成する
                TopPartsButton topPartsButton = Instantiate(TopButtonPrefab);
                //Scroll ViewのContentを親にする
                topPartsButton.transform.SetParent(_topContentTransform, false);
                //初期化
                string topPartsNum = ((clearNum + 15) / 20).ToString();
                //Mesh と MaterialのId
                string id = "top_" + topPartsNum;
                //初期化
                topPartsButton.Initialize(id, "Top." + topPartsNum);
                //リストに追加
                _topButtonList.Add(topPartsButton);
                //===初期の色を設定===
                //現在装着しているメッシュと同じIdなら
                if (MyoCustom.Instance.TopMeshRenderer.sharedMesh.name == id)
                {
                    topPartsButton.Button.image.color = Color.green;
                }
                else
                {
                    topPartsButton.Button.image.color = Color.white;
                }
                //クリックされた時のイベントを登録
                topPartsButton.Button.onClick.AddListener(() => {
                    //着せ替えの関数を実行
                    MyoCustom.Instance.ChangeParts(id);
                    //ボタンのリストを回す
                    for (int j = 0; j < _topButtonList.Count; j++)
                    {
                        var btn = _topButtonList[j].Button;
                        //選択されたボタンが自分自身のボタンなら
                        if (btn == topPartsButton.Button)
                        {
                            //選択された時の色を設定する
                            btn.image.color = Color.green;
                        }
                        else
                        {
                            //それ以外の色を選択する
                            btn.image.color = Color.white;
                        }
                    }
                });
            }
            //クリア回数が10 または +10の値が20で割り切れる時
            if (clearNum == 10 || ((clearNum + 10) % 20) == 0)
            {
                //この中でCLOTHESパーツボタンを生成する
                ClothesPartsButton clothesPartsButton = Instantiate(ClothesButtonPrefab);
                //Scroll ViewのContentを親にする
                clothesPartsButton.transform.SetParent(_clothesContentTransform, false);
                //初期化
                string clothesPartsNum = ((clearNum + 10) / 20).ToString();
                clothesPartsButton.Initialize("clothes_" + clothesPartsNum, "Clothes." + clothesPartsNum);
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
    void Update()
    {

    }
}
