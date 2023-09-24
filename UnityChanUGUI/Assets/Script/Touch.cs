using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    public RawImage ui;
    public TextMeshProUGUI uiText;
    public Material Seen;
    public Material UnSeen;
    public static int msgLen;

    private string msg;
    private bool flagDisplay = false;
    private float nextTime = 0;

    private Animator animator;
    private AudioSource univoice;

    private int motionIdol = Animator.StringToHash("Base Layer.Idol");


    // Start is called before the first frame update
    void Start()
    {

        uiText.text = "";
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flagDisplay && Time.time > nextTime)
        {
            uiText.text = msg.Substring(0, msgLen);
            if (msgLen < msg.Length)
            {
                msgLen++;
            }
            nextTime = Time.time + 0.02f;
        }
        animator.SetBool("Touch", false);
        animator.SetBool("TouchHead", false) ;

        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol)
        {
            animator.SetBool("Motion_Idle", true);
        }
        else
        {
            animator.SetBool("Motion_Idle", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitObj = hit.collider.gameObject;
                
                if (hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                }
                else if (hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                }
                else if (hitObj.tag == "Arm")
                {
                    msg = DateTime.Now.ToString("yyyy") + "년" +
                        DateTime.Now.ToString("MM") + "월" +
                        DateTime.Now.ToString("dd") + "일" +
                        DateTime.Now.ToString("hh") + "시" +
                        DateTime.Now.ToString("mm") + "분";
                    flagDisplay = true;
                    ui.GetComponent<RawImage>().material = Seen;
                }
            }
        }   
    }
}
