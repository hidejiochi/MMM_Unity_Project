using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageID : SingletonMonoBehaviour<StageID>
{
    [SerializeField]
    private List<string> saveList;

    public List<string> SaveList
    {
        get { return saveList; }
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        saveList = PlayerPrefsUtility.LoadList<string>("ListSaveKey");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StageClear(string stageId)
    {
        //すでに含まれていなければ
        if (saveList.Contains(stageId) == false)
        {
            saveList.Add(stageId);
            PlayerPrefsUtility.SaveList<string>("ListSaveKey", saveList);
        }
    }

    public void IDdelete()
    {
        PlayerPrefs.DeleteKey("ListSaveKey");
    }
}
