using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneWhenPlayerClose : MonoBehaviour {
    private Transform target;
    private Transform myTransform;
    public float range;
    public string levelToChangeTo;
	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the target
        myTransform = transform;
    }
	
	// Update is called once per frame
	void Update () {
	    if ( Vector3.Distance(myTransform.position,target.position) < range ) {
            SceneManager.LoadScene(levelToChangeTo);
        }
	}
}
