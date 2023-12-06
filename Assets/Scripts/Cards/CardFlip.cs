using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    Animator cardAnimator;
    SpriteRenderer cardRenderer;

    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    public LevelManager level;

    bool isFlipped = false;
    public bool isCardFlipping = false;

    void Start()
    {
        cardAnimator = GetComponent<Animator>();
        cardRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Check if the player clicked on a card
    /// </summary>
    private void OnMouseDown()
    {
        // know the pressed by card image
        if(gameObject.name == "Card (1)"){
            level.LevelUp();

        }

        if (isFlipped) return;
        FlipCard();
        Invoke(nameof(FlipCard), 2f);
    }

    /// <summary>
    /// Flip the card to see the front or back of card
    /// </summary>
    public void FlipCard()
    {
        if (isCardFlipping) return;
        isFlipped = !isFlipped;
        cardAnimator.SetBool("Flip", isFlipped);
    }

    /// <summary>
    ///  Change the image of the card when flipped in the animation
    /// </summary>
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
