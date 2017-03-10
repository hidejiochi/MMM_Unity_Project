using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.DOLocalMove(new Vector3(0, -500, 0), 2f).SetEase(Ease.InOutQuart);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
