using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<EnemySpawn> enemies = new List<EnemySpawn>();

    public float spawnRate;

    private float timer;

    private void Update() {
        timer += Time.deltaTime;

        if (timer > spawnRate) {
            // Spawn
            var item = enemies[Random.Range(0, enemies.Count)];
            Instantiate(item.enemyObject, item.targetToSpawn.position, Quaternion.identity);
            timer = 0;
            // spawnRate -= Manager.Instance.difficulty * 0.01f;
        }
    }
}

[System.Serializable]
public class EnemySpawn {
    public GameObject enemyObject;
    public Transform targetToSpawn;
}
