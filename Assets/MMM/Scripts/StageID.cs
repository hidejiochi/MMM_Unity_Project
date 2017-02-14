using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StageID : SingletonMonoBehaviour<StageID>
{
    [SerializeField]
    private List<string> clearList;

    public List<string> ClearList 
    {
        get { return clearList; }
    }

    private GameObject getItemText;

    protected override void OnAwake()
    {
        base.OnAwake();
        clearList = PlayerPrefsUtility.LoadList<string>("ListSaveKey");

        this.getItemText = GameObject.Find("GetItemText");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StageClear(string stageId)
    {
        //すでに含まれていなければ
        if (clearList.Contains(stageId) == false)
        {
            //クリアした数
            int clearNum = ClearList.Count+1;

            //クリア回数が3 または -3の値が9で割り切れる時
            if (clearNum == 3 || ((clearNum - 3) % 9) == 0)
            {
                this.getItemText.GetComponent<Text>().text = "Top Parts Get!";
                this.getItemText.GetComponent<TypefaceAnimator>().Play();
                //            this.getItemText.GetComponent<TypefaceAnimator> ().playOnAwake = true;
                //            this.getItemText.GetComponent<TypefaceAnimator> ().progress = proNum;
                //            DOTween.To (() => proNum, (x) => proNum = x, 1f, 12f);
            }

            //クリア回数が6 または +3の値が9で割り切れる時
            else if (clearNum == 6 || ((clearNum + 3) % 9) == 0)
            {
                this.getItemText.GetComponent<Text>().text = "Clothes Parts Get!";
                this.getItemText.GetComponent<TypefaceAnimator>().Play();
                //            this.getItemText.GetComponent<TypefaceAnimator> ().playOnAwake = true;
                //            this.getItemText.GetComponent<TypefaceAnimator> ().progress = proNum;
                //            DOTween.To (() => proNum, (x) => proNum = x, 1f, 12f);
            }

            //クリア回数が9で割り切れる時
            else if ((clearNum % 9) == 0)
            {
                this.getItemText.GetComponent<Text>().text = "Tail Parts Get!";
                this.getItemText.GetComponent<TypefaceAnimator>().Play();
                //            this.getItemText.GetComponent<TypefaceAnimator> ().playOnAwake = true;
                //            this.getItemText.GetComponent<TypefaceAnimator> ().progress = proNum;
                //            DOTween.To (() => proNum, (x) => proNum = x, 1f, 12f);
            }
            clearList.Add(stageId);
            PlayerPrefsUtility.SaveList<string>("ListSaveKey", clearList);
        }
    }

    public void IDdelete()
    {
        PlayerPrefs.DeleteKey("ListSaveKey");
    }
}
