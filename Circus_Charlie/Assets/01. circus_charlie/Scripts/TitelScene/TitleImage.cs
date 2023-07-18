using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleImage : MonoBehaviour
{
    private Image titleImage;

    public Sprite image1;
    public Sprite image2;
    public Sprite image3;

    private float time = default;
    private float changeTime = 0.1f;

    // Start is called before the first frame update

    private enum TYPE
    {
        IMAGE1, IMAGE2, IMAGE3
    }


    TYPE type = TYPE.IMAGE1;
    private void Awake()
    {
        titleImage = GetComponent<Image>();
        titleImage.sprite = image1;
        time = 0f;
    }
 
    private void Update()
    {
        time += Time.deltaTime;
        while (time > changeTime)
        {
            switch (type)
            {
                case TYPE.IMAGE1:
                    titleImage.sprite = image1;
                    type = TYPE.IMAGE2;
                    break;
                case TYPE.IMAGE2:
                    titleImage.sprite = image2;
                    type = TYPE.IMAGE3;
                    break;
                case TYPE.IMAGE3:
                    titleImage.sprite = image3;
                    type = TYPE.IMAGE1;
                    break;

            }
            time = 0;
        }

     
    }

}
