using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyAnim : MonoBehaviour {

    public AudioSource source;

    public AudioClip switchFrameClip;

    public TutorialButton tutorialButton;

    void Start()
    {
        if (IMenuController.instance.controllerType == MenuController.ControllerType.controller)
        {
            tutorialButton.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SwitchFrame()
    {
        source.PlayOneShot(switchFrameClip);
    }
}