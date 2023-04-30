using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class screenVictory : MonoBehaviour {

    private Vector3 pointerClick;

    public static int pizzaTotal = 0;

void Awake()
    {
        pizzaTotal = 0;
    }
    void Update(){
        if (Input.GetMouseButtonDown(1)) {
            pointerClick = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
         GameObject.Find("PizzaTotal").GetComponent<TextMeshProUGUI>().text = "Pizzas enviadas: " + pizzaTotal;
    }

    public void gameMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void gamePlay(){
        SceneManager.LoadScene("Main Infinite Scene 1");
    }

    public void gameCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void gameLeave() {
        Application.Quit();
    }
}
