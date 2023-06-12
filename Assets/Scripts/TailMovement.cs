using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovement : MonoBehaviour
{
    public float Speed;

    public Vector3 tailTarget;

    public int index;

    public GameObject tailTargetObj;

    public SnakeMovement snakeMovement;

    void Start()
    {
        snakeMovement = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
        Speed = snakeMovement.speed;
        tailTargetObj = snakeMovement.tailObjects[snakeMovement.tailObjects.Count - 2];
        index = snakeMovement.tailObjects.IndexOf(gameObject);
    }

    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime*Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead")) {
            if (index > 2) {
                if (Level.level == 1) {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                } else {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
        if (other.CompareTag("BG")) {
            SceneManager.LoadScene("GameOver");
        }
    }
}
