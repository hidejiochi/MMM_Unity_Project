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
    public SkinnedMeshRenderer ClothesMeshRenderer
    {
        get { return _clothesMeshRenderer; }
    }
        
   

    [SerializeField]
    private SkinnedMeshRenderer _tailMeshRenderer;
    public SkinnedMeshRenderer TailMeshRenderer 
    {
        get { return _tailMeshRenderer; }
    }

    public Mesh GetMesh (string id)
    {
        foreach (Mesh mesh in _meshList) {
            if (mesh.name == id) {
                return mesh;
            }
        }

        Debug.LogErrorFormat ("指定したidのMeshが存在しません,Id:{0}", id);
        return null;
    }

    public Material GetMaterial (string id)
    {
        foreach (Material material in _materialList) {
            if (material.name == id) {
                return material;
            }
        }

        Debug.LogErrorFormat ("指定したidのMaterialが存在しません,Id:{0}", id);
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
        if (targetMesh == null || targetMaterial == null)
        {
            Debug.LogErrorFormat("指定したIdのMesh または Materialが存在しません。Id:{0}", id);
            return;
        }

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
    protected override void OnAwake()
    {
        if (PlayerPrefs.HasKey("TOP_KEY"))
        {
            string topId = PlayerPrefs.GetString("TOP_KEY");            
            ChangeParts(topId);
        }
        else
        {
            ChangeParts("top_0");
        }
        if (PlayerPrefs.HasKey("CLOTHES_KEY"))
        {
            string clothesId = PlayerPrefs.GetString("CLOTHES_KEY");
            ChangeParts(clothesId);
        }
        else
        {
            ChangeParts("clothes_0");
        }
       
        if (PlayerPrefs.HasKey("TAIL_KEY"))
        {
            string tailId = PlayerPrefs.GetString("TAIL_KEY");
            ChangeParts(tailId);
        }
        else
        {
            ChangeParts("tail_0");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
