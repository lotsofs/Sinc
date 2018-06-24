using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {
    public Animator animR;
    public Animator animL;

    float mouseStart;
    float mouseChange;
    float mouseCurrent;
    float mouseDifference;
    // Update is called once per frame
    void Update ()
    {
        animR.SetFloat("RightHand", (Input.GetAxis("RightStick") / 2) + 0.5f);

        if (Input.GetJoystickNames().Length != 0)
            animL.SetFloat("LeftHand", (Input.GetAxis("LeftStick") / 2) + 0.5f);


        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0) == true)
        {
            //float mouseRatioX = Input.mousePosition.x / Screen.width;
            mouseChange = Mathf.Clamp(mouseChange + Input.GetAxis("MouseHorizontal"), -400, 400);
            mouseCurrent = mouseStart + mouseChange;
            mouseDifference = (mouseStart - mouseCurrent) / 300;
            print(mouseDifference);
            IGameManager.instance.frequency = Mathf.Clamp(1 - mouseDifference, 0.67f, 1.33f);
            animL.SetFloat("LeftHand", (Mathf.Clamp(1 - mouseDifference, 0.67f, 1.33f) / 0.67f - 1));
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            IGameManager.instance.frequency = 1;
            mouseCurrent = 0;
            mouseChange = 0;
            mouseDifference = 0;
            mouseStart = 0;
            animL.SetFloat("LeftHand", (Mathf.Clamp(1 - mouseDifference, 0.67f, 1.33f) / 0.67f - 1));
        }

    }
}
