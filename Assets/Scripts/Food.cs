using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    public GameObject snake;

    void Start()
    {
        snake = GameObject.FindGameObjectWithTag("SnakeHead");
        AudioSource = snake.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead")) {
            other.GetComponent<SnakeMovement>().AddTail();
            AudioSource.PlayOneShot(AudioClip);
            Destroy(gameObject);
        }
    }
}
