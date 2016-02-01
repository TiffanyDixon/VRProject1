using UnityEngine;
using System.Collections;

public class TrainMoving : MonoBehaviour {

    public bool UpdatePosition;

    public float DelayUpdatePos;
    public double FirstXPos;
    public double FirstZPos;
    public float MovementSpeed;

    public GameObject Train;

    // Use this for initialization
    void Start()
    {
        UpdatePosition = true;
        DelayUpdatePos = 1;
        FirstXPos = 119;
        FirstZPos = -629.4;
        MovementSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (UpdatePosition == true && DelayUpdatePos == 0)
        {
            Train.transform.Translate(MovementSpeed -1,0,1);
        }

        if (DelayUpdatePos > 0)
        {
            DelayUpdatePos -= Time.deltaTime;
        }

        if (DelayUpdatePos < 0)
        {
            DelayUpdatePos = 0;
        }
    }
}

