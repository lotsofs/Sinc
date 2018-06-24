using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMenu : MonoBehaviour {

    public AudioSource source;
    public AudioClip staticClip;

    public void PlayStaticSound()
    {
        source.PlayOneShot(staticClip);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}