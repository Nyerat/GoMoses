using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject ripple;

    public GameObject[] EnemyList;
    public GameObject[] SpawnPoints;


    public float distanceBetweenEnemies;



    public float spawnTimeMin;
    public float spawnTimeMax;
    public float spawnTimeChosen;
    public float counter;

    private void Start()
    {

    }

    private void Update()
    {
        int r = Random.Range(0, EnemyList.Count());
        
        if (counter <= 0)
        {
            spawnTimeChosen = Random.Range(spawnTimeMin, spawnTimeMax);
            counter = spawnTimeChosen;
        }
        else
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                Debug.Log("Spawning Enemy!");
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        int r1 = Random.Range(0, EnemyList.Count());
        int r2 = Random.Range(0, SpawnPoints.Count());

        GameObject enemyspawning = EnemyList[r1];
        GameObject selectedspawn = SpawnPoints[r2];

        Instantiate(enemyspawning, selectedspawn.transform.position, selectedspawn.transform.rotation);
    }

    
}
