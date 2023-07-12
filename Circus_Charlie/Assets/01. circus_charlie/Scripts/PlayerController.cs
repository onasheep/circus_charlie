using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Animator[] playerAnim;
    
    
    private float Jumpspeed = 7f;
    public bool isJump = default;

    // Start is called before the first frame update
    private void Awake()
    {
        playerRigid = this.GetComponent<Rigidbody2D>();
        playerAnim = this.GetComponentsInChildren<Animator>();
    }
   

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {

        float X = GameManager.instance.axisX;

        foreach(Animator anim in playerAnim)
        {
            anim.SetFloat("MoveX", X);
        }



    }

    private void Jump()
    {      
        if(GameManager.instance.InputJump() == true && isJump == false)
        {
            playerRigid.AddForce(Vector2.up * Jumpspeed, ForceMode2D.Impulse);
            isJump = true;
            playerAnim[1].SetBool("isJump", isJump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            isJump = false;
            playerAnim[1].SetBool("isJump", isJump);

        }
    }
}
