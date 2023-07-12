using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SpriteRenderer spirteRend = default;
    
    public float speed = 3f;
    private float realSpeed = default;
    
    private float time = default;
    private float changeTime = 0.5f;

    private enum FireType
    {
        NONE, Fire1, Fire2
    }

    FireType myType = FireType.NONE;

    public Sprite fireImage1;
    public Sprite fireImage2;

    // Start is called before the first frame update

    private void OnEnable()
    {
        spirteRend = GetComponent<SpriteRenderer>();
        if (myType == FireType.NONE)
        {
            spirteRend.sprite = fireImage1;
        }
    }
    // LEGACY :
    //void Start()
    //{
    //    spirteRend = GetComponent<SpriteRenderer>();
    //    if(myType == FireType.NONE)
    //    {
    //        spirteRend.sprite = fireImage1;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            time += Time.deltaTime;

            // 플레이어가 움직였을때 이동하는 값을 보정한 속도
            realSpeed = (speed + GameManager.instance.axisX * 2f);

            transform.Translate(Vector3.left * realSpeed * Time.deltaTime);

            if(time > changeTime)
            {
                SpriteChagne();
            }
            
        }
    }

    private void SpriteChagne()
    {
        switch (myType)
        {
            case FireType.NONE:
                spirteRend.sprite = fireImage2;
                myType = FireType.Fire1;
                time = 0f;
                break;
            case FireType.Fire1:
                spirteRend.sprite = fireImage1;
                myType = FireType.Fire2;
                time = 0f;
                break;
            case FireType.Fire2:
                spirteRend.sprite = fireImage2;
                myType = FireType.Fire1;
                time = 0f;
                break;

        }
    }
}
