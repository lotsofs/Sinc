using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour {

    public AudioSource source;

    void Update()
    {
        source.pitch = IGameManager.instance.frequency - 0.33333f;
    }
}