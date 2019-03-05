using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //public System.Random ran = new System.Random();
    //public GameObject brick;
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
            //take care of the spawning objects here can use graph by iterating through and see which vertecies are empty
            //and then spawn according to the empty vertecies.
            Graph G = new Graph();
            G.addEdges();
            for(int i = 0; i < 5; i++)
            {
                System.Random ran = new System.Random();
                //Debug.Log("here");
                G.removeEdges(ran.Next(36));
            }
            //run bfs before this
            SpawnThings(G);
            this.gameObject.transform.position += new Vector3(0,0,50);
        }
    }

    public void SpawnThings(Graph G)
    {
        for(int i = 0; i < 36; ++i)
        {
            if(G.gridspots[i].Count == 0)
            {
                int zpos = i / 6;
                int xpos;
                if(i % 6 == 2 || i % 6 == 3)
                {
                    xpos = 0;
                }
                else if(i % 6 == 0 || i % 6 == 1)
                {
                    xpos = -1;
                }
                else{
                    xpos = 1;
                }
                //Instantiate(brick, new Vector3(0, xpos, 48 + zpos), Quaternion.identity);
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.gameObject.transform.position = new Vector3(xpos, 1, 36 + zpos);
            }
        }
    }
}
