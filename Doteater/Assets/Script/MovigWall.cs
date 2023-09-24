using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovigWall : MonoBehaviour
{
    public int speed = 2;
    public string dir;
    public Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dir)
        {
            case "Up":
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
                if (transform.position.z >= initPosition.z + 1.4)
                    dir = "Down";
                break;
            case "Down":
                transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
                if (transform.position.z <= initPosition.z + 0.1)
                    dir = "Up";
                    break;
            case "Left":
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (transform.position.x <= initPosition.x + 0.1)
                    dir = "Right";
                break;
            case "Right":
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (transform.position.x >= initPosition.x + 1.4)
                    dir = "Left";
                break;
        }
    }
}
