using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class IHighScoreController
{
    public static HighScoreController instance;
}

public class HighScoreController : MonoBehaviour {

    void Awake()
    {
        IHighScoreController.instance = this;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("Score1"))
        {
            PlayerPrefs.SetFloat("Score1", 13300);
        }
        if (!PlayerPrefs.HasKey("Score2"))
        {
            PlayerPrefs.SetFloat("Score2", 3300);
        }
        if (!PlayerPrefs.HasKey("Score3"))
        {
            PlayerPrefs.SetFloat("Score3", 2100);
        }
        if (!PlayerPrefs.HasKey("Score4"))
        {
            PlayerPrefs.SetFloat("Score4", 1800);
        }
        if (!PlayerPrefs.HasKey("Score5"))
        {
            PlayerPrefs.SetFloat("Score5", 1500);
        }

        if (!PlayerPrefs.HasKey("Name1"))
        {
            PlayerPrefs.SetString("Name1", "JGB");
        }
        if (!PlayerPrefs.HasKey("Name2"))
        {
            PlayerPrefs.SetString("Name2", "SSS");
        }
        if (!PlayerPrefs.HasKey("Name3"))
        {
            PlayerPrefs.SetString("Name3", "RMN");
        }
        if (!PlayerPrefs.HasKey("Name4"))
        {
            PlayerPrefs.SetString("Name4", "NOC");
        }
        if (!PlayerPrefs.HasKey("Name5"))
        {
            PlayerPrefs.SetString("Name5", "VVB");
        }
    }

    public void RegisterScore(string name, float score)
    {
        List<float> curScores = new List<float>();
        List<string> curNames = new List<string>();

        curScores.Add(PlayerPrefs.GetFloat("Score1"));
        curScores.Add(PlayerPrefs.GetFloat("Score2"));
        curScores.Add(PlayerPrefs.GetFloat("Score3"));
        curScores.Add(PlayerPrefs.GetFloat("Score4"));
        curScores.Add(PlayerPrefs.GetFloat("Score5"));

        curNames.Add(PlayerPrefs.GetString("Name1"));
        curNames.Add(PlayerPrefs.GetString("Name2"));
        curNames.Add(PlayerPrefs.GetString("Name3"));
        curNames.Add(PlayerPrefs.GetString("Name4"));
        curNames.Add(PlayerPrefs.GetString("Name5"));

        for (int i = 0; i < curScores.Count; i++)
        {
            if (score > curScores[i])
            {
                curScores.Insert(i, score);
                curNames.Insert(i, name);
                break;
            }
        }

        PlayerPrefs.SetFloat("Score1", curScores[0]);
        PlayerPrefs.SetFloat("Score2", curScores[1]);
        PlayerPrefs.SetFloat("Score3", curScores[2]);
        PlayerPrefs.SetFloat("Score4", curScores[3]);
        PlayerPrefs.SetFloat("Score5", curScores[4]);

        PlayerPrefs.SetString("Name1", curNames[0]);
        PlayerPrefs.SetString("Name2", curNames[1]);
        PlayerPrefs.SetString("Name3", curNames[2]);
        PlayerPrefs.SetString("Name4", curNames[3]);
        PlayerPrefs.SetString("Name5", curNames[4]);
    }
}