using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Ring : MonoBehaviour
{
    public GameObject platformPrefab;

    private GameObject[] platforms;
    public int count = 3; 
    public float timeBetSpawnMin = 2.3f;
    public float timeBetSpawnMax = 4.5f;
    private float timeBetSpawn;
    private Vector2 poolPosition = new Vector2(0, -25f);
    private float lastSpawnTime;

    private float yPos;
    private float xPos;

    public float x;
    public float y;

    private int currentIndex = 0;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.instance.isGameOver)
        //{
        //    return;
        //}
        if (lastSpawnTime + timeBetSpawn <= Time.time)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            yPos = mainCamera.transform.position.y - y;
            xPos = mainCamera.transform.position.x + x;

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex += 1;

            if (count <= currentIndex)
            {
                currentIndex = 0;
            }
        }
    }
}
