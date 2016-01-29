using UnityEngine;
using System.Collections;

public class TreeFallWhenNearAndAddHaryPotterToCar : MonoBehaviour {
    public Transform target;
    // Use this for initialization
    public float distance;
    public GameObject treeHarry;
    public GameObject carHarry;
    public GameObject spider;
    public AudioClip TreeFallSound;
    void Start () {
        target = GameObject.FindWithTag("Player").transform; //target the player
        from = transform;
        from.Rotate(60, 0, 0);
        to = new Quaternion(from.rotation.x,from.rotation.y,from.rotation.z,from.rotation.w);
        from.Rotate(-60, 0, 0);

        
        //Rather than copy pasting the same line, should really put some of these in a utility class.
        //But that'd take time. 

    }
    public Transform from;
    public Quaternion to;
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
            transform.rotation = Quaternion.Lerp(from.rotation, to, Time.deltaTime * speed);
        }

        if (from.rotation ==  to  && fallingDown) {
            done = true;
            carHarry.SetActive(true);
            treeHarry.SetActive(false);
            spider.SetActive(true);
            playerCamera.transform.LookAt(spider.transform);
        }
        
    }
}
