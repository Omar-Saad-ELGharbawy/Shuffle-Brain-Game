using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupUp : MonoBehaviour
{

    private Vector3 originalPosition;

    bool isUp = false;

    /// <summary>
    /// Check if the player clicked on the cup with the ball
    /// </summary>
    private void OnMouseDown()
    {
        if (!Shuffle.canClickItem) return;
        if (isUp) return;

        Shuffle.canClickItem = false;

        bool isGameOver = gameObject.name != "Red Cup";

        StartCoroutine(GameObject.Find("Game Manager").GetComponent<Shuffle>().ShowItems(isGameOver));
        if (!isGameOver)
        {
            StartCoroutine(GameObject.Find("Game Manager").GetComponent<Shuffle>().ShowItems());
        }

        originalPosition = transform.position;
        StartCoroutine(MoveUpDown());
    }



    IEnumerator MoveUpDown()
    {
        isUp = true;
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

        //  ####################### Move the Cup Down ######################### /
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isUp = false;
    }

}
