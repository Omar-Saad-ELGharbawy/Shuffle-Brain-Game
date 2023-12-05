using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsShow : MonoBehaviour
{
    [SerializeField] GameObject[] cards;


    void Start()
    {
        Invoke(nameof(FlipAllCards), 1f);
        Invoke(nameof(FlipAllCards), 4f);
    }

    void FlipAllCards()
    {
        foreach (var card in cards)
        {
            CardFlip flipScript = card.GetComponent<CardFlip>();
            flipScript.FlipCard();
        }
    }

}
