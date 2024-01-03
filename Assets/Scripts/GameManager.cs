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
            Debug.Log("spawn enemy");
        }
    }

    void SpawnEnemy(string type, Vector3 position)
    {
        
    }
}
