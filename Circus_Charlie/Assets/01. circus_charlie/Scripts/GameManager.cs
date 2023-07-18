using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private AudioSource source;
    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip jump;
    public AudioClip win;
    public AudioClip gameover;



    public GameObject bonusText;
    public GameObject scoreText;
    public GameObject distanceText;

    // 스테이지 Ui test 빌드 후 수정 예정
    //public GameObject stageCanvas;
    //public GameObject backGround;
    //private float stageTime = 3.0f;
    //private float time;

    // Distacne magnitude
    public Transform player;
    public Transform finish;

    // Input Horizontal , Background scroll speed
    public float axisX;
    public float ScrollSpeed = 3f;
    
    public float BonusTimer {get; private set; }
    
    public bool isEnding = default;
    public bool isGameOver = default;
    public bool isWinStage = default;
    
    // 점프시 스크롤링 방지용 
    public bool isJump = default;

    public int score = 0;
    public bool getScore = default;

    private float bonusScore = 5000;
    private int distance = 250;

    
    

    private void Awake()
    {
        source = this.GetComponent<AudioSource>();

        if (instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다.");
            this.gameObject.Destroy();
        }

        isWinStage = false;
        isEnding = false;
        getScore = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true) { return; }

        // 스테이지 Ui test 빌드 후 수정 예정
        //time += Time.deltaTime;
        //while(time > stageTime)
        //{
        //    backGround.SetActive(true);
        //    stageCanvas.SetActive(false);
        //    source.PlayOneShot(stage1);

        //}

        if (isJump == false)
        {
        axisX = Input.GetAxis("Horizontal");
        }
   

        BonusTimer += Time.deltaTime * 3f;

        GetScore();

        GetBonusScore();

        GetDistanceText();
        
     
    }


    public bool InputJump()
    {
        if(Input.GetKeyDown(KeyCode.X) && isJump == false)
        {
            source.PlayOneShot(jump);
            return true;
        }

        return false;
    }
    private void GetScore()
    {
        scoreText.SetTMPText((string.Format("SCORE : {0}", score)));
    }

    private void GetBonusScore()
    {
        if(BonusTimer >= 1)
        {
            BonusTimer = 0;
            bonusScore -= 10;
        }
        bonusText.SetTMPText((string.Format("BONUS - {0}", (int)bonusScore)));

        if (bonusScore <= 0)
        {
            isGameOver = true;
        }

    }

    private void GetDistanceText()
    {
        
        
        distance = (int)((player.position - finish.position) / 171 * 100).magnitude ;

       
        distanceText.SetTMPText(string.Format("DISTANCE {0}M", distance));
    }

    public void WinStage()
    {
        source.loop = false;
        source.clip = win;
        source.Play();

        score += (int)bonusScore;
        bonusScore = 0;
        GetDistanceText();
        GetScore();
        isWinStage = true;
    }

    public void GameOver()
    {
        source.loop = false;
        source.clip = gameover;
        source.Play();
        isGameOver = true;

    }
}
