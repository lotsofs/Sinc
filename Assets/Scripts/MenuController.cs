using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IMenuController
{
    public static MenuController instance;
}

public class MenuController : MonoBehaviour {
    
    public enum ControllerType { mouseKey, controller };

    public ControllerType controllerType;

    public GameObject[] screens;
    public int screenIndex;
    public GameObject staticScreen;
    public GameObject gameCam;

    bool canUseLeftStick;
    bool tvStarted;

    Vector3 startCamPos;
    float startCamOrtho;

    void Awake()
    {
        IMenuController.instance = this;

        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
    }

    void Start()
    {
        startCamPos = gameCam.transform.position;
        startCamOrtho = gameCam.GetComponent<Camera>().orthographicSize;
    }

    public void StartTV()
    {
        screenIndex = 0;
        screens[screenIndex].SetActive(true);
        canUseLeftStick = true;
        tvStarted = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            print(IGameManager.instance);
            IMenuController.instance.controllerType = MenuController.ControllerType.mouseKey;
        }

        if (Input.GetAxis("LeftStick") > 0.5f || Input.GetAxis("LeftStick") < -0.5f)
        {
            IMenuController.instance.controllerType = MenuController.ControllerType.controller;
        }

        if (canUseLeftStick)
        {
            if (Input.GetAxis("LeftStick") > 0.5f || Input.GetKeyDown(KeyCode.RightArrow))
            {
                ScreenRight();
                canUseLeftStick = false;
            }
            if (Input.GetAxis("LeftStick") < -0.5f || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ScreenLeft();
                canUseLeftStick = false;
            }
        }

        if (Input.GetAxis("LeftStick") > - 0.2f && Input.GetAxis("LeftStick") < 0.2f && tvStarted)
        {
            canUseLeftStick = true;
        }
    }

    public void ScreenLeft()
    {
        screenIndex--;
        if (screenIndex < 0)
        {
            screenIndex = screens.Length - 1;
        }

        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }

        screens[screenIndex].SetActive(true);

        staticScreen.SetActive(true);
    }

    public void ScreenRight()
    {
        screenIndex++;
        if (screenIndex > screens.Length - 1)
        {
            screenIndex = 0;
        }

        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }

        screens[screenIndex].SetActive(true);

        staticScreen.SetActive(true);
    }

    public void ShowEnterScoreScreen()
    {
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }

        gameCam.transform.position = startCamPos;
        gameCam.GetComponent<Camera>().orthographicSize = startCamOrtho;

        enabled = false;
    }
}