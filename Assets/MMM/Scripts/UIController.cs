using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour {

    private bool isReloadButtonDown = false;
    private bool IDdeleteButtonDown = false; 

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || this.isReloadButtonDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Z) || this.IDdeleteButtonDown)
        {
            StageID.Instance.IDdelete();
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
    //Zボタンを押し続けた場合の処理
    public void GetIDdeleteButtonDown()
    {
        this.IDdeleteButtonDown = true;
    }
    //Zボタンを離した場合の処理
    public void GetIDdeleteButtonUp() 
    {
        this.IDdeleteButtonDown = false;
    }
}
