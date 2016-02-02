using UnityEngine;
using System.Collections;

public class DissapearAftercollide : MonoBehaviour {
    public float dissapearAfter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(
                DestroyAfterTime());
            
        }

    }
    IEnumerator DestroyAfterTime() {
        yield return new WaitForSeconds(dissapearAfter);
        Destroy(gameObject);
    }
}
