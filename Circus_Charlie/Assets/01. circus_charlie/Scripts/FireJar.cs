using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireJar : MonoBehaviour
{


    public float speed = 0f;
    private float realSpeed = default;

    // Start is called before the first frame update

    // Update is called once per frame

    void Update()
    {
        if (GameManager.instance.isGameOver) { return; }
         

        // �÷��̾ ���������� �̵��ϴ� ���� ������ �ӵ�
        realSpeed = (speed + GameManager.instance.axisX * GameManager.instance.ScrollSpeed);

        transform.Translate(Vector3.left * realSpeed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Die();

        }
    }
}

