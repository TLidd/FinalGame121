﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject box;

    public void createBox(int xpos, int ypos, int zpos)
    {
        GameObject obj = Instantiate(box, new Vector3(xpos, ypos, zpos), Quaternion.identity);
        obj.transform.localScale = new Vector3(1.67f,1.67f,1.67f);
        obj.AddComponent<Boxes>();
        obj.name = "box";
        Rigidbody objectbody = obj.gameObject.AddComponent<Rigidbody>();
        objectbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY
        | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationX;
    }

}
