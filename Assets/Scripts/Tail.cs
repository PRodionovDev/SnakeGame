using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int index;

    public Vector3 tailTarget;

    public GameObject tailTargetObj;
    public Snake snake;

    void Start()
    {
        snake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<Snake>();
        tailTargetObj = snake.tailObjects[snake.tailObjects.Count - 2];
        index = snake.tailObjects.IndexOf(gameObject);
    }

    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        Move();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead")) {
            if (index > 4) {
                Scene.gameOver();
            }
        }
    }

    private void Move()
    {
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime*snake.speed);
    }
}
