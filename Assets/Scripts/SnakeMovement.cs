using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 2;

    public float RotationSpeed = 100;

    public FixedJoystick joystick;

    private float moveInput;

    public List<GameObject> tailObjects = new List<GameObject>();

    public float z_offset = 3f;

    public GameObject TailPrefab;

    public Text ScoreText;

    public Text SpeedText;

    public Text LevelText;

    public Material material;

    [SerializeField] private Rigidbody rigidbody;

    void Start()
    {
        tailObjects.Add(gameObject);
    }

    void Update()
    {
        ScoreText.text = Score.score.ToString();
        SpeedText.text = "Скорость: " + Speed.speed.ToString();
        LevelText.text = "Уровень: " + Level.level;
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        rigidbody.velocity = new Vector3(joystick.Horizontal*speed, rigidbody.velocity.y, joystick.Vertical*speed);

        if (joystick.Horizontal != 0 || joystick.Vertical !=0) {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }

        if (Input.GetKey(KeyCode.Q)) {
            Score.score = 0;
            Level.level = 1;
            Speed.speed = 2;
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
        if (Score.score % 2 == 0 && Level.level <= 3) {
            Level.level++;
            SceneManager.LoadScene("Level " + Level.level);
        }
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;

        GameObject tail = GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject;
        tail.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);

        tailObjects.Add(tail);
    }
}
