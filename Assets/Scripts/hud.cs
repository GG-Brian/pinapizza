using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hud : MonoBehaviour
{
    // Start is called before the first frame update
    public static int vida = 3;
    public static int municion = 5;
    public static int pizza = 0;
    public static int pizzaTotal = 0;
    void Awake()
    {
        vida = 3;
        municion = 5;
        pizza = 0;
        pizzaTotal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Vida").GetComponent<TextMeshProUGUI>().text = "Vida: " + vida;


        GameObject.Find("Munición").GetComponent<TextMeshProUGUI>().text = "Municion: " + municion;


        GameObject.Find("Pizza").GetComponent<TextMeshProUGUI>().text = "Pizza: " + pizza;
    }
}
