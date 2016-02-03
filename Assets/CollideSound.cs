using UnityEngine;
using System.Collections;

public class CollideSound : MonoBehaviour {
    public AudioClip crashSound;
    public float distance = 200f;
    public Transform target;
    public float coolDown = 0;

    private float coolDownCounter = 0;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the player
    }
	
	// Update is called once per frame
	void Update () {
        coolDownCounter -= Time.deltaTime;
	}
   


void OnCollisionEnter(Collision collision) { 

        if(Vector3.Distance(target.position, transform.position) > distance ) { 
            return; //Don't play sound if target is too far away.
        }
        if (coolDownCounter >= 0) { //Next, check for the cooldown.
            return;
        }
        // next line requires an AudioSource component on this gameobject
        GetComponent<AudioSource>().PlayOneShot(crashSound);
        //We played our sound, so reset the cooldown
        coolDownCounter = coolDown;
    }

}
