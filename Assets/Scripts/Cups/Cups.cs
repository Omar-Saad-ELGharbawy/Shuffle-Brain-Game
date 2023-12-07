using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{

    private Vector3 originalPosition;
    private Quaternion startRotation;

    void Start()
    {
        Invoke("startShow", 0.5f); 
    }


    void startShow()
    {
        StartCoroutine(MoveAndRotate());
    }

    /// <summary>
    /// Check if the player clicked on the cup with the ball
    /// </summary>
    private void OnMouseDown()
    {
        if (!Shuffle.canClickItem) return;
        // if (isUp) return;

        Shuffle.canClickItem = false;

        // know the pressed by Cup with ball
        bool isGameOver = gameObject.name != "Red Cup";

        StartCoroutine(GameObject.Find("Game Manager").GetComponent<Shuffle>().ShowItems(isGameOver));
        if (!isGameOver)
        {
            GameObject.Find("Game Manager").GetComponent<LevelManager>().IncreaseLevel();
        }
    }




    public IEnumerator MoveUpDown()
    {
        originalPosition = transform.position;

        //  ####################### Move the Cup up ######################### /
        Vector3 targetPosition = originalPosition + Vector3.up * 2.0f; // Change the '2.0f' as per your desired movement distance
        float elapsedTime = 0f;
        float moveDuration = 0.4f; // Duration for movement upward

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Pause for 1 second
        yield return new WaitForSeconds(0.4f);

        //  ####################### Move the Cup Down ######################### /
        // GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();
        Invoke("cupSound", 0.2f); 

        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    public IEnumerator MoveAndRotate()
    {
        originalPosition = transform.position;
        startRotation = transform.rotation;

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
        float angleToRotate = 361.0f;
        float rotationTime = angleToRotate / rotationSpeed;

        Debug.Log("Rotation Time for 360-degree rotation: " + rotationTime);

        elapsedTime = 0f;
        while (elapsedTime < rotationTime)
        {
            float newRotation = initialRotationAngle + rotationSpeed * elapsedTime;
            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = startRotation;

        //  ####################### Move the Cup Down ######################### /
        Invoke("cupSound", 0.1f); 
        // GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();


        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    void cupSound()
    {
        GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();

    }

}
