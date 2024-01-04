using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Wave(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Wave(int wave)
    {
        for(int i = 0; i < wave; i++)
        {
            SpawnEnemy("normal", Vector3.up);
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
}
