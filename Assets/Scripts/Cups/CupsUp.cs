using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupUp : MonoBehaviour
{
    
    private Vector3 originalPosition;
    public float moveSpeed = 0.5f;
    public GameObject gameOverPanel;

    bool isUp= false;

    /// <summary>
    /// Check if the player clicked on a card
    /// </summary>
    private void OnMouseDown()
    {
        if (Shuffle.isShuflling) return;
        if (isUp) return;
        if (gameObject.name == "Red Cup"){
            LevelManager.levelNumber++;
        }
        else
        {
            Invoke(nameof(GameOver), 3f);
        }

        originalPosition = transform.position;
        StartCoroutine (MoveUpDown());
    }

    void GameOver(){
        LevelManager.levelNumber=1;
        gameOverPanel.SetActive(true);
        Time.timeScale= 0;
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
