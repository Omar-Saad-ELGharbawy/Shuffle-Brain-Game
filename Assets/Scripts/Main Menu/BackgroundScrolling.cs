using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    public float speedx, speedy;
    [SerializeField] RawImage backgroundImage;

    void Update()
    {
        backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + new Vector2(speedx, speedy) * Time.deltaTime, backgroundImage.uvRect.size);
    }
}
