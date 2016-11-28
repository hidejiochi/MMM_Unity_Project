using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyoCustom : MonoBehaviour {

    [SerializeField]
    private List<Mesh> _meshList;

    [SerializeField]
    private List<Material> _materialList;

    [SerializeField]
    private SkinnedMeshRenderer _topMeshRenderer;

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
        }
        else if (id.Contains("clothes"))
        {
            //差し替える処理      
            _clothesMeshRenderer.sharedMesh = targetMesh;
            _clothesMeshRenderer.sharedMaterial = targetMaterial;
        }
        else if (id.Contains("body"))
        {
            //差し替える処理      
            _bodyMeshRenderer.sharedMesh = targetMesh;
            _bodyMeshRenderer.sharedMaterial = targetMaterial;
        }
        else if (id.Contains("tail"))
        {
            //差し替える処理      
            _tailMeshRenderer.sharedMesh = targetMesh;
            _tailMeshRenderer.sharedMaterial = targetMaterial;
        }
    }




    // Use this for initialization
    public void Start()
    {
        string bodyId = PlayerPrefs.GetString("BODY_KEY");
        ChangeParts(bodyId);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
