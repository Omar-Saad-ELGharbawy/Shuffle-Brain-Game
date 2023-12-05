using System.Collections;
using UnityEngine;

public class CupShow : MonoBehaviour
{
    // Reference to the ball object
    public Transform ball;
    public float moveSpeed = 0.5f;
    public float showDuration = 1.5f;
    public float rotationDuration = 3f;
    public float rotationSpeed = 100f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        // Store the cup's original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input for horizontal movement (you can modify this based on your control scheme)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Move the cup left/right based on input
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Update the ball's position only on the horizontal axis
        Vector3 ballPosition = ball.position;
        ballPosition.x = transform.position.x;
        ball.position = ballPosition;

        if (Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(MoveAndRotate());
        }

    }


    IEnumerator MoveAndRotate()
    {
        //  ####################### Move the Cup up ######################### /
        Vector3 targetPosition = originalPosition + Vector3.up * 2.0f; // Change the '2.0f' as per your desired movement distance
        float elapsedTime = 0f;
        float moveDuration = 1.0f; // Duration for movement upward

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Pause for 1 second
        yield return new WaitForSeconds(1.0f);

        //  ####################### Rotate ######################### /
        
        // Get the initial rotation angle around the forward axis
        float initialRotationAngle = transform.rotation.eulerAngles.z;
        
        float rotationSpeed = 100.0f; 
        float angleToRotate = 360.0f; 
        float rotationTime = angleToRotate / rotationSpeed; 
        Debug.Log("Rotation Time for 360-degree rotation: " + rotationTime + " seconds");

        elapsedTime = 0f;

        while (elapsedTime < rotationTime) // Rotate for 2 seconds (adjust duration as needed)
        {
            float newRotation = initialRotationAngle + rotationSpeed * elapsedTime;
            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Pause for 1 second
        yield return new WaitForSeconds(1.0f);

        //  ####################### Return to the original rotation ######################### /
        // transform.rotation = originalRotation;

        //  ####################### Move the Cup Down ######################### /
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is back at the original position and rotation
        // transform.position = originalPosition;
    }



}
