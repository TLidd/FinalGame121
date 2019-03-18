using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Vector3 SolvePoint = new Vector3(0, 0, 0);
    public static int spawnAmount = 8;
    public static System.Random ran;
    BoxController BoxControl;
    
    private void Start()
    {
        BoxControl = GameObject.Find("GameController").GetComponent<BoxController>();
        if(transform.position.z > 20)
        {
            ran = new System.Random((int)transform.position.z);
            Graph G = MakeObjects(ran);
            SpawnThings(G);
        }
    }

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
        this.gameObject.transform.Translate(new Vector3(0.0f,0.0f,-2f) * Time.deltaTime); 
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.gameObject.name == "Backboard")
        {
            ran = new System.Random();
            Graph G = MakeObjects(ran);
            this.gameObject.transform.position += new Vector3(0,0,85);
            SpawnThings(G);
        }
    }

    public Graph MakeObjects(System.Random ran)
    {
        Graph G = new Graph(7, 3, 5);
        G.addEdges();
        int i = spawnAmount;
        while(i != 0)
        {
            Vector3 randomBox = new Vector3(ran.Next(G.width), ran.Next(G.height), ran.Next(1, G.length));
            G.removeEdges(randomBox);
            if(randomBox.y > 0)
            {
                int y = (int)randomBox.y;
                for(int j = (int)randomBox.y; j >= 0; --j)
                {
                    G.removeEdges(new Vector3(randomBox.x, j, randomBox.z));
                }
            }   
            --i;
            if(!G.BFS(SolvePoint))
            {
                for(int j = 0; j <= (int)randomBox.y; ++j)
                {
                    G.replaceEdge(new Vector3(randomBox.x, j, randomBox.z));
                }
                break;
            }
        }

        return G;
    }

    public void SpawnThings(Graph G)
    {
        for(int i = 0; i < G.width; ++i)
        {
            for(int j = 0; j < G.height; ++j)
            {
                for(int k = 0; k < G.length; ++k)
                {
                    if(G.grid[i,j,k].item == true)
                    {
                        BoxControl.createBox(i - 3, j + 1, (int)transform.position.z + k);
                    }
                }
            }
        }
    }
}
