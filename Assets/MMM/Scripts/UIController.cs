using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {

    private bool isReloadButtonDown = false;
    private bool playOnAwake = false;
    private float proNum;
    private GameObject clearText;
    private string stageId;
    
    // Use this for initialization
    void Start () {

        this.clearText = GameObject.Find("ClearText");
        string stageId = SceneManager.GetActiveScene().name;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || this.isReloadButtonDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(GemManager.Instance.IsClear())
        {            
            this.clearText.GetComponent<Text>().text = "Clear";
            this.clearText.GetComponent<TypefaceAnimator>().playOnAwake = true;
            this.clearText.GetComponent<TypefaceAnimator>().progress = proNum;
            DOTween.To(() => proNum, (x) => proNum = x, 1f, 2.5f);
            StageID.Instance.StageClear(stageId);

        }
    }

    //Aボタンを押し続けた場合の処理
    public void GetMyReloadButtonDown() 
    {
        this.isReloadButtonDown = true;
    }
    //Aボタンを離した場合の処理
    public void GetMyReloadButtonUp()
    { 
        this.isReloadButtonDown = false;
    }   
}
