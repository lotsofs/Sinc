using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScreen : MonoBehaviour {

    public Text highScoreText;

    void OnEnable()
    {
        highScoreText.text = "";

        highScoreText.text += PlayerPrefs.GetString("Name1") + ": " + PlayerPrefs.GetFloat("Score1");
        highScoreText.text += "\n" + PlayerPrefs.GetString("Name2") + ": " + PlayerPrefs.GetFloat("Score2");
        highScoreText.text += "\n" + PlayerPrefs.GetString("Name3") + ": " + PlayerPrefs.GetFloat("Score3");
        highScoreText.text += "\n" + PlayerPrefs.GetString("Name4") + ": " + PlayerPrefs.GetFloat("Score4");
        highScoreText.text += "\n" + PlayerPrefs.GetString("Name5") + ": " + PlayerPrefs.GetFloat("Score5");
    }
}