using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighCollectibles : MonoBehaviour {

    public GameObject[] prefabs;

    void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0.05f, 0.3f));

        GameObject inst = Instantiate(prefabs[Random.Range(0, prefabs.Length - 1)]);
        inst.transform.position = new Vector3(50, Random.Range(20, 80), 0);

        StartCoroutine(WaitForSpawn());
    }
}