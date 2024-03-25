using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyReferences;

    private GameObject spawnedEnemy;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() 
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0, enemyReferences.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(enemyReferences[randomIndex]);

            if (randomSide == 0) //Spawn enemy from left
            {
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4,10);
            }
            else //Spawn enemy from right
            {
                spawnedEnemy.transform.position = rightPos.position;
                spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                spawnedEnemy.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
