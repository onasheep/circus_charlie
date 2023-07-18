using UnityEngine;

public class ObastacleSpawner : MonoBehaviour
{
    public GameObject ringOfFireS;
    public GameObject ringOfFireB;
    public GameObject fireJar;

    public GameObject ringPool;
    public GameObject jarPool;

    // fireB 5 fireS 2 fireJar 3
    private int ringCount = 7;
    private int jarCount = 10;
    private int poolCount = 2;

    private float timeBetSpawnMin = 3f;
    private float timeBetSpawnMax = 5f;

    private float timeBetSpawn;
    
    private float lastSpawnTime;


    // 담기는 것이 확인되면 private로 할것 
    public GameObject[] ringObstacles;
    public GameObject[] jarObstacles;
    public Transform[] pools;
    //private Vector2 ringPosition = new Vector2(0f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        InitPrefabs();
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }



    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.isGameOver == true) { return; }
        if (GameManager.instance.isEnding == true)
        {
            this.gameObject.SetActive(false);
        }

        OnEnabelRings();
        

    }


    // 프리팹 만들기
    private void InitPrefabs()
    {
        ringObstacles = new GameObject[ringCount];
        jarObstacles = new GameObject[jarCount];
        pools = new Transform[poolCount];

        // ObstalceSpawner 본인이 들어가버림 0번
        pools = this.GetComponentsInChildren<Transform>();


        for (int i = 0; i < ringCount; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                    ringObstacles[i] = Instantiate(ringOfFireS, pools[1]);
                    ringObstacles[i].SetActive(false);
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    ringObstacles[i] = Instantiate(ringOfFireB, pools[1]);
                    ringObstacles[i].SetActive(false);
                    break;             
            }
        }

        for(int i = 0; i < jarCount; i++)
        {
            jarObstacles[i] = Instantiate(fireJar, pools[2].transform.position + new Vector3(15f * i, 0f),Quaternion.identity);
            
        }

    }

    private void OnEnabelRings()
    {

        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {

            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin,timeBetSpawnMax);

            int randNum = Random.Range(0, 7);


            if (ringObstacles[randNum].activeSelf == false)
            {
                ringObstacles[randNum].SetActive(true);
            }
        
        }     
    }

    private void OnEnableJars()
    {
        if(Time.time >= GameManager.instance.BonusTimer / 6)
        {

        }
       
    }
}
