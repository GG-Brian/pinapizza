using System.Collections.Generic;
using UnityEngine;

public class ProceduralRooms : MonoBehaviour
{
    [Header("Room Generation Settings")]
    public int initialRoomCount = 10;
    public List<GameObject> roomPrefabs;
    public float roomWidth;
    public Transform playerTransform;
    public float distanceThreshold = 2f;
    public float resetThreshold = 5f;

    public List<GameObject> rooms;
    private float currentX;

    // Start is called before the first frame update
    private void Start()
    {
        rooms = new List<GameObject>();
        currentX = 0;
        GenerateInitialRooms();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckDistanceToLastRoom();
        // CheckPlayerPosition();
    }

    // Generate the initial set of rooms
    private void GenerateInitialRooms()
    {
        for (int i = 0; i < initialRoomCount; i++)
        {
            GenerateRoom();
        }
    }

    // Generate a single room, selecting a random prefab from the list
    private void GenerateRoom()
    {
        GameObject randomRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Count)];

        if (rooms.Count > 0)
        {
            currentX += roomWidth;
        }

        GameObject room = RoomCorridorPool.SharedInstance.GetPooledRoom(randomRoomPrefab);
        if (room != null)
        {
            room.transform.position = new Vector3(currentX, 0, 0);
            room.transform.rotation = Quaternion.identity;
            room.transform.SetParent(transform);
            room.SetActive(true);
            rooms.Add(room);
        }
    }

    // Check the distance between the player and the last room
    private void CheckDistanceToLastRoom()
    {
        if (playerTransform.position.x + distanceThreshold >= rooms[rooms.Count - 1].transform.position.x)
        {
            GenerateRoom();
            RemoveOldestRoom();
        }
    }

    // Remove the oldest room
    private void RemoveOldestRoom()
    {
        if (rooms.Count > 0)
        {
            rooms[0].SetActive(false);
            rooms.RemoveAt(0);
        }
    }

    // Check player's position to move both the player and the room hierarchy
    // private void CheckPlayerPosition()
    // {
    //     if (playerTransform.position.x >= resetThreshold)
    //     {
    //         playerTransform.position = new Vector3(playerTransform.position.x - roomWidth, playerTransform.position.y, playerTransform.position.z);
    //         transform.position = new Vector3(transform.position.x - roomWidth, transform.position.y, transform.position.z);
    //     }
    // }
}
