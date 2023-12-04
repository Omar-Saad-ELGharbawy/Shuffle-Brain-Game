using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{

    public float x,y,z;
    public GameObject cardBack;
    public GameObject cardFront;

    public bool cardBackIsActive;
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        cardBack.SetActive(false);
        cardFront.SetActive(true);
        cardBackIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     StartCoroutine (CalculateFlip());
        // }
    }

    private void OnMouseDown()
    {
        StartCoroutine (CalculateFlip());
    }


    IEnumerator CalculateFlip()
    {
        for(int i=0;i<180;i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(x,y,z) );
            timer ++;
            
            if(timer == 90  || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }


    public void Flip()
    {
        if(cardBackIsActive)
        {
            cardBack.SetActive(false);
            cardFront.SetActive(true);
            cardBackIsActive = false;
        }
        else
        {
            cardBack.SetActive(true);
            cardFront.SetActive(false);
            cardBackIsActive = true;
        }
    }


}
