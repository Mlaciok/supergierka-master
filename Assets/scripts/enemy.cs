using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform player;
    public GameObject enemys;
    public int NuberOfZombies = 50;
    public float spawnRadius = 10f;
    public float spawnDelay = 1f;

    void Start()
    {
        // SpawnZombies();
        StartCoroutine(SpawnZombiesGradually());

    }

    IEnumerator SpawnZombiesGradually()
    {
        for (int i = 0; i < NuberOfZombies; i++)
        {
            Vector2 randomPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(enemys, new Vector3(randomPosition.x, randomPosition.y, 0), Quaternion.identity);

            EnemyMovement movement = enemys.GetComponent<EnemyMovement>();
            if (movement != null)
            {
                movement.player = player;
            }

            yield return new WaitForSeconds(spawnDelay);

        }
    }


    // void SpawnZombies()
    //  {
    //     for (int i = 0; i < NuberOfZombies; i++)
    //     {
    //        Vector2 randomPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;
    //         Instantiate(enemys, new Vector3(randomPosition.x, randomPosition.y, 0), Quaternion.identity);
    //
    //    }
    //  }


}
