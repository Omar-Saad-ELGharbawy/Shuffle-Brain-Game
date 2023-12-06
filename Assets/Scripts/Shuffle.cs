using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    List<int> transformList = new List<int>();
    List<int> shuffledList = new List<int>();

    public static int levelNum = 0;
    public static int shuffleCount = 5;
    public static float suffleDuration = 1.0f;

    public float moveSpeed = 0.5f;

    public GameObject ball;
    private List<GameObject> shuffleObjects = new List<GameObject>();


    void Start()
    {
        GetShufflingObjects();

        if (shuffleObjects.Contains(GameObject.Find("Card")))
        {
            Invoke(nameof(FlipAllCards), 1f);
            Invoke(nameof(FlipAllCards), 4f);
        }

        Invoke(nameof(ShuffleObjects), 6f);
    }

    void ShuffleObjects()
    {
        StartCoroutine(ShuffleList());
    }

    /// <summary>
    /// Flip all the cards at the beginning of the scene
    /// </summary>
    /// <param name="cards"></param>
    void FlipAllCards()
    {
        foreach (var card in shuffleObjects)
        {
            CardFlip flipScript = card.GetComponent<CardFlip>();
            flipScript.FlipCard();
        }
    }

    /// <summary>
    /// Get all the shuffling items placed in the scene with the tag [Shuffle]
    /// </summary>
    void GetShufflingObjects()
    {
        // Assuming your cups have a specific tag, adjust this based on your setup
        GameObject[] shufflesList = GameObject.FindGameObjectsWithTag("Shuffle");

        foreach (GameObject shuffle in shufflesList)
        {
            shuffleObjects.Add(shuffle);
            transformList.Add((int)shuffle.transform.position.x);
        }
    }

    /// <summary>
    /// Shuffle the elements in a given list and change their position
    /// </summary>
    IEnumerator ShuffleList()
    {

        for (int shufflingNumber = 0; shufflingNumber < shuffleCount; shufflingNumber++)
        {
            shuffledList = transformList.OrderBy(item => Random.value).ToList();

            float elapsedTime = 0f;
            while (elapsedTime < suffleDuration)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 currentPosition = new Vector3(transformList[i], 0f, 0f);
                    Vector3 targetPosition = new Vector3(shuffledList[i], 0f, 0f);
                    shuffleObjects[i].transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / suffleDuration);
                }
                elapsedTime += Time.deltaTime;
                yield return null;

            }
            transformList = shuffledList;
        }
    }
}
