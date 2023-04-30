using System.Collections.Generic;
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
    int enemyCount = Mathf.CeilToInt(currentRoom * 0.5f); // Increase enemy count based on the room number
    GameObject currentRoomObj = proceduralRooms.rooms[currentRoom];

    for (int i = 0; i < enemyCount; i++)
    {
        Vector3 spawnPosition = new Vector3(
            currentRoomObj.transform.position.x + Random.Range(0, 9.5f),
            Random.Range(-3.5f, 2.5f),
            0
        );

        GameObject spawnedEnemy = Instantiate(enemyPizzaPrefab, spawnPosition, Quaternion.identity);
        
        if (currentRoom % 5 == 0 && i == 0) // Check if it's a multiple of 5 and the first enemy in the room
        {
            spawnedEnemy.transform.localScale *= 2; // Make the enemy twice as large
            enemyController controller = spawnedEnemy.GetComponent<enemyController>();
            controller.shootInterval = 0.8333f; // Make the enemy shoot three times faster (2.5f / 3)
        }
    }
}
}