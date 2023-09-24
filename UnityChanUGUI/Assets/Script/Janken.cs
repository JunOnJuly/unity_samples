using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Janken : MonoBehaviour
{
    bool flagJanken = false;
    int modeJanken = 0;

    public AudioClip voiceStart;
    public AudioClip voicePon;
    public AudioClip voiceGoo;
    public AudioClip voiceChoki;
    public AudioClip voicePar;
    public AudioClip voiceWin;
    public AudioClip voiceLoose;
    public AudioClip voiceDraw;

    const int JANKEN = -1;
    const int GOO = 0;
    const int CHOKI = 1;
    const int PAR = 2;
    const int DRAW = 3;
    const int WIN = 4;
    const int LOOSE = 5;

    private Animator animator;
    private AudioSource univoice;

    int myHand;
    int unityHand;
    int flagResult;
    int[,] tableResult = new int[3, 3];

    public Material Seen;
    public Material Unseen;

    float waitDelay;

    public Button startBtn;
    public Button GooBtn;
    public Button ChokiBtn;
    public Button ParBtn;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();

        tableResult[GOO, GOO] = DRAW;
        tableResult[GOO, CHOKI] = WIN;
        tableResult[GOO, PAR] = LOOSE;

        tableResult[CHOKI, GOO] = LOOSE;
        tableResult[CHOKI, CHOKI] = DRAW;
        tableResult[CHOKI, PAR] = WIN;

        tableResult[PAR, GOO] = WIN;
        tableResult[PAR, CHOKI] = LOOSE;
        tableResult[PAR, PAR] = DRAW;

        Button btn = startBtn.GetComponent<Button>();

        btn.onClick.AddListener(TaskOnClick);

        Button goobtn = GooBtn.GetComponent<Button>();
        Button chokibtn = ChokiBtn.GetComponent<Button>();
        Button parbtn = ParBtn.GetComponent<Button>();

        goobtn.onClick.AddListener(GooOnClick);
        chokibtn.onClick.AddListener(ChokiOnClick);
        parbtn.onClick.AddListener(ParOnClick);
    }

    void TaskOnClick()
    {
        flagJanken = true;
        startBtn.GetComponent<RawImage>().material = Unseen;
        GooBtn.GetComponent<RawImage>().material = Seen;
        ChokiBtn.GetComponent<RawImage>().material = Seen;
        ParBtn.GetComponent<RawImage>().material = Seen;
    }
    void GooOnClick()
    {
        modeJanken ++;
        myHand = GOO;
    }
    void ChokiOnClick()
    {
        modeJanken++;
        myHand = CHOKI;
    }
    void ParOnClick()
    {
        modeJanken++;
        myHand = PAR;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagJanken)
        {
            switch (modeJanken)
            {
                case 0:
                    UnityChanAction(JANKEN);
                    modeJanken++;
                    break;
                case 1:
                    animator.SetBool("Janken", false);
                    animator.SetBool("Aiko", false);
                    animator.SetBool("Goo", false);
                    animator.SetBool("Choki", false);
                    animator.SetBool("Par", false);
                    animator.SetBool("Win", false);
                    animator.SetBool("Loose", false);
                    break;
                case 2:
                    flagResult = JANKEN;
                    unityHand = Random.Range(GOO, PAR + 1);
                    UnityChanAction(unityHand);
                    flagResult = tableResult[unityHand, myHand];
                    modeJanken++;
                    break;
                case 3:
                    waitDelay += Time.deltaTime;
                    if (waitDelay > 1.5f)
                    {
                        UnityChanAction(flagResult);
                        waitDelay = 0;
                        modeJanken++;
                    }
                    break;
                default:
                    flagJanken = false;
                    modeJanken = 0;
                    break;
            }
        }
    }


    void UnityChanAction(int act) // 이벤트 함수
    {
        switch (act)
        {
            case JANKEN:
                animator.SetBool("Janken", true);
                univoice.clip = voiceStart;
                break;
            case GOO:
                animator.SetBool("Goo", true);
                univoice.clip = voiceGoo;
                break;
            case CHOKI:
                animator.SetBool("Choki", true);
                univoice.clip = voiceChoki;
                break;
            case PAR:
                animator.SetBool("Par", true);
                univoice.clip = voicePar;
                break;
            case DRAW:
                animator.SetBool("Aiko", true);
                univoice.clip = voiceDraw;
                break;
            case WIN:
                animator.SetBool("Win", true);
                univoice.clip = voiceWin;
                break;
            case LOOSE:
                animator.SetBool("Loose", true);
                univoice.clip = voiceLoose;
                break;
        }
        univoice.Play();
    }

}
