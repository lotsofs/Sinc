using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineOnMesh : MonoBehaviour {

    Mesh mesh;

    Vector3[] vertices;
    float mouseStart;
    float mouseChange;
    float mouseCurrent;
    float mouseDifference;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void Update()
    {
        if (Input.GetJoystickNames().Length != 0) {
            IGameManager.instance.frequency = 1 + Input.GetAxis("LeftStick") / 3;
        }
        // Mouse controls below: These are ass but I guess having them won't hurt
        if (Input.GetMouseButtonDown(0)) {
            mouseStart = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0) == true) {
            //float mouseRatioX = Input.mousePosition.x / Screen.width;
            mouseChange = Mathf.Clamp(mouseChange + Input.GetAxis("MouseHorizontal"), -400, 400);
            mouseCurrent = mouseStart + mouseChange;
            mouseDifference = (mouseStart - mouseCurrent) / 300;
            print(mouseDifference);
            IGameManager.instance.frequency = Mathf.Clamp(1 - mouseDifference, 0.67f, 1.33f);
        }
        if (Input.GetMouseButtonUp(0) == true) {
            IGameManager.instance.frequency = 1;
            mouseCurrent = 0;
            mouseChange = 0;
            mouseDifference = 0;
            mouseStart = 0;
        }
        /*else {
            if (Input.GetKey(KeyCode.RightArrow)) {
                IGameManager.instance.frequency += 0.5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) {
                IGameManager.instance.frequency -= 0.5f * Time.deltaTime;
            }

            if (IGameManager.instance.frequency < 0) {
                IGameManager.instance.frequency = 0;
            }
            if (IGameManager.instance.frequency > 2) {
                IGameManager.instance.frequency = 2;
            }
        }*/

        vertices = mesh.vertices;

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            vertices[i].y = Mathf.Sin(IGameManager.instance.frequency * (vertices[i].x + transform.position.x) + IGameManager.instance.meshTranslation + IGameManager.instance.translationMod);
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}