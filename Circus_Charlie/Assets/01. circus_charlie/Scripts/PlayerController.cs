using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigid;
    private Animator[] playerAnim;
    
    
    private float Jumpspeed = 7.0f;
    public bool isJump = default;
    private bool getScore = default;


    // Start is called before the first frame update
    private void Awake()
    {
        playerRigid = this.GetComponent<Rigidbody2D>();
        playerAnim = this.GetComponentsInChildren<Animator>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameOver == true ) { return; }
        if(GameManager.instance.isWinStage == true) { return; }
        Move();
        Jump();
        
        GameManager.instance.isJump = isJump;

    }

    private void Move()
    {

        float X = GameManager.instance.axisX;

        foreach(Animator anim in playerAnim)
        {
            anim.SetFloat("MoveX", X);
        }
        if(GameManager.instance.isEnding == true)
        {
            this.transform.Translate(Vector2.right * X * 3f * Time.deltaTime);            
            
        }


    }

    private void Jump()
    {      
        if(GameManager.instance.InputJump() == true && isJump == false)
        {
            isJump = true;
            playerAnim[1].SetBool("isJump", isJump);

            GameManager.instance.isJump = isJump;
   
                playerRigid.AddForce(Vector2.up * Jumpspeed, ForceMode2D.Impulse);
         
        }
    }

    public void Die()
    {
        GFunc.Log("ав╬З╫ю╢о╢ы!");
        GameManager.instance.GameOver();

        foreach(Animator anim in playerAnim)
        {
            anim.SetTrigger("Die");
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            isJump = false;
            playerAnim[1].SetBool("isJump", isJump);

            if (getScore == true)
            {
                GameManager.instance.score += 100;
                getScore = false;

            }
        }

        if (collision.collider.tag.Equals("Finish"))
        {
            isJump = false;
            playerAnim[0].SetTrigger("Win");
            playerAnim[1].SetBool("isJump", isJump);
            playerAnim[1].SetFloat("MoveX", 0f);
            GameManager.instance.WinStage();
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Score"))
        {
            getScore = true;
        }
    }
}
