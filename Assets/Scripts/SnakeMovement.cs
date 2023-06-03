using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2;

    public float RotationSpeed = 100;

    public List<GameObject> tailObjects = new List<GameObject>();

    public float z_offset = 3f;

    public GameObject TailPrefab;

    public Text ScoreText;

    public Text SpeedText;

    public Material material;

    void Start()
    {
        tailObjects.Add(gameObject);
    }

    void Update()
    {
        ScoreText.text = Score.score.ToString();
        SpeedText.text = "Скорость: " + Speed.speed.ToString();
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up*RotationSpeed*Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up*-1*RotationSpeed*Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q)) {
            SceneManager.LoadScene("Menu");
        }
    }

    public void AddTail()
    {
        Score.score = Score.score + 1;

        if (tailObjects.Count % 5 == 0 && speed <= 6) {
            speed++;
            Speed.speed = Speed.speed + 1;
        }
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;

        GameObject tail = GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject;
        tail.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);

        tailObjects.Add(tail);
    }
}
