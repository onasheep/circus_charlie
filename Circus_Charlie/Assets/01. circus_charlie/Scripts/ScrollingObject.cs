using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == true || GameManager.instance.isWinStage == true) { return; }


        if (GameManager.instance.isJump == false)
        {
            Scroll();
        }
        else
        {
            transform.Translate(Vector3.left * GameManager.instance.ScrollSpeed * GameManager.instance.axisX * Time.deltaTime);
        }




    }

    private void Scroll()
    {

        transform.Translate(Vector3.left * GameManager.instance.ScrollSpeed * GameManager.instance.axisX * Time.deltaTime);

    }
}
