using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private GameDefine.GemType _type;

    public GameDefine.GemType Type
    {
        get { return _type; }
    }   

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}