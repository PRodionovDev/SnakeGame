using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Borders : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead")) {
            if (Level.level == 1) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } else {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
