using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Shuffle : MonoBehaviour
{
    List<int> transformList = new List<int>();
    List<int> shuffledList = new List<int>();

    public static int levelNum = 0;
    public static int shuffleCount = 5;
    public static float suffleDuration = 1.0f;

    public float moveSpeed = 0.5f;

    public GameObject ball;
    [SerializeField] private List<GameObject> shuffleObjects = new List<GameObject>();

    private void Awake()
    {
        GetShufflingObjects();
    }
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(ShuffleList());
        }
    }

    void GetShufflingObjects()
    {
        // Assuming your cups have a specific tag, adjust this based on your setup
        GameObject[] shuffleObjects = GameObject.FindGameObjectsWithTag("Shuffle");

        foreach (GameObject shuffle in shuffleObjects)
        {
            this.shuffleObjects.Add(shuffle);
            transformList.Add((int)shuffle.transform.position.x);
        }
    }

    // <summary>
    // Shuffle the elememnts in a given list
    // </summary>
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
