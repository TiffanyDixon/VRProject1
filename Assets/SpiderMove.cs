using UnityEngine;
using System.Collections;

public class SpiderMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        iTween.MoveTo(gameObject, new Vector3(95.25f, 2.24f, 16.46f), 7);
	}
}
