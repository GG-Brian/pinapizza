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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Vida").GetComponent<TextMeshProUGUI>().text = "Vida: " + vida;


        GameObject.Find("Munición").GetComponent<TextMeshProUGUI>().text = "Municion: " + municion;


        GameObject.Find("Pizza").GetComponent<TextMeshProUGUI>().text = "Pizza: " + pizza;
    }
}
