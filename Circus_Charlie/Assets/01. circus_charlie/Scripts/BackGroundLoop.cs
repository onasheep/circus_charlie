using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width = default;
    // Start is called before the first frame update

    private void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width * 2f)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offSet = new Vector2(width * 3.5f, 0f);

        // LEGACY :
        // transform.position = (Vector2)transform.position + offset;
        this.transform.position = this.transform.position.AddVector(offSet);
    }
}
