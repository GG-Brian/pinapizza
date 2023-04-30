using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pineapplePizza : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D colision){       
        if(colision.gameObject.tag == "Player"){
            Destroy(gameObject); // Bale player
            //GameObject.Find("SoundManager").GetComponent<soundManager>().PlayAudio("choque");
            //hud.score++;
        }
    }
}
