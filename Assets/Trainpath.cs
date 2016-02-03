using UnityEngine;
using System.Collections;

public class Trainpath : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TrainMove"),"time", 40, "easetype", "linear"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
