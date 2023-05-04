using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawning Settings")]
    public GameObject enemyPizzaPrefab;
    public Transform playerTransform;
    public int initialRoom;

    private ProceduralRooms proceduralRooms;
    private int currentRoom;
    private int previousRoom;

    // Start is called before the first frame update
    void Start()
    {
        proceduralRooms = GetComponent<ProceduralRooms>();
        currentRoom = initialRoom;
        previousRoom = initialRoom;
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayerRoom();
    }

    private void TrackPlayerRoom()
    {
        float roomWidth = proceduralRooms.roomWidth;
        currentRoom = Mathf.FloorToInt((playerTransform.position.x + roomWidth / 2) / roomWidth);

        if (currentRoom != previousRoom)
        {
            SpawnEnemies();
            previousRoom = currentRoom;
        }
    }

    private void SpawnEnemies()
{
    int enemyCount = Mathf.CeilToInt(currentRoom * 0.6f); // Increase enemy count based on the room number
    GameObject currentRoomObj = proceduralRooms.rooms[currentRoom % proceduralRooms.rooms.Count];

    for (int i = 0; i < enemyCount; i++)
    {
        float currentRoomX = currentRoom * proceduralRooms.roomWidth;
        Vector3 spawnPosition = new Vector3(
            currentRoomX + Random.Range(0, 9.5f),
            Random.Range(-3.5f, 2.5f),
            0
        );

        GameObject spawnedEnemy = Instantiate(enemyPizzaPrefab, spawnPosition, Quaternion.identity);

        enemyController controller = spawnedEnemy.GetComponent<enemyController>();
        controller.shootInterval *= Mathf.Pow(1f / 1.33f, currentRoom / 10); // Make the enemy shoot progressively faster every 10 rooms
        

        if (currentRoom % 5 == 0 && i == 0) // Check if it's a multiple of 5 and the first enemy in the room
        {
            spawnedEnemy.transform.localScale *= 2; // Make the enemy twice as large
            controller.shootInterval *= 0.8333f * Mathf.Pow(1f / 1.33f, currentRoom / 10); // Make the boss enemy shoot progressively faster
            StartCoroutine(MoveBossUpAndDown(spawnedEnemy.transform)); // Start the coroutine to move the boss enemy up and down        
        }
        else
        {
            controller.shootInterval *= Mathf.Pow(1f / 1.33f, currentRoom / 10); // Make the enemy shoot progressively faster every 10 rooms
        }
    }
}

private IEnumerator MoveBossUpAndDown(Transform bossTransform)
{
    float minY = -3.5f;
    float maxY = 2.5f;
    float speed = 0.5f;
    float t = 0;

    while (true)
    {
        if (bossTransform == null) // Check if the bossTransform is null
        {
            break; // If it is, break out of the loop and end the coroutine
        }

        float newY = Mathf.Lerp(minY, maxY, t);
        bossTransform.position = new Vector3(bossTransform.position.x, newY, bossTransform.position.z);
        t += Time.deltaTime * speed;

        if (t >= 1)
        {
            t = 0;
            float temp = minY;
            minY = maxY;
            maxY = temp;
        }

        yield return null;
    }
}

}