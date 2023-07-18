using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackGroundLoop : MonoBehaviour
{

    public Transform[] scrollBackGround;
    public Transform[] backGroundPool;
    public BoxCollider2D[] backGroundCollider;

    public Transform startBackGround;
    public Transform endBackGround;

    private int backgroundCnt;

    private int loopCnt = 0;

    private bool tryBack = false;

    // Start is called before the first frame update


    private void Awake()
    {

        backgroundCnt = backGroundPool.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if(tryBack == false)
        {
            foreach (Transform tr in scrollBackGround)
            {
                ScrollingObject(tr);
            }
        }

        BlockBehind(backGroundPool[loopCnt]);




        if (backGroundPool[loopCnt].position.x <= - backGroundCollider[loopCnt].size.x * 2 )
        {
            Reposition();
            loopCnt += 1;

            if (loopCnt >= backgroundCnt)
            {
                loopCnt = 0;
            }       
        }


        EndCheck();
    }

    private void Reposition()
    {

        
        Vector2 offSet = new Vector2(backGroundCollider[loopCnt].size.x * 4f, 0f);

        // LEGACY :
        // transform.position = (Vector2)transform.position + offset;
        backGroundPool[loopCnt].position = (Vector2)backGroundPool[loopCnt].position.AddVector(offSet);
    }
    private void EndCheck()
    {
        if(endBackGround.transform.position.x < 5f)
        {
            GameManager.instance.isEnding = true;
            GameManager.instance.ScrollSpeed = 0f;
        }
    }

    private void BlockBehind(Transform tr)
    {
        if (tr.position.x < -3.5f && GameManager.instance.axisX < 0)
        {
            tryBack = true;
            GameManager.instance.ScrollSpeed = 0f;
        }
        else
        {
            tryBack = false;

            GameManager.instance.ScrollSpeed = 3f;
        }
    }


    // 배경을 뒤로 미는 기능
    private void ScrollingObject(Transform tr)
    {
        if (GameManager.instance.isGameOver == true) { return; }


        if (GameManager.instance.isJump == false)
        {
            Scroll(tr);
        }
        else
        {
            tr.Translate(Vector3.left * GameManager.instance.ScrollSpeed * GameManager.instance.axisX * Time.deltaTime);
        }

    }

    private void Scroll(Transform tr)
    {

        tr.Translate(Vector3.left * GameManager.instance.ScrollSpeed * GameManager.instance.axisX * Time.deltaTime);

    }
}


