using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UguiBtn : MonoBehaviour
{
    public Texture BBtn;
    public Texture YBtn;
    public Texture RBtn;

    public bool start = false;
    public bool seen = false;


    // Start is called before the first frame update
    void Start()
    {
        if (start)
        {
            seen = true;
        }
        else
        {
            seen = false;
        }

        if (seen)
        {
            GetComponent<RawImage>().texture = BBtn;
        }
        else
        {
            GetComponent<RawImage>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
