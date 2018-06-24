using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    float piDetermination = 0;
    float startTranslation = 0;

	// Use this for initialization
	void Start () {
        piDetermination = Mathf.Round(IGameManager.instance.meshTranslation / (2 * Mathf.PI) + 6) * (2 * Mathf.PI);
        startTranslation = IGameManager.instance.meshTranslation;
    }

    // Update is called once per frame
    void Update () {
        // Stick to one of the valleys of the sine wave
        transform.position = new Vector3(piDetermination / IGameManager.instance.frequency + ((Mathf.PI / IGameManager.instance.frequency) * 1.5f - ((IGameManager.instance.meshTranslation + IGameManager.instance.translationMod) / IGameManager.instance.frequency)) , Mathf.Sin(IGameManager.instance.frequency * transform.position.x + IGameManager.instance.meshTranslation + IGameManager.instance.translationMod), 0);
        if (IGameManager.instance.meshTranslation > startTranslation + 60) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Penguin")
        {
            IGameManager.instance.menuHolder.SetActive(true);
            MenuController menuController = IGameManager.instance.menuHolder.GetComponent<MenuController>();
            menuController.ShowEnterScoreScreen();
            IGameManager.instance.enterNameScreen.SetActive(true);
            Destroy(col.gameObject);
        }
    }
}
