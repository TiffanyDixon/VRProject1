using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject standingHermione;
    public GameObject sittingHermione;
    public GameObject activateCube;
    public int ItemsCollected;
    public bool hasCollided = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pickup-Glasses"))
        {
            other.gameObject.SetActive(false);
            ++ItemsCollected;
        }
        if (other.gameObject.CompareTag("Pickup-Wand"))
        {
            other.gameObject.SetActive(false);
            ++ItemsCollected;
        }
        if (other.gameObject.CompareTag("Pickup-SpellBook"))
        {
            other.gameObject.SetActive(false);
            ++ItemsCollected;
        }
        if (other.gameObject.CompareTag("Hermione"))
        {
            sittingHermione.SetActive(true);
        }
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