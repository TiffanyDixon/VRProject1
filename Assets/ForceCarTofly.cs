using UnityEngine;
using System.Collections;

public class ForceCarTofly : MonoBehaviour {


    private Transform target;
    private Transform myTransform;
    public float range;
    public GameObject car;
    private UnityStandardAssets.Vehicles.Car.CarController controller;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the target
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(myTransform.position, target.position) < range)
        {
            Debug.Log("Switching car modes");
          controller =   car.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
            controller.switchMode();
        }
    }
}   