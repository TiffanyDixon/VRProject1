using UnityEngine;
using System.Collections;

public class FenceFallOnHit : MonoBehaviour {
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
    public float speed = 1f;
    private RotateHelper rotator;
    public Vector3 rotation;
    public AudioClip fenceThudSound;
    // Use this for initialization
    void Start () {
        rotator = new RotateHelper(gameObject, rotation, speed);
	}

    private bool fallingDown = false;
    private bool done = false;
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && !done) {
            if (!fallingDown && !done) {
                GetComponent<AudioSource>().PlayOneShot(fenceThudSound);
            }
            fallingDown = true;

        }

    }
    // Update is called once per frame
    void Update () {
        if (fallingDown && !done) {
            rotator.doRotateStep();
            StartCoroutine(TurnIntangibleAfterTime(1f));

        }

        if (rotator.isDone() && fallingDown) {
            done = true;
            

        }

    }
    public float turnIntangibleAfter;
    IEnumerator TurnIntangibleAfterTime(float time) {
        yield return new WaitForSeconds(time);
        GetComponent<Collider>().enabled = false;
    }
}
