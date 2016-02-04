using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateText() {
        int remaining = 4 - ItemsCollected;
        if (remaining != 0) {
            scoreTextL.text = "Need " + (remaining) + " More Items!!";
           // scoreTextR.text = "RNeed " + (remaining) + " More Items!!";
        } else {
            scoreTextL.text = "You got it all! Go to the tunnel!";
            //scoreTextR.text = "You got it all! Go to the tunnel!";
        }
    }

    public GameObject standingHermione;
    public GameObject sittingHermione;
    public GameObject activateCube;
    public int ItemsCollected;
    public bool hasCollided = false;
    public Text scoreTextL;
    //public Text scoreTextR;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hermione");
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            ++ItemsCollected;
        }
        if (other.gameObject.CompareTag("Hermione"))
        {
            sittingHermione.SetActive(true);
        }
        updateText();
        moveToScene3();
    }

    void Hermione()
    {
        if(hasCollided == true)
        {
            standingHermione.SetActive(false);
            sittingHermione.SetActive(true);
        }
    }

    void moveToScene3()
    {
        if(ItemsCollected >= 4)
        {
            activateCube.SetActive(true);
        }
    }
}