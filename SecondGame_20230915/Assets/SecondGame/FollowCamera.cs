using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        tr.position = new Vector3(target.position.x - 0.5f, target.position.y+1, target.position.z - 6.5f);
        tr.rotation = target.rotation;

        tr.LookAt(target);
    }
}
