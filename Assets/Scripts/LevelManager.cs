using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI level;
    public Shuffle gameDifficulty;


    int levelNumber = 1;

    public void LevelUp(){

        levelNumber++;
        level.text = "Level: " + levelNumber;
        gameDifficulty.shuffleDuration -= levelNumber * 0.1f;
        gameDifficulty.Invoke(nameof(gameDifficulty.ShuffleObjects), 3f);
    }


}
