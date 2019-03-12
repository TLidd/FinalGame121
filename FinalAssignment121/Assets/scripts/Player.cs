using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Rigidbody body;
    bool planted = true;
    public float jumpForce = 2.0f;
    public Vector3 jump;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-2f,0,0f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(2f,0,0f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0f,0,2f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f,0,-2.5f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space) && planted)
        {
            body.AddForce(jump * jumpForce, ForceMode.Impulse);
            planted = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.transform.gameObject.name == "box")
        {
            Vector3 check = other.transform.position - transform.position;
            if(Math.Abs(check.x) <= 1 && Math.Abs(check.y) >=1 && Math.Abs(check.z) <= 1)
            {
                planted = true;
            }
        }
        else if(other.transform.gameObject.name == "platform")
        {
            planted = true;
        }
    }
}
