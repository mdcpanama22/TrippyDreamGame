using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public struct Joke
{
    [TextArea(3, 10)]
    public string setup;
    [TextArea(3, 10)]
    public string punchline;
}

public class BlackCloudGuy : MonoBehaviour {

    public GameObject canvas;
    public FancyText fancyText;
    public Font font;

    public Joke[] jokes;

    List<Joke> untoldJokes;

    int index = 0;
    int jokeIndex;

    bool active = false;

    GameObject player;

	// Use this for initialization
	void Start () {
        untoldJokes = new List<Joke>(jokes);
        player = GameObject.Find("FPSController");
        if (player == null) {
             player = GameObject.Find("RealFPSController");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (active) {
            if (Vector3.Distance(player.transform.position, transform.position) > 4f) {
                active = false;
                StartCoroutine("FadeOut");
                canvas.SetActive(false);
                index = 0;
            }
        }
	}


    public void Trigger()
    {
        if (fancyText.revealing)
        {
            fancyText.FinishLine();
        }
        else if (index == 0)
        {
            active = true;
            canvas.SetActive(true);
            SetVariables();
            StopCoroutine("FadeOut");
            GetComponent<AudioSource>().volume = 1;
            GetComponent<AudioSource>().Play();
            fancyText.SetText("Hello, would you like to hear a joke?");
            index += 1;
        }
        else if (index == 1)
        {
            jokeIndex = UnityEngine.Random.Range(0, untoldJokes.Count);
            fancyText.SetText(untoldJokes[jokeIndex].setup);
            index += 1;
        }
        else if (index == 2)
        {
            fancyText.SetText(untoldJokes[jokeIndex].punchline);
            untoldJokes.RemoveAt(jokeIndex);
            if (untoldJokes.Count == 0)
            {
                untoldJokes = new List<Joke>(jokes);
            }
            index += 1;
        }
        else
        {
            StartCoroutine("FadeOut");
            canvas.SetActive(false);
            index = 0;
        }
    }

    private void SetVariables()
    {
        fancyText.GetComponent<Text>().font = font;
        fancyText.createtype = FancyText.CreateType.FADEIN;
        fancyText.createTime = 0.5f;
        fancyText.effectType = FancyText.EffectType.JITTER;
        fancyText.effectStrength = 0.5f;
        fancyText.charDelay = .05f;
        fancyText.newLinePause = .8f;
    }

    IEnumerator FadeOut()
    {
        while (GetComponent<AudioSource>().volume != 0)
        {
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume -= Time.deltaTime * .5f;
            yield return new WaitForEndOfFrame();
        }
        GetComponent<AudioSource>().Stop();
    }
}
