using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recivePineapple : MonoBehaviour
{
    private int index = 0;
    private static bool touchedFirstTime = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hud.municion < 9)
        {
            if (!touchedFirstTime)
            {
                touchedFirstTime = true;
                index++;
                hud.municion += 5;
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
