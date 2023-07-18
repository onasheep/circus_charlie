using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    private SpriteRenderer spirteRend = default;


    private float time = default;
    private float changeTime = 0.1f;

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

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == true) { return; }

        time += Time.deltaTime;

        if (time > changeTime)
        {
            SpriteChagne();
            time = 0f;
        }

    }

    private void SpriteChagne()
    {
        switch (myType)
        {
            case FireType.NONE:
                spirteRend.sprite = fireImage2;
                myType = FireType.Fire1;
                break;
            case FireType.Fire1:
                spirteRend.sprite = fireImage1;
                myType = FireType.Fire2;
                break;
            case FireType.Fire2:
                spirteRend.sprite = fireImage2;
                myType = FireType.Fire1;
                break;

        }
    }
}
