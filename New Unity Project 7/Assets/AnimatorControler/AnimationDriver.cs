using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDriver : MonoBehaviour {

    private Animator myAnimator;
    //private CharacterController playerControler;
    //private Rigidbody body;
    private int key = 9;
    private float speed = 1f;
    private float oldSpeed = 1f;
    float duration = 3f;
    private float time = 0f;
    RaycastHit hit;
    float height = 2f;
    Vector3 down;
    private KeyCode[] keyCodes = {
        
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.Alpha0
    };
    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        //body = GetComponent<Rigidbody>();
        //playerControler = GetComponent<CharacterController>();
        myAnimator.SetBool("OnGround", true);

    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < keyCodes.Length; i++) {
            //Debug.Log(i);
            if (Input.GetKeyDown(keyCodes[i])) {
                key = i;
                time = 0;
                oldSpeed = speed;
                //Debug.Log(speed);
            }
        }


        
        if (time<1)
        {
            time += Time.deltaTime * duration;
            speed = Mathf.Lerp(oldSpeed, (key + 1) * 0.1f, time);
        }
        //Debug.Log(body.velocity.y);
        //if (body.velocity.y < -1)
        //{
        //myAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;

        //myAnimator.SetBool("OnGround", false);
        //}
        //else {
        //myAnimator.updateMode = AnimatorUpdateMode.Normal;
        //myAnimator.SetBool("OnGround", true);


        //}
        Vector3 down = new Vector3(0, -1, 0);
        Vector3 orig = transform.position;
        Debug.DrawRay(transform.position, down, Color.green);
        Debug.Log(Physics.Raycast(orig, down, height));
        if (Physics.Raycast(orig, down, height))
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            //myAnimator.updateMode = AnimatorUpdateMode.Normal;
            myAnimator.SetBool("OnGround", false);
        }
        else
        {
            //nothing was below your gameObject within 10m.
           // myAnimator.updateMode = AnimatorUpdateMode.AnimatePhysics;
            myAnimator.SetBool("OnGround", true);
        } 


        myAnimator.SetFloat("VSpeed", speed * Input.GetAxis("Vertical"));
        myAnimator.SetFloat("HSpeed", speed * Input.GetAxis("Horizontal"));
	}
}
