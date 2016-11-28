using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageID : SingletonMonoBehaviour<StageID>
{
    [SerializeField]
    private List<string> clearList;

    public List<string> ClearList 
    {
        get { return clearList; }
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        clearList = PlayerPrefsUtility.LoadList<string>("ListSaveKey");
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
            clearList.Add(stageId);
            PlayerPrefsUtility.SaveList<string>("ListSaveKey", clearList);
        }
    }

    public void IDdelete()
    {
        PlayerPrefs.DeleteKey("ListSaveKey");
    }
}
