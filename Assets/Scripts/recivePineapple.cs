using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recivePineapple : MonoBehaviour
{
    private int index = 0;
    private static bool touchedFirstTime = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hud.municion < 9)
        {
            if (!touchedFirstTime)
            {
                touchedFirstTime = true;
                index++;
                hud.municion += 5;
                Debug.Log("lol");
            }
            if (index == 0)
            {
                hud.municion += 2;
                index++;
            }
            //hud.score++;
        }
    }


}
