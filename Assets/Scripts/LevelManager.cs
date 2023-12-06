using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI level;
    public Shuffle gameDifficulty;
    public static int levelNumber = 1;
    float originalDuration;
    float minShuffleDuration = 0.25f;
    int currentLevel;

    void Start()
    {
        originalDuration = gameDifficulty.shuffleDuration;
        currentLevel = levelNumber;
    }

    void Update()
    {
        if (levelNumber != currentLevel)
        {
            currentLevel = levelNumber;
            level.text = "Level " + levelNumber;
            gameDifficulty.shuffleDuration = originalDuration - levelNumber * 0.1f;

            // Ensure shuffle duration doesn't go below the minimum duration
            if (gameDifficulty.shuffleDuration < minShuffleDuration)
            {
                gameDifficulty.shuffleDuration = minShuffleDuration;
            }
            // gameDifficulty.shuffleCount++;
            gameDifficulty.shuffleCount = levelNumber + 3;

            gameDifficulty.Invoke(nameof(gameDifficulty.ShuffleObjects), 3f);
        }
    }
    

    // public static void LevelUp()
    // {

        // levelNumber++;
        // level.text = "Level " + levelNumber;
        // // gameDifficulty.shuffleDuration -= levelNumber * 0.1f;
        // gameDifficulty.shuffleDuration = originalDuration -  (levelNumber-1)*0.1f;

        // // Ensure shuffle duration doesn't go below the minimum duration
        // if (gameDifficulty.shuffleDuration < minShuffleDuration)
        // {
        //     gameDifficulty.shuffleDuration = minShuffleDuration;
        // }
        // if(levelNumber%2 == 0){
        //     gameDifficulty.shuffleCount++;
        // }

        // gameDifficulty.Invoke(nameof(gameDifficulty.ShuffleObjects), 3f);
    // }

    // public void RestrtGame(){
    //     levelNumber =1;
    // }

}
