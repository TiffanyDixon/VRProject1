using UnityEngine;
using System.Collections;

public class CollideSound : MonoBehaviour {
    public AudioClip crashSound; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   


void OnCollisionEnter(Collision collision)
    {
        // next line requires an AudioSource component on this gameobject
       GetComponent<AudioSource>().PlayOneShot(crashSound);
    }
}
