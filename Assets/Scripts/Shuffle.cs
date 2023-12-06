using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    List<int> transformList = new List<int>();
    int[] shuffledList = new int[3];
    public static int score = 0;
    public static int shuffleCount = 5;
    public static float suffleDuration = 1.0f;

    public float moveSpeed = 0.5f;

    public GameObject ball;
    [SerializeField] private List<GameObject> shuffleObjects = new List<GameObject>();

    void Start()
    {
        InitializeList();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShuffleList());
        }
    }
    // <summary>
    // / Shuffle the elememnts in a given list
    // </summary>
    IEnumerator ShuffleList()
    {
        // List<int> newShuffle = transformList.OrderBy(item => Random.value).ToList();
        // newShuffle.CopyTo(shuffledList);
        string stringList2 = string.Join(", ", transformList);
        string stringList = string.Join(", ", shuffledList);
        print("Original");
        print(stringList2);
        print("Shuffled");
        print(stringList);

        for (int s = 0; s < shuffleCount; s++)
        {
            List<int> newShuffle = transformList.OrderBy(item => Random.value).ToList();
            newShuffle.CopyTo(shuffledList);

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
        }
    }

    void InitializeList()
    {
        // Assuming your cups have a specific tag, adjust this based on your setup
        GameObject[] cupArray = GameObject.FindGameObjectsWithTag("Cup");

        foreach (GameObject cup in cupArray)
        {
            shuffleObjects.Add(cup);
            transformList.Add((int)cup.transform.position.x);
        }
    }
}
