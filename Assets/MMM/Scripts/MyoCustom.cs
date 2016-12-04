using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyoCustom : SingletonMonoBehaviour<MyoCustom>
{

    [SerializeField]
    private List<Mesh> _meshList;

    [SerializeField]
    private List<Material> _materialList;

    [SerializeField]
    private SkinnedMeshRenderer _topMeshRenderer;
    public SkinnedMeshRenderer TopMeshRenderer 
    {
        get { return _topMeshRenderer; }
    }

    [SerializeField]
    private SkinnedMeshRenderer _clothesMeshRenderer; 

    [SerializeField]
    private SkinnedMeshRenderer _bodyMeshRenderer;

    [SerializeField]
    private SkinnedMeshRenderer _tailMeshRenderer; 

    public Mesh GetMesh(string id)
    {
        foreach (Mesh mesh in _meshList)
        {
            if (mesh.name == id)
            {
                return mesh;
            }
        }

        Debug.LogError("指定したidのMeshが存在しません");
        return null;
    }

    public Material GetMaterial(string id)
    {
        foreach (Material material in _materialList)
        {
            if (material.name == id)
            {
                return material;
            }
        }

        Debug.LogError("指定したidのMaterialが存在しません");
        return null;
    }

    /// <summary>
    /// Changes the parts.
    /// </summary>
    /// <param name="id">Identifier.</param>
    public void ChangeParts(string id)
    {
        Mesh targetMesh = GetMesh(id);
        Material targetMaterial = GetMaterial(id);

        if (id.Contains("top"))
        {
            //差し替える処理        
            _topMeshRenderer.sharedMesh = targetMesh;
            _topMeshRenderer.sharedMaterial = targetMaterial;
            //Idを保存
            PlayerPrefs.SetString("TOP_KEY", id);
        }
        else if (id.Contains("clothes"))
        {
            //差し替える処理      
            _clothesMeshRenderer.sharedMesh = targetMesh;
            _clothesMeshRenderer.sharedMaterial = targetMaterial;
            //Idを保存
            PlayerPrefs.SetString("CLOTHES_KEY", id);
        }
        else if (id.Contains("body"))
        {
            //差し替える処理      
            _bodyMeshRenderer.sharedMesh = targetMesh;
            _bodyMeshRenderer.sharedMaterial = targetMaterial;
            //Idを保存
            PlayerPrefs.SetString("BODY_KEY", id);
        }
        else if (id.Contains("tail"))
        {
            //差し替える処理      
            _tailMeshRenderer.sharedMesh = targetMesh;
            _tailMeshRenderer.sharedMaterial = targetMaterial;
            //Idを保存
            PlayerPrefs.SetString("TAIL_KEY", id);
        }
    }




    // Use this for initialization
    public void Start()
    {
        string topId = PlayerPrefs.GetString("TOP_KEY");
        ChangeParts(topId);

        string clothesId = PlayerPrefs.GetString("CLOTHES_KEY");
        ChangeParts(clothesId);

        string bodyId = PlayerPrefs.GetString("BODY_KEY");
        ChangeParts(bodyId);

        string tailId = PlayerPrefs.GetString("TAIL_KEY");
        ChangeParts(tailId);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
