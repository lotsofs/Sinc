using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    public AudioSource source;

    public AudioClip switchFrameClip;

    public MouseKeyAnim mouseKey;

    void Start()
    {
        if (IMenuController.instance.controllerType == MenuController.ControllerType.mouseKey)
        {
            mouseKey.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void SwitchFrame()
    {
        source.PlayOneShot(switchFrameClip);
    }
}