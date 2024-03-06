using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRangeX = 45f;
    public float spawnRangeY = 20f;
    public float radius;
    public LayerMask mask;

    private float timer;
    private bool spawner;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 200f)
        {
            SpawnInArea();
            timer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !spawner)
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

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
  
}
