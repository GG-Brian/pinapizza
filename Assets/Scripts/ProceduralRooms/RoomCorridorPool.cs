using System.Collections.Generic;
using UnityEngine;

public class RoomCorridorPool : MonoBehaviour
{
    public static RoomCorridorPool SharedInstance;

    [Header("Object Pooling Settings")]
    public List<GameObject> pooledRooms;
    public List<GameObject> roomPrefabs;
    public int amountToPoolRooms;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledRooms = new List<GameObject>();

        GameObject temp;

        // Pool rooms
        for (int i = 0; i < amountToPoolRooms; i++)
        {
            temp = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
            temp.SetActive(false);
            pooledRooms.Add(temp);
        }
    }

    public GameObject GetPooledRoom(GameObject prefab)
    {
        foreach (GameObject obj in pooledRooms)
        {
            if (!obj.activeInHierarchy && obj.name.Contains(prefab.name))
            {
                return obj;
            }
        }

        // If there's no available object, create a new one and add it to the pool
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        pooledRooms.Add(newObj);
        newObj.name = prefab.name;
        return newObj;
    }
}
