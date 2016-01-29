using UnityEngine;
using System.Collections;

public class CollideSound : MonoBehaviour {
    public AudioClip crashSound;
    public float distance = 200f;
    public Transform target;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the player
    }
	
	// Update is called once per frame
	void Update () {
	
	}
   


void OnCollisionEnter(Collision collision)
    {
        if(Vector3.Distance(target.position, transform.position) > distance ) { 
            return; //Don't play sound if target is too far away.
        }
        // next line requires an AudioSource component on this gameobject
        GetComponent<AudioSource>().PlayOneShot(crashSound);
    }
}
