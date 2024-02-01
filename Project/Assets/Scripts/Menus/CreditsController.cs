using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    public RectTransform RTrans;
    public RectTransform FinalPos;
    public float Speed;
    public Image image;

    bool move;
    bool showImage;
    private void Start()
    {
        image.color = Color.clear;
        move = true;
        showImage = false;
    }

    private void FixedUpdate()
    {
        if (move)
        {
            Move();
        }

        if (showImage)
        {
            ShowImage();
        }
    }

    void Move()
    {
        float Distance = RTrans.position.y - FinalPos.position.y;
        if (Distance < 0.2f)
        {
            RTrans.position -= Vector3.down * Speed;
        }
        else
        {
            RTrans.position = FinalPos.position;
            move = false;
            showImage = true;
        }
    }

    void ShowImage()
    {
        if (image.color != Color.white)
        {
            image.color = Color.Lerp(image.color, Color.white, Time.deltaTime);
        }
        else
        {
            showImage = false;
        }
    }
}
