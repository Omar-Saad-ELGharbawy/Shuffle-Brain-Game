using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shuffle : MonoBehaviour
{
    List<float> transformList = new List<float>();
    List<float> shuffledList = new List<float>();
    public int shuffleCount = 2;
    public float shuffleDuration = 1.5f;
    // public float moveSpeed = 0.5f;
    private List<GameObject> shuffleObjects = new List<GameObject>();

    public static bool isShuflling = false;

    public CupShow cupShow;



    void Start()
    {
        isShuflling = true;
        GetShufflingObjects();

        StartShuffling();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        isShuflling = true;
        GetShufflingObjects();
        StartShuffling();
    }

    public void StartShuffling()
    {
        isShuflling = true;
        Debug.Log("Outside Cups");

        if (shuffleObjects.Contains(GameObject.Find("Card")))
        {
            Invoke(nameof(FlipAllCards), 1f);
            Invoke(nameof(FlipAllCards), 3f);
        }
        if (shuffleObjects.Contains(GameObject.Find("Red Cup")))
        {
            Debug.Log("All Cups");
            Invoke(nameof(FlipAllCards), 0.8f);
            // Invoke(nameof(FlipAllCards), 3f);
        }
        Invoke(nameof(ShuffleObjects), 5f);
        // isShuflling = false;

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
            transformList.Add(shuffle.transform.position.x);
        }
    }

    /// <summary>
    /// Flip all the cards at the beginning of the scene
    /// </summary>
    public void FlipAllCards()
    {
        foreach (var shuffleObject in shuffleObjects)
        {

            if (shuffleObjects.Contains(GameObject.Find("Card")))
            {
                CardFlip flipScript = shuffleObject.GetComponent<CardFlip>();
                flipScript.FlipCard();
            }
            if (shuffleObjects.Contains(GameObject.Find("Red Cup")))
            {
                Debug.Log("All Cups 2");

                CupShow cupShow = shuffleObject.GetComponent<CupShow>();
                if (shuffleObject.name == "Red Cup")
                {
                    Debug.Log("Red Cup");

                    cupShow.ShowBall();
                }
                // Invoke(nameof(cupShow.ShowBall()), 1f);
                // Invoke(nameof(FlipAllCards), 3f);
            }
        }
    }

    public void ShuffleObjects()
    {
        isShuflling = true;
        StartCoroutine(ShuffleList());
    }

    /// <summary>
    /// Shuffle the elements in a given list and change their position
    /// </summary>
    IEnumerator ShuffleList()
    {

        for (int shufflingNumber = 0; shufflingNumber < shuffleCount; shufflingNumber++)
        {
            shuffledList = transformList.OrderBy(item => Random.value).ToList();
            if (transformList.Equals(shuffledList))
            {
                Debug.Log("The same random number was generated!");
            }

            // print("Original");
            // foreach (var item in transformList)
            // {
            //     print(item);

            // }
            // print("Shuffled");
            // foreach (var item in shuffledList)
            // {
            //     print(item);

            // }

            float elapsedTime = 0f;
            while (elapsedTime < shuffleDuration)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 currentPosition = new Vector3(transformList[i], -2f, 0f);
                    Vector3 targetPosition = new Vector3(shuffledList[i], -2f, 0f);
                    shuffleObjects[i].transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / shuffleDuration);
                }
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transformList = shuffledList;
        }
        isShuflling = false;
    }
}
