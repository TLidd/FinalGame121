using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public void setPlatform(Vector3 pos, Vector3 scale)
    {
        Rigidbody objectbody = this.gameObject.AddComponent<Rigidbody>();
        objectbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX 
        | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationX;
        this.gameObject.transform.position = pos;
        this.gameObject.transform.localScale = scale;
    }

    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0.0f,0.0f,-1f) * Time.deltaTime); 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.gameObject.name == "Backboard")
        {
            this.gameObject.transform.position += new Vector3(0,0,50);
        }
    }
}
