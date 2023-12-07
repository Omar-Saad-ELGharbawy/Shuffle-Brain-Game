using System.Data;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    Animator cardAnimator;
    SpriteRenderer cardRenderer;

    [SerializeField] Sprite cardFront;
    [SerializeField] Sprite cardBack;

    bool isFlipped = false;

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
        if (!Shuffle.canClickItem) return;

        Shuffle.canClickItem = false;

        // GetComponent<AudioSource>().Play();

        // GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();

        // know the pressed by card image
        bool isGameOver = gameObject.name != "Card (1)";

        StartCoroutine(GameObject.Find("Game Manager").GetComponent<Shuffle>().ShowItems(isGameOver));
        if (!isGameOver)
        {
            GameObject.Find("Game Manager").GetComponent<LevelManager>().IncreaseLevel();
        }
    }





    /// <summary>
    /// Flip the card to see the front or back of card
    /// </summary>
    public void FlipCard()
    {
        isFlipped = !isFlipped;
        cardAnimator.SetBool("Flip", isFlipped);
        GameObject.Find("Game Manager").GetComponent<AudioSource>().Play();

    }




    /// <summary>
    ///  Change the image of the card when flipped in the animation (DON'T DELETE)
    /// </summary>
    void ChangeSprite()
    {
        cardRenderer.sprite = isFlipped ? cardFront : cardBack;
    }
}
