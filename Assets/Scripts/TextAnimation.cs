using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    public void ShowErrorText(String text)
    {
        textBox.text = text;
        StartCoroutine(ShowAnimation(0.4f, textBox));
    }
    
    IEnumerator ShowAnimation(float t, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
    
    private void Start()
    {
        textBox = gameObject.GetComponent<TextMeshProUGUI>();
        textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, 0);
    }
}
