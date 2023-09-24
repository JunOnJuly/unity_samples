using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
        GetComponent<Transform>().localScale = new Vector3(Random.Range(0.5f, 10), Random.Range(0.5f, 10), Random.Range(0.5f, 10));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            if (GetComponent<Break>())
                Destroy(gameObject);
            player.addScore(1);
        }
    }
}
