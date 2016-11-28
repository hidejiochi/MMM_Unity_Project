using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameText : MonoBehaviour {

    private bool playOnAwake = false;
    private float proNum;
    private GameObject clearText;
    private GameObject stageNameText;
    private string _stageName; 

    // Use this for initialization
    void Start () {
        //現在のシーン名を取得
         _stageName = SceneManager.GetActiveScene().name; 
        this.stageNameText = GameObject.Find("StageNameText");
        this.stageNameText.GetComponent<Text>().text = "Stage" +_stageName; 

        this.clearText = GameObject.Find("ClearText");

    }
	
	// Update is called once per frame
	void Update () {
        

        if (GemManager.Instance.IsClear())
        {
            this.clearText.GetComponent<Text>().text = "Clear";
            this.clearText.GetComponent<TypefaceAnimator>().playOnAwake = true;
            this.clearText.GetComponent<TypefaceAnimator>().progress = proNum;
            DOTween.To(() => proNum, (x) => proNum = x, 1f, 5f);       

        }

    }
}
