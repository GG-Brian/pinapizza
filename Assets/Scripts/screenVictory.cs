using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenVictory : MonoBehaviour {

    private Vector3 pointerClick;

    void Update(){
        if (Input.GetMouseButtonDown(1)) {
            pointerClick = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    public void gameMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void gamePlay(){
        SceneManager.LoadScene("Main Infinite Scene");
    }

    public void gameCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void gameLeave() {
        Application.Quit();
    }
}
