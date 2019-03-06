using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject box;

    void Start() 
    {
        //Instantiate(brick, new Vector3(0, 0, 15), Quaternion.identity);

    }

    public void createBox(int xpos, int ypos, int zpos)
    {
        GameObject obj = Instantiate(box, new Vector3(xpos, ypos, zpos), Quaternion.identity);
        obj.transform.localScale = new Vector3(1.67f,1.67f,1.67f);
        obj.AddComponent<Boxes>();
        Rigidbody objectbody = obj.gameObject.AddComponent<Rigidbody>();
        objectbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX 
        | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationX;
    }

}
