using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public int language;
    public string[] text;
    private TMP_Text textLine;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText() 
    {
        language = PlayerPrefs.GetInt("language", language);
        textLine = GetComponent<TMP_Text>();
        textLine.text = "" + text[language];
    }
}
