using UnityEngine;
using System.Collections;

public class TreeFallWhenNearAndAddHaryPotterToCar : MonoBehaviour {
    public Transform target;
    // Use this for initialization
    public float distance;
    public GameObject treeHarry;
    public GameObject carHarry;
    public GameObject gateLeft;
    public GameObject gateRight;
    public AudioClip TreeFallSound;

    void initializeToandFrom(ref Transform from,ref Quaternion to) {
        from.Rotate(90, 0, 0);
        to = new Quaternion(from.rotation.x, from.rotation.y, from.rotation.z, from.rotation.w);
        from.Rotate(-90, 0, 0);
    }
    void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the player
        fromTree = transform;
        initializeToandFrom(ref fromTree,ref toTree);

        fromGateL = gateLeft.transform;
        fromGateR = gateRight.transform;
        initializeToandFrom(ref fromGateL, ref toGateL);
        initializeToandFrom(ref fromGateR, ref toGateR);





        //Rather than copy pasting the same line, should really put some of these in a utility class.
        //But that'd take time. 

    }
    public Transform fromTree;
    public Quaternion toTree;
    public Transform fromGateL;
    public Quaternion toGateL;
    public Transform fromGateR;
    public Quaternion toGateR;
    public float speed = 0.1F;
    public Camera playerCamera;



    // Update is called once per frame
    private bool fallingDown = false;
    private bool done = false;
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && !done) {
            if (!fallingDown && !done) {
                GetComponent<AudioSource>().PlayOneShot(TreeFallSound);
            }
            fallingDown = true;

        }

    }

    void doRotateStep(Transform from, Quaternion to,float speed,Transform transformToRotate) {
        transformToRotate.rotation = Quaternion.Lerp(from.rotation, to, Time.deltaTime * speed);
    }
    void Update () {
        if (fallingDown && !done) {
            doRotateStep(fromTree, toTree, speed,transform);
            doRotateStep(fromGateL, toGateL, speed,gateLeft.transform);
            doRotateStep(fromGateR, toGateR, speed,gateRight.transform);
            //Todo, refactor this into a class, then go through list of class and call rotate on each one, each class will hold the appropriate few vars.

        }

        if (fromTree.rotation ==  toTree  && fallingDown) {
            done = true;
            carHarry.SetActive(true);
            treeHarry.SetActive(false);
        }
        
    }
}
