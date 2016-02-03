using UnityEngine;
using System.Collections;

public class TreeFallWhenNearAndAddHaryPotterToCar : MonoBehaviour {
    private class RotateHelper {
        private Transform from;
        private Quaternion to;
        private GameObject obj;
        private float speed;
        public RotateHelper(GameObject obj, Vector3 rotation, float speed) {
            from = obj.transform;
            from.Rotate(rotation);
            to = new Quaternion(from.rotation.x, from.rotation.y, from.rotation.z, from.rotation.w);
            from.Rotate(-rotation.x, -rotation.y, -rotation.z);
            this.speed = speed;
            this.obj = obj;
        }
     public void doRotateStep() {
            obj.transform.rotation = Quaternion.Lerp(from.rotation, to, Time.deltaTime * speed);
        }
    public bool isDone() {
            return from.rotation == to;
        }

    }
    public Transform target;
    // Use this for initialization
    public float distance;
    public GameObject treeHarry;
    public GameObject carHarry;
    public GameObject gateLeft;
    public GameObject gateRight;
    public AudioClip TreeFallSound;
    private RotateHelper treeRotate;
    private Collider meshCollider;
    private System.Collections.Generic.List<RotateHelper> gateRotators;

    void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the player
        treeRotate = new RotateHelper(gameObject,new Vector3(90,0,0),speed);
        gateRotators = new System.Collections.Generic.List<RotateHelper>();
        gateRotators.Add(new RotateHelper(gateLeft, new Vector3(-90, 0, 0),speed/2));
        gateRotators.Add(new RotateHelper(gateRight, new Vector3(-90, 0, 0), speed/2));
        meshCollider = GetComponent<Collider>();

        //Rather than copy pasting the same line, should really put some of these in a utility class.
        //But that'd take time. 

    }

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


    void Update () {
        if (fallingDown && !done) {
            StartCoroutine(TurnIntangibleAfterTime());
            treeRotate.doRotateStep();
            foreach(RotateHelper rot in gateRotators) {
                rot.doRotateStep();
            }

            //Todo, refactor this into a class, then go through list of class and call rotate on each one, each class will hold the appropriate few vars.

        }

        if (treeRotate.isDone()  && fallingDown) {
            done = true;
            carHarry.SetActive(true);
            treeHarry.SetActive(false);
            
        }
        
    }
    public float turnIntangibleAfter;
    IEnumerator TurnIntangibleAfterTime() {
        yield return new WaitForSeconds(turnIntangibleAfter);
        meshCollider.enabled = false;
    }
}
