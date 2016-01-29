using UnityEngine;
using System.Collections;

public class PlanePilot : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("plane pilot script added to" + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Input.GetAxis("Vertical"),0.0f,-Input.GetAxis("Horizontal"));
	}
}
