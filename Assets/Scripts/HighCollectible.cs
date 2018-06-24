using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighCollectible : MonoBehaviour {

    float prevRightStick = 0;

    void Update()
    {
        transform.Translate(Vector3.left * IGameManager.instance.speed * Time.deltaTime);
        transform.Translate(Vector3.right * (Input.GetAxis("RightStick") - prevRightStick));
        prevRightStick = Input.GetAxis("RightStick");

        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter()
    {
        IScoreCounter.instance.UpdateScore(20);
        Destroy(gameObject);
    }
}