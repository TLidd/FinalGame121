using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-2f,0f,0f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(2f,0f,0f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0f,0f,2f) * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0f,0f,-2f) * Time.deltaTime);
        }
        // if(!Input.GetKey(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        // {
        //     transform.Translate(new Vector3(0f,0f,1f) * Time.deltaTime);
        // }    
    }
}
