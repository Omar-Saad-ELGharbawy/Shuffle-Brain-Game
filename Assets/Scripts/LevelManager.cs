using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    Shuffle shuffleScript;

    int levelNumber = 1;

    float originalDuration;
    float minShuffleDuration = 0.25f;

    void Start()
    {
        shuffleScript = gameObject.GetComponent<Shuffle>();
        originalDuration = shuffleScript.shuffleDuration;
    }




    /// <summary>
    /// Increase the level, update the text and increase the difficulty
    /// </summary>
    public void IncreaseLevel()
    {
        levelNumber++;
        levelText.text = "Level " + levelNumber;
        IncreaseDifficulty();
    }




    /// <summary>
    /// Decrease the duration of shuffling until [minShuffleDuration] and increase the [shuffleCount]
    /// </summary>
    void IncreaseDifficulty()
    {
        shuffleScript.shuffleDuration = originalDuration - levelNumber * 0.1f;

        // Ensure shuffle duration doesn't go below the minimum duration
        if (shuffleScript.shuffleDuration < minShuffleDuration)
        {
            shuffleScript.shuffleDuration = minShuffleDuration;
        }
        shuffleScript.shuffleCount = levelNumber + 3;
    }
}
