using UnityEngine;
using System.Collections;

public class TrainMoveLastScene : MonoBehaviour {

    // Use this for initialization
    void Start() {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("TrainMoveLastScene"), "time", 10, "easetype", "linear"));
    }

    // Update is called once per frame
    void Update () {
	
	}
}
