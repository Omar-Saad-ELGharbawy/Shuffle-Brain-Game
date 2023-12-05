using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    int[] originalList = { -5, 0, 5 };
    [SerializeField] GameObject[] ShuffleObjects;

    //void Start()
    //{
    //    InvokeRepeating(nameof(ShuffleList), 0.2f, 1f);
    //}

    /// <summary>
    /// Shuffle the elememnts in a given list
    /// </summary>
    void ShuffleList()
    {
        List<int> newShuffle = originalList.OrderBy(item => Random.value).ToList();
        newShuffle.CopyTo(originalList);



        string stringList = string.Join(", ", newShuffle);
        print(stringList);
    }
}
