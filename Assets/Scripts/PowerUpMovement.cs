using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour {

    //float piDetermination = 0;
    //float startTranslation = 0;

    //float prevFrequency = 0;
    public float powerupSpeed = 0.7f;

  /*  void Start() {
        piDetermination = Mathf.Round(IGameManager.instance.meshTranslation / (2 * Mathf.PI) + 1) * (2 * Mathf.PI);
        startTranslation = IGameManager.instance.meshTranslation;

    }
    */
    // Update is called once per frame
    void Update() {
        // Move up and down
        //transform.position += Vector3.up * (IGameManager.instance.frequency - prevFrequency) * 4;
        //prevFrequency = IGameManager.instance.frequency;

        // Move to the left
        transform.position += Vector3.left * Time.deltaTime * IGameManager.instance.speed * IGameManager.instance.frequency;
        if (transform.position.x < -50) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter()
    {
        IScoreCounter.instance.UpdateScore(10);
        Destroy(gameObject);
    }
}
