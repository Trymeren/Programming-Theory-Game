using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    private int waveLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Wave(5);
        }

        CheckForEnemiesLeft();
    }

    void Wave(int wave)
    {
        for(int i = 0; i < wave; i++)
        {
            float[] xRange = {-24, 24};
            float[] zRange = {-12.5f, 12.5f};
            Vector3 spawnPosition;

            if (Random.Range(0,2) == 0)
            {
                spawnPosition = new Vector3(Random.Range(-24.0f, 24.0f), 1, zRange[Random.Range(0, zRange.Length)]);
            }
            else
            {
                spawnPosition = new Vector3(xRange[Random.Range(0, xRange.Length)], 1, Random.Range(-12.5f, 12.5f));
            }

            SpawnEnemy("normal", spawnPosition);
        }
    }

    void SpawnEnemy(string type, Vector3 position)
    {
        GameObject enemyToSpawn = null;
        if(type == "dummy")
        {
            enemyToSpawn = enemyPrefabs[0];
        }
        else if (type == "normal")
        {
            enemyToSpawn = enemyPrefabs[1];
        }
        Instantiate(enemyToSpawn, position, enemyToSpawn.transform.rotation);
    }

    void CheckForEnemiesLeft()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            waveLevel++;
            Wave(waveLevel);
        }
    }
}
