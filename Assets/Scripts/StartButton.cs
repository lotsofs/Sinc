using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    public AudioSource source;

    public AudioClip startButtonOn;
    public AudioClip startButtonOff;

    public GameObject gameHolder;
    public GameObject menuHolder;
    public CameraControl gameCamera;
    public GameObject penguin;

    Vector3 startPenguinPos;

    void Start()
    {
        startPenguinPos = penguin.transform.position;
    }

    public void StartButtonOn()
    {
        source.PlayOneShot(startButtonOn);
    }

    public void StartButtonOff()
    {
        source.PlayOneShot(startButtonOff);
    }

    void Update()
    {
        if (Input.GetAxis("Cross") > 0)
        {
            gameCamera.OnStartGame();
            gameHolder.SetActive(true);
            menuHolder.SetActive(false);penguin.SetActive(true);
            penguin.transform.position = startPenguinPos;
        }
    }
}
