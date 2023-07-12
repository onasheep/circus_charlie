using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private float speed = 2f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector3.left * /*GameManager.instance.scrollSpeed*/ speed * GameManager.instance.axisX * Time.deltaTime);
        }
    }
}
