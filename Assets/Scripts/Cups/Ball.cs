using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Reference to the ball object
    // public Transform ball;
    public Transform MyCup;


    void Update()
    {
        // Update the ball's position only on the horizontal axis
        Vector3 myCupPosition = transform.position;
        myCupPosition.x = MyCup.position.x;
        transform.position = myCupPosition;
    }

}
