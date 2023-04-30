using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public GameObject room;
    public float enemyDetectionDistance = 11f;

    private bool canOpenDoor = false;

    // Update is called once per frame
    void Update()
    {
        CheckConditions();
    }

    private void CheckConditions()
    {
        if (canOpenDoor && Input.GetKeyDown(KeyCode.E) && hud.pizza == 0 && NoEnemiesInRoom())
        {
            door.SetActive(false);
        }
    }

    private bool NoEnemiesInRoom()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemyPizza");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x >= room.transform.position.x && enemy.transform.position.x <= room.transform.position.x + room.GetComponent<Renderer>().bounds.size.x)
            {
                if (Mathf.Abs(enemy.transform.position.x - transform.position.x) < enemyDetectionDistance)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpenDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpenDoor = false;
        }
    }
}