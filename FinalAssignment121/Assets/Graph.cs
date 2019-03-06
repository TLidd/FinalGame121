using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public List<int>[] gridspots;
    public Graph()
    {
        gridspots = new List<int>[42];
        for(int i = 0; i < 42; ++i){
            gridspots[i] = new List<int>();
        }
    }

    public void addEdges()
    {
        int i = 0;
        int k = i + 1;
        while(i < 36)
        {
            gridspots[i].Add(i+6);
            gridspots[i].Add(i+7);
            gridspots[i].Add(i+8);
            gridspots[i].Add(i+9);
            gridspots[k].Add(i+6);
            gridspots[k].Add(i+7);
            gridspots[k].Add(i+8);
            gridspots[k].Add(i+9);
            i+=2;
            k+=2;
            gridspots[i].Add(i+4);
            gridspots[i].Add(i+5);
            gridspots[i].Add(i+6);
            gridspots[i].Add(i+7);
            gridspots[i].Add(i+8);
            gridspots[i].Add(i+9);
            gridspots[k].Add(i+4);
            gridspots[k].Add(i+5);
            gridspots[k].Add(i+6);
            gridspots[k].Add(i+7);
            gridspots[k].Add(i+8);
            gridspots[k].Add(i+9);
            i+=2;
            k+=2;
            gridspots[i].Add(i+4);
            gridspots[i].Add(i+5);
            gridspots[i].Add(i+6);
            gridspots[i].Add(i+7);
            gridspots[k].Add(i+4);
            gridspots[k].Add(i+5);
            gridspots[k].Add(i+6);
            gridspots[k].Add(i+7);
            i+=2;
            k+=2;
        }
    }

    public void removeEdges(int vertex)
    {
        for(int i = 0; i < 42; ++i)
        {
            if(gridspots[i].Contains(vertex))
            {
                gridspots[i].Remove(vertex);
            }
        }
        gridspots[vertex].Clear();
        Debug.Log(gridspots[vertex].Count);
        if(vertex % 6 == 4)
        {
            gridspots[vertex - 2].Remove(vertex+6);
            gridspots[vertex - 2].Remove(vertex+7);
            gridspots[vertex - 1].Remove(vertex+6);
            gridspots[vertex - 1].Remove(vertex+7);
        }
        else if(vertex % 6 == 5)
        {
            gridspots[vertex - 2].Remove(vertex+6);
            gridspots[vertex - 2].Remove(vertex+5);
        }
        else if(vertex % 6 == 2)
        {
            gridspots[vertex - 2].Remove(vertex+6);
            gridspots[vertex - 1].Remove(vertex+6);
            gridspots[vertex + 2].Remove(vertex+6);
            gridspots[vertex + 3].Remove(vertex+6);
            gridspots[vertex - 2].Remove(vertex+7);
            gridspots[vertex - 1].Remove(vertex+7);
            gridspots[vertex + 2].Remove(vertex+7);
            gridspots[vertex + 3].Remove(vertex+7);
        }
        else if(vertex % 6 == 3)
        {
            gridspots[vertex - 2].Remove(vertex+6);
            gridspots[vertex + 2].Remove(vertex+6);
            gridspots[vertex - 2].Remove(vertex+5);
            gridspots[vertex + 2].Remove(vertex+5);
        }
        else if(vertex % 6 == 0)
        {
            gridspots[vertex + 2].Remove(vertex+6);
            gridspots[vertex + 2].Remove(vertex+7);
            gridspots[vertex + 3].Remove(vertex+6);
            gridspots[vertex + 3].Remove(vertex+7);
        }
        else{
            gridspots[vertex + 2].Remove(vertex+6);
            gridspots[vertex + 2].Remove(vertex+5);
        }
    }

    public bool BFS(int StartNode)
    {
        bool[] visited = new bool[42];
        Queue<int> queue = new Queue<int>();
        visited[StartNode] = true;
        queue.Enqueue(StartNode);

        while(queue.Count != 0)
        {
            int vertex = queue.Dequeue();
            //Debug.Log(vertex);
            for(int i = 0; i < gridspots[vertex].Count; ++i)
            {
                //if it can reach the end vertecies return true
                if(gridspots[vertex][i] > 35)
                {
                    Debug.Log(vertex + " found end");
                    return true;
                }
                if(!visited[gridspots[vertex][i]])
                {
                    visited[gridspots[vertex][i]] = true;
                    queue.Enqueue(gridspots[vertex][i]);
                }
            }
        }
        //will return false if no end vertecies were found
        return false;
    }
}
