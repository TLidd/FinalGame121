using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Vector3 SolvePoint = new Vector3(0, 0, 0);
    //public System.Random ran = new System.Random();
    BoxController BoxControl;
    private void Start()
    {
        BoxControl = GameObject.Find("GameController").GetComponent<BoxController>();
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
            System.Random ran = new System.Random();
            //take care of the spawning objects here can use graph by iterating through and see which vertecies are empty
            //and then spawn according to the empty vertecies.
            Graph G = new Graph(7, 3, 5);
            G.addEdges();
            int i = 25;
            //int count = 0;
            //use timer to remove x amount of boxes and run bfs each time until not solvable or amount is reached
            while(i != 0)
            {
                Vector3 randomBox = new Vector3(ran.Next(G.width), ran.Next(G.height), ran.Next(1, G.length));
                G.removeEdges(randomBox);
                //count++;
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
            //Debug.Log(count);
            SpawnThings(G);
            this.gameObject.transform.position += new Vector3(0,0,85);
        }
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
                        BoxControl.createBox(i - 3, j + 1, 75 + k);
                    }
                }
            }
        }
    }
}
