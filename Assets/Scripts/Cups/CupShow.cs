using System.Collections;
using UnityEngine;

public class CupShow : MonoBehaviour
{
    // Reference to the ball object
    public Transform ball;
    // public float moveSpeed = 0.5f;
    // public float showDuration = 1.5f;
    float rotationSpeed = 720f;
    // float rotationDuration = 3f;
    private Vector3 originalPosition;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private Quaternion target2Rotation;


    void Start()
    {
        // Store the cup's original position and rotation
        // originalPosition = transform.position;
        // originalRotation = transform.rotation;
        StartCoroutine(MoveAndRotate());

    }

    void Update()
    {
        // Update the ball's position only on the horizontal axis
        Vector3 ballPosition = ball.position;
        ballPosition.x = transform.position.x;
        ball.position = ballPosition;
    }

    // public void ShowBall()
    // {
    //     StartCoroutine(MoveAndRotate());
    // }

    public IEnumerator MoveAndRotate()
    {
        originalPosition = transform.position;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0, 0, 360); // Adjust the target rotation as needed
        target2Rotation = Quaternion.Euler(0, 0, 539); // Adjust the target rotation as needed


        //  ####################### Move the Cup up ######################### /
        Vector3 targetPosition = originalPosition + Vector3.up * 2.0f; // Change the '2.0f' as per your desired movement distance
        float elapsedTime = 0f;
        float moveDuration = 0.3f; // Duration for movement upward

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Pause for 1 second
        yield return new WaitForSeconds(0.2f);

        //  ####################### Rotate ######################### /

        //Get the initial rotation angle around the forward axis
        float initialRotationAngle = transform.rotation.eulerAngles.z;

        // float rotationTime = 0.6f;
        float rotationSpeed = 720.0f;
        float angleToRotate = 360.0f;
        float rotationTime = angleToRotate / rotationSpeed;
        // float rotationSpeed = angleToRotate / rotationTime;

        Debug.Log("Rotation Speed for 360-degree rotation: " + rotationTime );

        elapsedTime = 0f;

        while (elapsedTime < rotationTime) 
        {
            float newRotation = initialRotationAngle + rotationSpeed * elapsedTime;
            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = startRotation;
        
        // elapsedTime = 0f;
        // while (elapsedTime < 1.0f)
        // {
        //     elapsedTime += Time.deltaTime;
        //     transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
        //     yield return null;
        // }

        // // Pause for 1 second
        // yield return new WaitForSeconds(0.1f);

        // elapsedTime = 0f;
        // while (elapsedTime < 1.0f)
        // {
        //     elapsedTime += Time.deltaTime;
        //     transform.rotation = Quaternion.Lerp(targetRotation, target2Rotation, elapsedTime);
        //     yield return null;
        // }
        // yield return new WaitForSeconds(0.2f);

        //  ####################### Move the Cup Down ######################### /
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }
}
