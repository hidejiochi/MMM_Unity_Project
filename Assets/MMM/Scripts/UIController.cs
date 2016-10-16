using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private bool isReloadButtonDown = false; 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || this.isReloadButtonDown)
        {
            SceneManager.LoadScene("Stage_004");
        }
    }

    //スペースボタンを押し続けた場合の処理
    public void GetMyReloadButtonDown() 
    {
        this.isReloadButtonDown = true;
    }
    //スペースボタンを離した場合の処理
    public void GetMyReloadButtonUp()
    { 
        this.isReloadButtonDown = false;
    }
}
