using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyoCustom : MonoBehaviour {

    [SerializeField]
    private List<Mesh> _meshList;

    [SerializeField]
    private List<Material> _materialList; 

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



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
