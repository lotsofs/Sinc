using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour {

    public AudioSource source;

    public AudioClip switchFrameClip;
    public TurnOff turnOffScript;

    public void SwitchFrame()
    {
        source.PlayOneShot(switchFrameClip);
    }

    void Update()
    {
        if (Input.GetAxis("Cross") > 0)
        {
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        turnOffScript.enabled = true;
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}