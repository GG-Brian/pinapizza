using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    //public int municion = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("right") || Input.GetKey("d")){
            //transform.localScale = new Vector3(normal, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x + 5f * Time.deltaTime, transform.position.y, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Derecha tecla pulsada");
        }

        if(Input.GetKey("left") || Input.GetKey("a")){
            //transform.localScale = new Vector3(invertido, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x - 5f * Time.deltaTime, transform.position.y, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Izquierda tecla pulsada");
        }

         if(Input.GetKey("up") || Input.GetKey("w")){
            //transform.localScale = new Vector3(normal, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f * Time.deltaTime, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Derecha tecla pulsada");
        }

        if(Input.GetKey("down") || Input.GetKey("s")){
            //transform.localScale = new Vector3(invertido, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x , transform.position.y - 5f * Time.deltaTime, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Izquierda tecla pulsada");
        }

        if (Input.GetMouseButtonDown(0) && hud.municion > 0) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;
            Vector3 direction = (mousePosition - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            hud.municion--;
        }
    }

      void OnTriggerEnter2D (Collider2D colision){
        while(colision.gameObject.tag == "recivePineapple" && hud.municion < 10){
            Debug.Log("Choca con el Player");
            hud.municion++;
            //hud.score++;
        }       
        if(colision.gameObject.tag == "sendPizza" && hud.pizza > 0){
            hud.pizza = 0;
        }
    }
}
