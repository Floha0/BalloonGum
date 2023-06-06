using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startTime = 1f;
    private float repeatTime = 2f;
    public GameObject[] obstaclePrefab;
    private PlayerController playerControllerSc;

    void Start()
    {
        InvokeRepeating("spawn", startTime, repeatTime);
        playerControllerSc = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void spawn(){
        if (!playerControllerSc.gameOver)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[obstacleIndex], new Vector3(18, 0, 0), obstaclePrefab[obstacleIndex].transform.rotation);    
        }
    }
}
