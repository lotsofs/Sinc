using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IGameManager
{
    public static GameManager instance;
}

public class GameManager : MonoBehaviour {

    public float meshTranslation;
    public float translationMod;
    public float frequency;
    public float speed = 10;

    public float speedMod = 1;
    public GameObject powerup;
    public GameObject bear;
    public GameObject enterNameScreen;
    public GameObject menuHolder;

    void OnEnable()
    {
        IGameManager.instance = this;
    }

    void Awake()
    {
        IGameManager.instance = this;
    }

    void Update()
    {
        translationMod = -Input.GetAxis("RightStick") * 2;

        meshTranslation += speed * Time.deltaTime;

        if (Input.GetButtonDown("Start"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
    void Start() {
        //StartCoroutine(PowerupSpawnTimer());
        StartCoroutine(BearSpawnTimer());
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void SpawnBear() {
        Instantiate(bear);
        StartCoroutine(BearSpawnTimer());
    }

    /*public void spawnBattery(float spd) {
        Instantiate(powerup, new Vector3(4 + 3 * Mathf.PI / frequency, spd + 2, 0), Quaternion.identity);
    }*/

    /*void SpawnPowerup() {
        GameObject inst = Instantiate(powerup);
        inst.transform.position = new Vector3(50, Random.Range(1, 10), 0);
        //StartCoroutine(PowerupSpawnTimer());
    }

    IEnumerator PowerupSpawnTimer() {
        yield return new WaitForSeconds(Random.Range(1f, 7f));
        SpawnPowerup();
    }*/

    IEnumerator BearSpawnTimer() {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        if (IScoreCounter.instance.score < 5000) {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
        }
        SpawnBear();
    }

    public void OnPlayerDeath()
    {

    }
}