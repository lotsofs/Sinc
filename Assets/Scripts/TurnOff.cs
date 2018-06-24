using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour {

    // ENABLE this script when the game is over
    public Material mat;
    public MovieTexture txt;
	// Use this for initialization
	void Start () {
        mat.mainTexture = txt;
        txt.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
