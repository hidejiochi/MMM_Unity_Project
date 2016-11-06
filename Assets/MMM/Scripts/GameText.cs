using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GameText : MonoBehaviour {

    private bool playOnAwake = false;
    private float proNum;
    private GameObject clearText;

    // Use this for initialization
    void Start () {
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
