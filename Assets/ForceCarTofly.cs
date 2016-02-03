using System.Collections;
using UnityEngine;

public class ForceCarTofly : MonoBehaviour {


    private Transform target;
    private Transform myTransform;
    public float range;
    public GameObject car;
    private UnityStandardAssets.Vehicles.Car.CarController controller;
    private bool didIt = false;
    public AudioClip Leviosa;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the target
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!didIt)
        {
            if (Vector3.Distance(myTransform.position, target.position) < range)
            {
                didIt = true;
                Debug.Log("Switching car modes");
                controller = car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
                GetComponent<AudioSource>().PlayOneShot(Leviosa);
                controller.switchMode();
            }
        }
    
    }
}   