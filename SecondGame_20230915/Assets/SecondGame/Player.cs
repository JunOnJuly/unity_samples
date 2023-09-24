using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float rotateSpeed = 120;

    int score = 0;

    TextMesh scoreOutput;
    void Start()
    {
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Drop"))
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "Á¡¼ö : " + score;
    }
}
