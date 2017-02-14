using UnityEngine;

using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class GameText : MonoBehaviour
{

    private bool playOnAwake = false;
    private float proNum;
    private GameObject clearText;
    private GameObject getItemText;

    private GameObject stageNameText;
    private string _stageName;

    // Use this for initialization
    void Start()
    {
        //現在のシーン名を取得
        _stageName = SceneManager.GetActiveScene().name;
        this.stageNameText = GameObject.Find("StageNameText");
        this.stageNameText.GetComponent<Text>().text = "Stage" + _stageName;

        this.clearText = GameObject.Find("ClearText");
        this.getItemText = GameObject.Find("GetItemText");

        //クリア時に呼ぶ関数を登録
        MyoController.Instance.OnClearHandler += OnClear;

    }

    void OnClear()
    {
        
            this.clearText.GetComponent<Text>().text = "Clear";
            this.clearText.GetComponent<TypefaceAnimator>().playOnAwake = true;
            this.clearText.GetComponent<TypefaceAnimator>().progress = proNum;
            DOTween.To(() => proNum, (x) => proNum = x, 1f, 5f);

            for (int i = 0; i < StageID.Instance.ClearList.Count; i++)
            {
                //クリアId
                var clearId = StageID.Instance.ClearList[i];
                //クリアした数
                int clearNum = i + 1;

                //クリア回数が3 または -3の値が9で割り切れる時
                if (clearNum == 3 || ((clearNum - 3) % 9) == 0)
                {
                    this.getItemText.GetComponent<Text>().text = "Top Parts Get!";
                    this.getItemText.GetComponent<TypefaceAnimator>().playOnAwake = true;
                    this.getItemText.GetComponent<TypefaceAnimator>().progress = proNum;
                    DOTween.To(() => proNum, (x) => proNum = x, 1f, 12f);
                }

                //クリア回数が6 または +3の値が9で割り切れる時
                if (clearNum == 6 || ((clearNum + 3) % 9) == 0)
                {
                    this.getItemText.GetComponent<Text>().text = "Clothes Parts Get!";
                    this.getItemText.GetComponent<TypefaceAnimator>().playOnAwake = true;
                    this.getItemText.GetComponent<TypefaceAnimator>().progress = proNum;
                    DOTween.To(() => proNum, (x) => proNum = x, 1f, 12f);
                }

                //クリア回数が9で割り切れる時
                if ((clearNum % 9) == 0)
                {
                    this.getItemText.GetComponent<Text>().text = "Tail Parts Get!";
                    this.getItemText.GetComponent<TypefaceAnimator>().playOnAwake = true;
                    this.getItemText.GetComponent<TypefaceAnimator>().progress = proNum;
                    DOTween.To(() => proNum, (x) => proNum = x, 1f, 12f);
                }

            }
        }
    }

   

