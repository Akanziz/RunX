using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteoriteSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteoritePrefab;
    public float spawnInterval = 1f;
    private float timer;

    private float leftBoundary;
    private float rightBoundary;
    
     void Start()
     {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        leftBoundary = -screenWidth;
        rightBoundary = screenWidth;
     }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnMeteorite();
            timer = 0f;
        }
    }

    void SpawnMeteorite()
    {
        float spawnX = UnityEngine.Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(spawnX, 6f, 0f);
        Debug.Log("Spawning Meteorite at: " + spawnPosition);
        Instantiate(meteoritePrefab, spawnPosition, Quaternion.identity);
    }
}
