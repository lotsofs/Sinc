using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public static class IScoreCounter {
    public static ScoreCounter instance;
}

public class ScoreCounter : MonoBehaviour {

    public Text scoreCounter;
    public Text comboCounter;
    public Text rewardCounter;
    public Text formulaDisplay;
    public int score = 0;
    int multiplier = 1;

    void Awake() {
        IScoreCounter.instance = this;
    }

    void Update() {
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            UpdateScore(1);
        }*/
        Color col = rewardCounter.color;
        col.a -= Time.deltaTime / 3;
        rewardCounter.color = col;

        if (Mathf.RoundToInt(IGameManager.instance.translationMod) == 0) {
            if (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f == 1) {
                formulaDisplay.text = "f(x)=sin(x)";
            }
            else {
                formulaDisplay.text = "f(x)=sin(" + (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f).ToString() + "X)";
            }
        }
        else if (Mathf.RoundToInt(IGameManager.instance.translationMod) > 0) {
            if (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f == 1) {
                formulaDisplay.text = "f(x)=sin((X+" + Mathf.RoundToInt(IGameManager.instance.translationMod).ToString() + "))";
            }
            else formulaDisplay.text = "f(x)=sin(" + (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f).ToString() + "(X+" + Mathf.RoundToInt(IGameManager.instance.translationMod).ToString() + "))";
        }
        else {
            if (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f == 1) {
                formulaDisplay.text = "f(x)=sin((X" + Mathf.RoundToInt(IGameManager.instance.translationMod).ToString() + "))";
            }
            else formulaDisplay.text = "f(x)=sin(" + (Mathf.RoundToInt(IGameManager.instance.frequency * 10) / 10f).ToString() + "(X" + Mathf.RoundToInt(IGameManager.instance.translationMod).ToString() + "))";
        }
    }

    public void IncrementMultiplier() {
        if (multiplier < 8) {
            multiplier += 1;
            comboCounter.text = multiplier.ToString() + " x";
        }
    }

    public void DecrementMultiplier() {
        if (multiplier > 1) {
            multiplier -= 1;
            comboCounter.text = multiplier.ToString() + " x";
        }
    }


    public void ResetMultiplier() {
            multiplier = 1;
            comboCounter.text = multiplier.ToString() + " x";
    }

    public void UpdateScore(int sco) {
        score += sco * multiplier;
        if (sco > 0) {
            scoreCounter.text = score.ToString("D6");
            rewardCounter.text = "+" + sco * multiplier;
            rewardCounter.color = Color.white;
        }
    }

}
