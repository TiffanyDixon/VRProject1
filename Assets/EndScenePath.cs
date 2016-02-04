using UnityEngine;
using System.Collections;

public class EndScenePath : MonoBehaviour {

    // Use this for initialization
    void Start() {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("EndScenePath"), "time", 25, "easetype", "linear"));
    }
    // Update is called once per frame
    void Update () {
	
	}
}
