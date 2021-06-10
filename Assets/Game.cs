using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text lvl1Text;
    public Text lvl2Text;
    public Text lvl5Text;
    public Text lvl6Text;
    private string text = "There is a missing <color=black>GAME</color>";
    private string text2 = "Ok<color=black>a</color>y fine! There is <color=black>a</color> GAME.\nBut you c<color=black>a</color>n't finish it.";
    private string text5 = "You must wait NOW!";
    private string text6 = "THERE IS NO";
    private string text66 = "GAME!";
    private string curText = "";
    public int g, a, m, e, l2okay, l2a, l2cant, l4yes, l5txt, l6txt;
    public int lvl = 1;

    [HideInInspector] public GameObject lvl1, lvl2, lvl3, lvl4, lvl5, lvl6, lvl7, lostLevel;
    public AudioSource audioSource;
    public AudioClip trans;
    public AudioClip hit;
    public AudioClip textSound;
    public AudioClip exp;
    void Start()
    {
        audioSource.PlayOneShot(trans, 1f);
        g = 0; a = 0; m = 0; e = 0; l2okay = 0; l2a = 0; l2cant = 0; l4yes = 0; l5txt = 0; l6txt = 0;
    }

    void Update()
    {
        if (lvl == 1)
        {
            if (Input.GetKeyDown("g"))
            {
                if (g == 0)
                {
                    g = 1;
                    audioSource.Play();
                    text = text.Replace("G", "<color=white>G</color>");
                    lvl1Text.text = text;
                }
            }
            if (Input.GetKeyDown("a"))
            {
                if (a == 0)
                {
                    a = 1;
                    audioSource.Play();
                    text = text.Replace("A", "<color=white>A</color>");
                    lvl1Text.text = text;
                }
            }
            if (Input.GetKeyDown("m"))
            {
                if (m == 0)
                {
                    m = 1;
                    audioSource.Play();
                    text = text.Replace("M", "<color=white>M</color>");
                    lvl1Text.text = text;
                }
            }
            if (Input.GetKeyDown("e"))
            {
                if (e == 0)
                {
                    e = 1;
                    audioSource.Play();
                    text = text.Replace("E", "<color=white>E</color>");
                    lvl1Text.text = text;
                }
            }

            if (g == 1 && a == 1 && m == 1 && e == 1)
            {
                lvl = 2;
                audioSource.PlayOneShot(trans, 1f);
                lvl1.SetActive(false);
                lvl2.SetActive(true);
            }
        }

        if (lvl == 2)
        {
            if (l2okay == 1 && l2a == 1 && l2cant == 1)
            {
                lvl = 3;
                audioSource.PlayOneShot(trans, 1f);
                lvl2.SetActive(false);
                lvl3.SetActive(true);
            }
        }

        if (lvl == 4)
        {
            if (l4yes == 10)
            {
                lvl = 5;
                audioSource.PlayOneShot(trans, 1f);
                lvl4.SetActive(false);
                lvl5.SetActive(true);
            }
        }

        if (lvl == 5)
        {
            if (l5txt == 0)
            {
                l5txt = 2;
                curText = "";
                StartCoroutine(L5Text());
            }

            if (Input.anyKey || Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0 || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                if (l5txt == 1)
                {
                    audioSource.Stop();
                    lvl5Text.text = "";
                    StopAllCoroutines();
                    StartCoroutine(L5Text());
                }
            }
        }

        if (lvl == 6)
        {
            if (l6txt == 0)
            {
                l6txt = 1;
                StartCoroutine(L6Text());
            }
        }
    }

    public void lvl2Click(string txt)
    {
        if (txt == "okay")
        {
            l2okay = 1;
            audioSource.Play();
            text2 = text2.Replace("Ok<color=black>a</color>y", "<color=white>Okay</color>");
            lvl2Text.text = text2;
        }
        if (txt == "a")
        {
            l2a = 1;
            audioSource.Play();
            text2 = text2.Replace(" <color=black>a</color> ", "<color=white> a </color>");
            lvl2Text.text = text2;
        }
        if (txt == "cant")
        {
            l2cant = 1;
            audioSource.Play();
            text2 = text2.Replace("c<color=black>a</color>n't", "<color=white>can't</color>");
            lvl2Text.text = text2;
        }
    }
    public void lvl3Click(string txt)
    {
        if (txt == "further")
        {
            lvl3.SetActive(false);
            lostLevel.SetActive(true);
        }
        if (txt == "close")
        {
            lvl = 4;
            audioSource.PlayOneShot(trans, 1f);
            lvl3.SetActive(false);
            lvl4.SetActive(true);
        }
    }
    public void lvl4Click(GameObject g)
    {
        Destroy(g);
        audioSource.PlayOneShot(hit, 1f);
        l4yes++;
    }
    IEnumerator L5Text()
    {
        yield return new WaitForSeconds(3f);
        l5txt = 1;
        for (int i = 0; i < text5.Length + 1; i++)
        {
            curText = text5.Substring(0, i);
            lvl5Text.text = curText;
            audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5f);
        lvl = 6;
        audioSource.PlayOneShot(trans, 1f);
        lvl5.SetActive(false);
        lvl6.SetActive(true);
    }
    IEnumerator L6Text()
    {
        curText = "";
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(textSound, 1f);
        lvl6Text.text = "these are good things.";
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(textSound, 1f);
        lvl6Text.text = "But you are trying in vain,";
        yield return new WaitForSeconds(3f);
        audioSource.PlayOneShot(textSound, 1f);
        lvl6Text.text = "because i told you";
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < text6.Length + 1; i++)
        {
            curText = text6.Substring(0, i);
            lvl6Text.text = curText;
            audioSource.Play();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.5f);
        curText = "";
        for (int i = 0; i < text66.Length + 1; i++)
        {
            curText = text66.Substring(0, i);
            lvl6Text.text = curText;
            audioSource.PlayOneShot(exp, 1f);
            yield return new WaitForSeconds(0.7f);
        }
        yield return new WaitForSeconds(2f);
        lvl = 7;
        audioSource.PlayOneShot(trans, 1f);
        lvl6.SetActive(false);
        lvl7.SetActive(true);
    }

    public void lvl7Click()
    {
        Application.Quit();
    }
}
