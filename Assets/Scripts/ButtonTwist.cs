using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTwist : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("RButton", Input.GetAxis("RightStick"));
        anim.SetFloat("LButton", Input.GetAxis("LeftStick"));
    }
}
