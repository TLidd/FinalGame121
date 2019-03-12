using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f,0f,-2f) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.gameObject.name == "Backboard")
        {
            Destroy(this.gameObject);
        }
    }
}
