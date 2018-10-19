using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typwriter : MonoBehaviour {

    string text = "";

    public RawImage image;
    Text textComponent;

    float imageR, imageG, imageB, textR, textB, textG;

    private void Start()
    {
        textComponent = GetComponent<Text>();
        Color temp = image.color;
        imageR = temp.r;
        imageG = temp.g;
        imageB = temp.b;
        temp = GetComponent<Text>().color;
        temp = textComponent.color;
        textR = temp.r;
        textG = temp.g;
        textB = temp.b;
    }

    // Update is called once per frame
    void Update () {
		if (Input.anyKeyDown)
        {
            text += (string)Input.inputString;
            int num = (int)((Input.inputString).GetHashCode() % 12);
            switch(num)
            {
                case 0:
                    imageR += 0.05f;
                    imageR = Mathf.Clamp01(imageR);
                    break;
                case 1:
                    imageR -= 0.1f;
                    imageR = Mathf.Clamp01(imageR);
                    break;
                case 2:
                    imageG += 0.1f;
                    imageG= Mathf.Clamp01(imageG);
                    break;
                case 3:
                    imageG -= 0.1f;
                    imageG = Mathf.Clamp01(imageG);
                    break;
                case 4:
                    imageB += 0.1f;
                    imageB = Mathf.Clamp01(imageB);
                    break;
                case 5:
                    imageB -= 0.1f;
                    imageB = Mathf.Clamp01(imageB);
                    break;
                case 6:
                    textR += 0.1f;
                    textR = Mathf.Clamp01(textR);
                    break;
                case 7:
                    textR -= 0.1f;
                    textR = Mathf.Clamp01(textR);
                    break;
                case 8:
                    textG += 0.1f;
                    textG = Mathf.Clamp01(textG);
                    break;
                case 9:
                    textG -= 0.1f;
                    textG = Mathf.Clamp01(textG);
                    break;
                case 10:
                    textB += 0.1f;
                    textB = Mathf.Clamp01(textB);
                    break;
                case 11:
                    textB -= 0.1f;
                    textB = Mathf.Clamp01(textB);
                    break;
            }

            Color temp = new Color(imageR, imageG, imageB);
            Color temp2 = new Color(textR, textG, textB);
            image.color = temp;
            textComponent.color = temp2;

            GetComponent<Text>().text = text;
        }
	}
}
