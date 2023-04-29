using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey("right")){
            //transform.localScale = new Vector3(normal, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x + 5f * Time.deltaTime, transform.position.y, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Derecha tecla pulsada");
        }

        if(Input.GetKey("left")){
            //transform.localScale = new Vector3(invertido, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x - 5f * Time.deltaTime, transform.position.y, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Izquierda tecla pulsada");
        }

         if(Input.GetKey("up")){
            //transform.localScale = new Vector3(normal, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f * Time.deltaTime, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Derecha tecla pulsada");
        }

        if(Input.GetKey("down")){
            //transform.localScale = new Vector3(invertido, transform.localScale.y,transform.localScale.z);
            transform.position = new Vector3(transform.position.x , transform.position.y - 5f * Time.deltaTime, 0);
            //GetComponent<Animator>().SetBool("moving",true);
            Debug.Log("Izquierda tecla pulsada");
        }
    }
}
