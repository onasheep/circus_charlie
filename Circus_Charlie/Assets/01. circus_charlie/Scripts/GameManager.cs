using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float axisX;
    public float scrollSpeed { get; private set; }
    public bool isGameOver = default;
    
    private void Awake()
    {
        if(instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다.");
            this.gameObject.Destroy();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        scrollSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        axisX = Input.GetAxis("Horizontal");
    }

    public bool InputJump()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {

            return true;
        }

        return false;
    }

}
