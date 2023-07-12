using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObastacleSpawner : MonoBehaviour
{
    public GameObject ringOfFireS;
    public GameObject ringOfFireB;
    public GameObject fireJar;
    public GameObject ringPool;
    public GameObject jarPool;

    // 풀에 들어갈 갯수는 10개 fireB 5 fireS 2 fireJar 3
    private int obsCount = 10;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    private float jarPosX = default;
    private float jarPosY = -3.2f;

    // 담기는 것이 확인되면 private로 할것 
    public GameObject[] obstacles;
    //private Vector2 ringPosition = new Vector2(0f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        InitPrefabs();
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    // 프리팹 만들기
    private void InitPrefabs()
    {
        obstacles = new GameObject[obsCount];

        for (int i = 0; i < obsCount; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                    obstacles[i] = Instantiate(ringOfFireS, ringPool.transform/*.position, Quaternion.identity*/);
                    obstacles[i].SetActive(false);
                    break;
                case 3:
                case 4:
                case 5:
                case 6:
                    obstacles[i] = Instantiate(ringOfFireB, ringPool.transform/*.position, Quaternion.identity*/);
                    obstacles[i].SetActive(false);
                    break;
                case 7:
                case 8:
                case 9:
                    obstacles[i] = Instantiate(fireJar, jarPool.transform/*.position, Quaternion.identity*/);
                    obstacles[i].SetActive(false);
                    break;


            }
        }
    }

    private void OnEnabelPrefabs()
    {
        
    }
}
