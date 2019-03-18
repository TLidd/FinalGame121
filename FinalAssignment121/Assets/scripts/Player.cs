using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    float time = 1.0f;
    bool setTime = false;
    bool rotated = false;
    private Animation anim;
    public GameObject character;
    Rigidbody body;
    public static bool PlayerAlive = true;
    bool planted = true;
    private float jumpForce = 4f;
    public Vector3 jump;
    private void Start()
    {
        anim = GetComponent<Animation>();
        body = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);
        anim.Play("Run");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            if(!rotated)
            {
                transform.Translate(new Vector3(-2f,0,0f) * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(2f,0,0f) * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.D))
        {
            if(!rotated)
            {
                transform.Translate(new Vector3(2f,0,0f) * Time.deltaTime);
            }
            else
            {
                transform.Translate(new Vector3(-2f,0,0f) * Time.deltaTime);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(!rotated)
            {
                transform.Rotate(0,180,0);
                rotated = true;
            }
            transform.Translate(new Vector3(0f,0,4.5f) * Time.deltaTime);
        }
        else if(transform.position.z < 7f)
        {
            if(rotated)
            {
                transform.Rotate(0,180,0);
                rotated = false;
            }
            transform.Translate(new Vector3(0f,0,1f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space) && time >= 1.0 && planted)
        {
            anim.Play("Runtojumpspring");
            setTime = true;
            time = 0;
            body.AddForce(jump * jumpForce, ForceMode.Impulse);
            planted = false;
        }
        if(setTime)
        {
            time += Time.deltaTime;
            if(time >= 1.0 && planted)
            {
                setTime = false;
                anim.Play("Run");
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.transform.gameObject.name == "Backboard")
        {
            PlayerAlive = false;
        }
        planted = true;
    }
}
