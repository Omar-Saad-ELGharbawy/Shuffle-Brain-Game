using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    Animator cardAnimator;
    SpriteRenderer cardRenderer;

    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    bool isFlipped = false;
    public bool isCardFlipping = false;

    void Start()
    {
        cardAnimator = GetComponent<Animator>();
        cardRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        FlipCard();
    }

    void FlipCard()
    {
        if (isCardFlipping) return;
        isFlipped = !isFlipped;
        cardAnimator.SetBool("Flip", isFlipped);
    }

    void ChangeSprite()
    {
        if (isFlipped)
        {
            cardRenderer.sprite = cardFront;
        }
        else
        {
            cardRenderer.sprite = cardBack;
        }
    }
}
