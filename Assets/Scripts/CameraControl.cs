using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    float beginSize;

    Camera cam;

    public GameObject penguin;

    bool followPenguin;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        beginSize = cam.orthographicSize;
    }

    void Update()
    {
        if (followPenguin)
        {
            if (penguin != null)
            {
                cam.orthographicSize = beginSize + penguin.transform.position.y / 2;
                transform.localPosition = new Vector3(transform.localPosition.x, penguin.transform.position.y + 5, transform.localPosition.z);
            }
        }
    }

    public void OnStartGame()
    {
        followPenguin = true;
    }
}