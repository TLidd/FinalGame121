using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public node[,,] grid;
    public int height, width, length;
    public Graph(int widthG, int heightG, int lengthG)
    {
        width = widthG;
        height = heightG;
        //length needs to be plus 1 because z0 is the area that contains the solved position
        length = lengthG + 1;
        grid = new node[width,height,length];
        for(int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                for(int k = 0; k < length; ++k)
                {
                    grid[i,j,k] = new node();
                }
            }
        }
    }

    public void addEdges()
    {
        //needs to be length - 1 because the last elements of z don't contain adjs
        for(int k = 0; k < length - 1; ++k)
        {
            for(int j = 0; j < height; ++j)
            {
                for(int i = 0; i < width; ++i)
                {
                    grid[i, j, k].adj.Add(new Vector3(i,j,k+1));
                    if(i == 0)
                    {
                        if(j == 0)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j+1, k+1));
                        }
                        else if(j == height - 1)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j-1, k+1));
                        }
                        else
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j-1, k+1));
                        }
                        grid[i, j, k].adj.Add(new Vector3(i+1, j, k+1));
                    }
                    else if(i == width - 1)
                    {
                        if(j == 0)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j+1, k+1));
                        }
                        else if(j == height - 1)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j-1, k+1));
                        }
                        else
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j-1, k+1));
                        }
                        grid[i, j, k].adj.Add(new Vector3(i-1, j, k+1));
                    }
                    else
                    {
                        if(j == 0)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j+1, k+1));
                        }
                        else if(j == height - 1)
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j-1, k+1));
                        }
                        else
                        {
                            grid[i, j, k].adj.Add(new Vector3(i, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j+1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i-1, j-1, k+1));
                            grid[i, j, k].adj.Add(new Vector3(i+1, j-1, k+1));

                        }
                        grid[i, j, k].adj.Add(new Vector3(i-1, j, k+1));
                        grid[i, j, k].adj.Add(new Vector3(i+1, j, k+1));
                    }
                }
            }
        }
    }

    public void removeEdges(Vector3 vertex)
    {
        //removes the edges attached to the box that will spawn in
        grid[(int)vertex.x, (int)vertex.y, (int)vertex.z].item = true;
        
        if(vertex.x != 0)
        {
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y, vertex.z + 1));
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y + 1, vertex.z));
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y - 1, vertex.z));
        }
        if(vertex.x != width - 1)
        {
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y, vertex.z + 1));
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y + 1, vertex.z));
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Remove(new Vector3(vertex.x, vertex.y - 1, vertex.z));
        }
        
        for(int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                if(vertex.z != 0)
                {
                    grid[i,j,(int)vertex.z-1].adj.Remove(vertex);
                }
            }
        }
    }

    public void replaceEdge(Vector3 vertex)
    {
        grid[(int)vertex.x, (int)vertex.y, (int)vertex.z].item = false;
        if(vertex.x != 0)
        {
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y, vertex.z + 1));
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y + 1, vertex.z));
            grid[(int)vertex.x - 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y - 1, vertex.z));
        }
        if(vertex.x != width - 1)
        {
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y, vertex.z + 1));
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y + 1, vertex.z));
            grid[(int)vertex.x + 1, (int)vertex.y, (int)vertex.z].adj.Add(new Vector3(vertex.x, vertex.y - 1, vertex.z));
        }

        for(int i = 0; i < width; ++i)
        {
            for(int j = 0; j < height; ++j)
            {
                if(vertex.z != 0)
                {
                    grid[i,j,(int)vertex.z-1].adj.Remove(vertex);
                }
            }
        }
    }

    public bool BFS(Vector3 StartNode)
    {
        bool[,,] visited = new bool[width, height, length];
        Queue<Vector3> queue = new Queue<Vector3>();
        visited[(int)StartNode.x, (int)StartNode.y, (int)StartNode.z] = true;
        queue.Enqueue(StartNode);

        while(queue.Count != 0)
        {
            Vector3 vertex = queue.Dequeue();
            for(int i = 0; i < grid[(int)vertex.x, (int)vertex.y, (int)vertex.z].adj.Count; ++i)
            {
                //if it can reach the end vertecies return true
                Vector3 that = grid[(int)vertex.x, (int)vertex.y, (int)vertex.z].adj[i];
                if(that.z == length - 1 && that.y == 0)
                {
                    Platform.SolvePoint = new Vector3((int)vertex.x, (int)vertex.y, (int)vertex.z);
                    return true;
                }
                if(!visited[(int)that.x, (int)that.y, (int)that.z])
                {
                    visited[(int)that.x, (int)that.y, (int)that.z] = true;
                    queue.Enqueue(new Vector3((int)that.x, (int)that.y, (int)that.z));
                }
            }
        }
        //will return false if no end vertecies were found
        return false;
    }

    public class node
    {
        public bool item = false;
        public List<Vector3> adj = new List<Vector3>();
    }
}
