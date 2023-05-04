using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recivePineapple : MonoBehaviour
{
    private static int index = 0;
    private bool alreadyCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !alreadyCollided)
        {
            alreadyCollided = true;

            if (index == 0)
            {
                hud.municion += 5;
            }
            else
            {
                hud.municion += 2 * index;
            }
            index++;
        }
    }
}
