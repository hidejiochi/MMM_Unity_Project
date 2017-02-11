using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class PartsButtonGenerator : MonoBehaviour
{
    private GameObject partsText;
    private float proNum;

    public TopPartsButton TopButtonPrefab;
    public ClothesPartsButton ClothesButtonPrefab;
    public TailPartsButton TailButtonPrefab;

    [SerializeField]
    private List<TopPartsButton> _topButtonList;

    [SerializeField]
    private List<ClothesPartsButton> _clothesButtonList;
        
    [SerializeField]
    private List<TailPartsButton> _tailButtonList; 

    [SerializeField]
    private Transform _topContentTransform;
    [SerializeField]
    private Transform _clothesContentTransform;
    [SerializeField]
    private Transform _tailContentTransform;


    // Use this for initialization
    void Start()
    {
        this.partsText = GameObject.Find("PartsText");

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
        //リストに追加
        _clothesButtonList.Add(clothesParts0Button);
        //===初期の色を設定===
        //現在装着しているメッシュと同じIdなら
        if (MyoCustom.Instance.ClothesMeshRenderer.sharedMesh.name == "clothes_0")
        {
            clothesParts0Button.Button.image.color = Color.green;
        }
        else
        {
            clothesParts0Button.Button.image.color = Color.white;
        }
        //クリックされた時のイベントを登録
        clothesParts0Button.Button.onClick.AddListener(() => {
            //着せ替えの関数を実行
            MyoCustom.Instance.ChangeParts("clothes_0");
            //ボタンのリストを回す
            for (int j = 0; j < _clothesButtonList.Count; j++)
            {
                var btn = _clothesButtonList[j].Button;
                //選択されたボタンが自分自身のボタンなら
                if (btn == clothesParts0Button.Button)
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
                
        //この中でTAILパーツボタンを生成する
        TailPartsButton tailParts0Button = Instantiate(TailButtonPrefab);
        //Scroll ViewのContentを親にする
        tailParts0Button.transform.SetParent(_tailContentTransform, false);
        tailParts0Button.Initialize("tail_0", "Tail.0");
        //リストに追加
        _tailButtonList.Add(tailParts0Button);
        //===初期の色を設定===
        //現在装着しているメッシュと同じIdなら
        if (MyoCustom.Instance.TailMeshRenderer.sharedMesh.name == "tail_0")
        {
            tailParts0Button.Button.image.color = Color.green;
        }
        else
        {
            tailParts0Button.Button.image.color = Color.white;
        }
        //クリックされた時のイベントを登録
        tailParts0Button.Button.onClick.AddListener(() => {
            //着せ替えの関数を実行
            MyoCustom.Instance.ChangeParts("tail_0");
            //ボタンのリストを回す
            for (int j = 0; j < _tailButtonList.Count; j++)
            {
                var btn = _tailButtonList[j].Button;
                //選択されたボタンが自分自身のボタンなら
                if (btn == tailParts0Button.Button)
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


        for (int i = 0; i < StageID.Instance.ClearList.Count; i++)
        {
            //クリアId
            var clearId = StageID.Instance.ClearList[i];
            //クリアした数
            int clearNum = i + 1;

            //クリア回数が3 または -3の値が9で割り切れる時
            if (clearNum == 3 || ((clearNum - 3) % 9) == 0)
            {
               

                //この中でTOPパーツボタンを生成する
                TopPartsButton topPartsButton = Instantiate(TopButtonPrefab);
                //Scroll ViewのContentを親にする
                topPartsButton.transform.SetParent(_topContentTransform, false);
                //初期化
                string topPartsNum = ((clearNum + 6) / 9).ToString();
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
            //クリア回数が6 または +3の値が9で割り切れる時
            if (clearNum == 6 || ((clearNum + 3) % 9) == 0)
            {
                //この中でCLOTHESパーツボタンを生成する
                ClothesPartsButton clothesPartsButton = Instantiate(ClothesButtonPrefab);
                //Scroll ViewのContentを親にする
                clothesPartsButton.transform.SetParent(_clothesContentTransform, false);
                //初期化
                string clothesPartsNum = ((clearNum + 3) / 9).ToString();
                //Mesh と MaterialのId
                string id = "clothes_" + clothesPartsNum;
                //初期化
                clothesPartsButton.Initialize(id, "Clothes." + clothesPartsNum);
                //リストに追加
                _clothesButtonList.Add(clothesPartsButton);
                //===初期の色を設定===
                //現在装着しているメッシュと同じIdなら
                if (MyoCustom.Instance.ClothesMeshRenderer.sharedMesh.name == id)
                {
                    clothesPartsButton.Button.image.color = Color.green;
                }
                else
                {
                    clothesPartsButton.Button.image.color = Color.white;
                }
                //クリックされた時のイベントを登録
                clothesPartsButton.Button.onClick.AddListener(() => {
                    //着せ替えの関数を実行
                    MyoCustom.Instance.ChangeParts(id);
                    //ボタンのリストを回す
                    for (int j = 0; j < _clothesButtonList.Count; j++)
                    {
                        var btn = _clothesButtonList[j].Button;
                        //選択されたボタンが自分自身のボタンなら
                        if (btn == clothesPartsButton.Button)
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
            //クリア回数が9で割り切れる時
            if ((clearNum % 9) == 0)
            {
                //この中でTAILパーツボタンを生成する
                TailPartsButton tailPartsButton = Instantiate(TailButtonPrefab);
                //Scroll ViewのContentを親にする
                tailPartsButton.transform.SetParent(_tailContentTransform, false);
                //初期化
                string tailPartsNum = (clearNum / 9).ToString();
                //Mesh と MaterialのId
                string id = "tail_" + tailPartsNum;
                //初期化
                tailPartsButton.Initialize(id, "Tail." + tailPartsNum);
                //リストに追加
                _tailButtonList.Add(tailPartsButton);
                //===初期の色を設定===
                //現在装着しているメッシュと同じIdなら
                if (MyoCustom.Instance.TailMeshRenderer.sharedMesh.name == id)
                {
                    tailPartsButton.Button.image.color = Color.green;
                }
                else
                {
                    tailPartsButton.Button.image.color = Color.white;
                }
                //クリックされた時のイベントを登録
                tailPartsButton.Button.onClick.AddListener(() => {
                    //着せ替えの関数を実行
                    MyoCustom.Instance.ChangeParts(id);
                    //ボタンのリストを回す
                    for (int j = 0; j < _tailButtonList.Count; j++)
                    {
                        var btn = _tailButtonList[j].Button;
                        //選択されたボタンが自分自身のボタンなら
                        if (btn == tailPartsButton.Button)
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
        }

    }

    // Update is called once per frame
    void Update()
    {


    }
}
