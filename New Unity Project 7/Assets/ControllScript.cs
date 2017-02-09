using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScript : MonoBehaviour {
    private Animator anim;
    private CapsuleCollider colide;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        colide = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Verticle");

        anim.SetFloat("VSpeed", v);
        anim.SetFloat("HSpeed", h);
	}
}
