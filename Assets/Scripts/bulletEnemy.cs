using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bulletEnemy : MonoBehaviour
{
    public static float bulletSpeed = 5f;

    //bool pass = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 diferencia = GameObject.Find("Player").transform.position - transform.position;        
        GetComponent<Rigidbody2D>().velocity = diferencia.normalized * bulletSpeed;
        Destroy(gameObject, 10f);
        // pass=false;
    }

    void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Choca con el Player");
            SoundManager.Instance.PlayAudio(colision.GetComponent<playerController>()._audioSource, SoundManager.Instance.sounds[0]);
            hud.vida--;
            if (hud.vida == 0)
            {
                SceneManager.LoadScene("Lose", LoadSceneMode.Single);
            }

        }
        if (colision.gameObject.tag == "PlayerBullet")
        {
            Destroy(colision.gameObject); // Bale player
            Destroy(gameObject); // Bala enemigo
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("choque");
            //hud.score++;
        }
    }
}
