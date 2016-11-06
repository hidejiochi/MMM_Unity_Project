using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageID : SingletonMonoBehaviour<StageID>
{

    [SerializeField]
    private List<string> saveList;  

    // Use this for initialization
    void Start () {
        saveList = PlayerPrefsUtility.LoadList<string>("ListSaveKey");
    }
	
	// Update is called once per frame
	void Update () {
                      
    }

    public void StageClear(string stageId)
    {
        saveList.Add(stageId);
        PlayerPrefsUtility.SaveList<string>("ListSaveKey", saveList);
    }

}
