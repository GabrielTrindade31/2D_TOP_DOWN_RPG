using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefab;
    public GameObject boss;
    public float spawnRangeX = 45f;
    public float spawnRangeY = 20f;
    public float radius;
    public LayerMask mask;
    public bool bossAlive = false; // Add this variable to track the boss's status
    private float timer;
    private bool spawner;
    public int maxEnemies = 10;
    private int currentEnemyCount = 0;
    private int totalEnemiesKilled = 0;
    public bool bossSpawned = false;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private Skeleton skeleton;
    private void Start(){
        skeleton = FindAnyObjectByType<Skeleton>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 50f)
        {
            TrySpawnCharacter();
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !spawner)
        {
            TrySpawnCharacter();
        }

        if (totalEnemiesKilled >= 2 && !bossSpawned)
        {
            SpawnBoss();
            bossSpawned = true; // Ensure the boss is only spawned once
        }
        if(GameObject.Find(boss.name)){
            bossAlive = true;
        }else{
            bossAlive = false;
        }

    }


    public void TrySpawnCharacter()
    {
        if (currentEnemyCount < maxEnemies)
        {
            SpawnInArea();
        }
    }
    public void SpawnInArea()
    {

        Vector3 spawnPos;
        int safetyNet = 0;
        do
        {

            spawnPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY),
                0f
            );
            safetyNet++;
            if (safetyNet > 50)
            {
                Debug.LogWarning("Couldn't find a valid spawn position!");
                return; // Exit the function if a valid position isn't found within 50 tries
            }
        } while (Physics2D.OverlapCircle(spawnPos, 1.5f, mask));
        currentEnemyCount++;
        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);
        spawnedEnemies.Add(enemy);

    }
    public void OnEnemyDeath(GameObject enemy)
    {
        // Call this method whenever an enemy dies
        currentEnemyCount--;
        totalEnemiesKilled++;
        spawnedEnemies.Remove(enemy); // Remove the dead enemy from the list
        Destroy(enemy); // Destroy the enemy GameObject
        TrySpawnCharacter(); // Try to spawn another character if one dies
    }

    private void SpawnBoss()
    {
        Vector3 spawnPos;
        int safetyNet = 0;
        do
        {

            spawnPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY),
                0f
            );
            safetyNet++;
            if (safetyNet > 50)
            {
                Debug.LogWarning("Couldn't find a valid spawn position!");
                return; // Exit the function if a valid position isn't found within 50 tries
            }
        } while (Physics2D.OverlapCircle(spawnPos, 1.5f, mask));
        foreach (var enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
        spawnedEnemies.Clear();
        Instantiate(boss, spawnPos, Quaternion.identity);
        

    }
    
}
