using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public bool disparar = false;
    public GameObject bulletEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBullet");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diferencia = GameObject.Find("Player").transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 1, transform.position.y), diferencia.normalized, 10f);
        Debug.DrawRay(new Vector2(transform.position.x - 1, transform.position.y), diferencia.normalized * 10f, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("Rayo toca a: " + hit.collider.name);
            if (hit.collider.name == "Player")
            {
                disparar = true;
            }
            else
            {
                disparar = false;
            }
        }
        else
        {
            Debug.Log("Rayo no toca nada");
            disparar = false;
        }
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
            Instantiate(bulletEnemyPrefab, transform.position, Quaternion.identity);
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("DisparoEnemy");
            yield return new WaitForSeconds(2.5f);
        }

        /*
while(true){
    //if((GameObject.FindGameObjectWithTag("bala") == null) && (disparar)){
        Instantiate(bulletEnemyPrefab,transform.position,Quaternion.identity);
        //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("DisparoEnemy");
        yield return new WaitForSeconds(2.5f);
    //}else{
        yield return null;
    //}

}*/
    }
}
