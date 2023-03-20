using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaw_Area : MonoBehaviour
{
 
    public GameObject enemyPrefab;
    public float spawnRate = 3f;
    public float spawnRadius = 10f;

    private Transform playerTransform;
    private float nextSpawnTime = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        // Obter a posição do jogador
        Vector2 playerPos = playerTransform.position;

        // Adicionar um deslocamento aleatório
        float xOffset = Random.Range(-spawnRadius, spawnRadius);
        float yOffset = Random.Range(-spawnRadius, spawnRadius);
        Vector2 spawnPos = playerPos + new Vector2(xOffset, yOffset);

        // Instanciar o inimigo na posição gerada
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }


}
