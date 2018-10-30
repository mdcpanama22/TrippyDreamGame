using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {


    public AudioClip noise;
    public AudioClip presentation;
    public GameObject startButton;
    public Text FeaturePresentation;

    AudioSource audio;

    private void Start()
    {
        Color temp = FeaturePresentation.color;
        temp.a = 0f;
        FeaturePresentation.color = temp;

        audio = GetComponent<AudioSource>();
    }

    public void Begin()
    {
        StartCoroutine("ActualStart");
    }

    public IEnumerator ActualStart()
    {
        startButton.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        float alpha = 0;
        Color newColor;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime * 0.5f;
            newColor = FeaturePresentation.color;
            newColor.a = alpha;
            FeaturePresentation.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        newColor = FeaturePresentation.color;
        newColor.a = 1f;
        FeaturePresentation.color = newColor;

        yield return new WaitForSeconds(0.2f);

        audio.loop = false;
        audio.clip = presentation;
        audio.Play();

        while (audio.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        audio.loop = true;
        audio.clip = noise;
        audio.Play();

        yield return new WaitForSeconds(0.2f);
        alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * 0.5f;
            newColor = FeaturePresentation.color;
            newColor.a = alpha;
            FeaturePresentation.color = newColor;
            yield return new WaitForEndOfFrame();
        }
        newColor = FeaturePresentation.color;
        newColor.a = 0f;
        FeaturePresentation.color = newColor;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync("FinalScene");

    }
}
