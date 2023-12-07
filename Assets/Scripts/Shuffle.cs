using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shuffle : MonoBehaviour
{
    List<GameObject> shuffleItems = new();
    List<float> itemsXPositions = new();

    public int shuffleCount = 2;
    public float shuffleDuration = 1.5f;

    public static bool canClickItem = false;

    [SerializeField] GameObject gameOverPanel;

    bool cupShowFlag;

    void Start()
    {
        cupShowFlag = true;
        FindAllShuffleItems();
        StartCoroutine(ShowItems());
    }




    /// <summary>
    /// Get all the shuffling items placed in the scene with the tag [Shuffle]
    /// </summary>
    void FindAllShuffleItems()
    {
        GameObject[] shufflesList = GameObject.FindGameObjectsWithTag("Shuffle");

        foreach (GameObject shuffle in shufflesList)
        {
            shuffleItems.Add(shuffle);
            itemsXPositions.Add(shuffle.transform.position.x);
        }
    }




    /// <summary>
    /// Show all the objects in the scene either the cards numbers or the cup with the ball and then shuffle or gameover
    /// </summary>
    /// <param name="isGameOver"></param>
    public IEnumerator ShowItems(bool isGameOver = false)
    {
        // Flip all the Cards in the scene
        if (shuffleItems.Contains(GameObject.Find("Card")))
        {
            yield return new WaitForSeconds(0.5f);
            foreach (var item in shuffleItems) item.GetComponent<CardFlip>().FlipCard();

            yield return new WaitForSeconds(2);
            foreach (var item in shuffleItems) item.GetComponent<CardFlip>().FlipCard();
        }
        // Raise the cup that has the ball
        else if (shuffleItems.Contains(GameObject.Find("Red Cup")))
        {
            yield return new WaitForSeconds(0.5f);

            if (!cupShowFlag)
            {
                foreach (var item in shuffleItems) StartCoroutine(item.GetComponent<CupUp>().MoveUpDown());
            }
            yield return new WaitForSeconds(2f);
            cupShowFlag = false;

        }

        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            StartCoroutine(ShuffleList());
        }
    }





    /// <summary>
    /// Shuffle the elements in a given list and change their position
    /// </summary>
    IEnumerator ShuffleList()
    {
        yield return new WaitForSeconds(1f);

        // Start shuffling the items in the scene and change their positions
        for (int shufflingNumber = 0; shufflingNumber < shuffleCount; shufflingNumber++)
        {
            List<float> shuffledList = itemsXPositions.OrderBy(item => Random.value).ToList();
            float elapsedTime = 0f;
            while (elapsedTime < shuffleDuration)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 currentPosition = new Vector3(itemsXPositions[i], -2f, 0f);
                    Vector3 targetPosition = new Vector3(shuffledList[i], -2f, 0f);
                    shuffleItems[i].transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / shuffleDuration);
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            itemsXPositions = shuffledList;
        }
        // Make the items clickable
        canClickItem = true;
    }


}