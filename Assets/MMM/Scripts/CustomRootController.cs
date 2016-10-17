using UnityEngine;
using System.Collections;

public class CustomRootController : MonoBehaviour
{
    [SerializeField]
    private MyoController _myoController;

    // Use this for initialization
    void Start()
    {
        _myoController.SetAnimation("Dance");
    }
}

