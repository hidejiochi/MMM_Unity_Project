using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyoCustom : MonoBehaviour {

    [SerializeField]
    private List<Mesh> _meshList;

    public Mesh GetMesh(string id)
    {
        foreach (Mesh mesh in _meshList)
        {
            if (mesh.name == id)
            {
                return mesh;
            }
        }
        Debug.LogError("指    定したidのMeshが存在しません");
        return null;
    }



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
