using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemySpawn;
    public float interval = 5f;
    public float lowerX;
    public float upperX;
    public float lowerZ;
    public float upperZ;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(interval, enemySpawn));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(lowerX, upperX), 1, Random.Range(lowerZ, upperZ)), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy));
    }

    
}
