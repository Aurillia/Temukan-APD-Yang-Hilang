using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class pathfinding : MonoBehaviour
{
    Grid grid;
    
    //bool found = false;

    Canvas canvastext;
    public Text prefabtext;
    Text label;
    public List<Text> textpref = new List<Text>();
    public List<Node> close = new List<Node>();
    public List<Vector2> closevector = new List<Vector2>();
    static pathfinding instance;

    private void Awake()
    {
        canvastext = GetComponentInChildren<Canvas>();
        grid = GetComponent<Grid>();
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
           // StartCoroutine(jalan_musuh1());
           
    }

    public static Vector2[] runpathfind(Vector2 from, Vector2 to)
    {
        return instance.findpathmusuh1(from, to);
;    }
    public static Vector2[] runpathfind2(Vector2 from, Vector2 to)
    {
        return instance.findpathmusuh2(from, to);
;    }
    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2[] findpathmusuh1 (Vector2 musuh, Vector2 target)
    {
        Stopwatch timee = new Stopwatch();
       // timee.Start();
        Vector2[] pathpos = new Vector2[0];
       
        Node nodeawal = grid.pointNode(musuh);
        Node nodetarget = grid.pointNode(target);
        nodeawal.Parent=nodeawal;
        nodeawal.hcost= Jarakhcost(nodeawal,nodetarget);

        List<Node> openlist = new List<Node>();
        HashSet<Node> closelist = new HashSet<Node>();
        openlist.Add(nodeawal);

        while (openlist.Count > 0)
        {
            Node currentNode = openlist[0];
            for (int i = 1; i < openlist.Count; i++)
            {
                if (openlist[i].fcost < currentNode.fcost || openlist[i].fcost == currentNode.fcost && openlist[i].hcost<currentNode.hcost)
                {
                    currentNode = openlist[i];
                }
            }

            openlist.Remove(currentNode);
            closelist.Add(currentNode);

            if(currentNode == nodetarget)
            {
               // timee.Stop();
               // print(timee.Elapsed.TotalMilliseconds + "ms");
                pathpos = getpathmusuh1(nodeawal, nodetarget);
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.path || closelist.Contains(neighbour))
                {
                    continue;
                }

                int newmovementcosttoneighbour = currentNode.gcost + Jarakgcost(currentNode, neighbour);
                if (newmovementcosttoneighbour < neighbour.gcost || !openlist.Contains(neighbour))
                
                {
                    neighbour.gcost = newmovementcosttoneighbour;
                    
                    neighbour.hcost = Jarakhcost(neighbour, nodetarget);
                    neighbour.Parent = currentNode;

                    if (!openlist.Contains(neighbour))
                    {
                        openlist.Add(neighbour);
                    }

                }
            }
        }

       /* close = closelist.ToList();

        for (int i = 0; i < close.Count; i++)
        {
            closevector.Add(close[i].arena);
            label = Instantiate<Text>(prefabtext);
            textpref.Add(label);
            label.transform.SetParent(canvastext.transform, false);
            label.transform.position = new Vector2(closevector[i].x, closevector[i].y);
            textpref[i].text = "g= " + close[i].gcost.ToString() + "\nh= " + close[i].hcost.ToString() ;
        }*/
        return pathpos;
    }

    Vector2[] getpathmusuh1(Node nodeawal, Node nodeakhir)
    {
        List<Node> path = new List<Node>();
        Node currentnode = nodeakhir;

        while(currentnode != nodeawal)
        {
            path.Add(currentnode);
            currentnode = currentnode.Parent;
        }

        List<Vector2> pathpos = new List<Vector2>();
        Vector2 directionold = Vector2.zero;
        for (int i = 0; i < path.Count; i++)
        {
            Vector2 directionnew = new Vector2(path[i].gridx, path[i].gridy);
            if (directionnew != directionold)
            {
                pathpos.Add(path[i].arena);
            }
            directionold = directionnew;
        }
        grid.path = path;
        pathpos.Reverse();
        return pathpos.ToArray();
    }

   
    int Jarakgcost(Node nodeA, Node nodeB)
    {
        int distancex = Mathf.Abs(nodeA.gridx - nodeB.gridx);
        int distancey = Mathf.Abs(nodeA.gridy - nodeB.gridy);
        if (distancex > distancey)
            return 14 * distancey + 10 * (distancex - distancey);
        return 14 * distancex + 10 * (distancey - distancex);
    } 
    int Jarakhcost(Node nodeA, Node nodeB)
    {
        int distancex = Mathf.Abs(nodeA.gridx - nodeB.gridx);
        int distancey = Mathf.Abs(nodeA.gridy - nodeB.gridy);


        return (distancex + distancey) * 10;
    }
    Vector2[] findpathmusuh2 (Vector2 musuh, Vector2 target)
    {
        Stopwatch timee = new Stopwatch();
        //timee.Start();
        Vector2[] pathpos = new Vector2[0];
       
        Node nodeawal = grid.pointNode(musuh);
        Node nodetarget = grid.pointNode(target);
        nodeawal.Parent=nodeawal;
        nodeawal.hcost= Jarakhcost2(nodeawal,nodetarget);

        List<Node> openlist = new List<Node>();
        HashSet<Node> closelist = new HashSet<Node>();
        openlist.Add(nodeawal);

        while (openlist.Count > 0)
        {
            Node currentNode = openlist[0];
            for (int i = 1; i < openlist.Count; i++)
            {
                if (openlist[i].fcost < currentNode.fcost || openlist[i].fcost == currentNode.fcost && openlist[i].hcost<currentNode.hcost)
                {
                    currentNode = openlist[i];
                }
            }

            openlist.Remove(currentNode);
            closelist.Add(currentNode);

            if(currentNode == nodetarget)
            {
               // timee.Stop();
               // print(timee.Elapsed.TotalMilliseconds + "ms");
                pathpos = getpathmusuh2(nodeawal, nodetarget);
            }

            foreach (Node neighbour in grid.GetNeighbours(currentNode))
            {
                if (!neighbour.path || closelist.Contains(neighbour))
                {
                    continue;
                }

                int newmovementcosttoneighbour = currentNode.gcost + Jarakgcost2(currentNode, neighbour);
                if (newmovementcosttoneighbour < neighbour.gcost || !openlist.Contains(neighbour))
                
                {
                    neighbour.gcost = newmovementcosttoneighbour;
                    
                    neighbour.hcost = Jarakhcost2(neighbour, nodetarget);
                    neighbour.Parent = currentNode;

                    if (!openlist.Contains(neighbour))
                    {
                        openlist.Add(neighbour);
                    }

                }
            }
        }

        /*close = closelist.ToList();

        for (int i = 0; i < close.Count; i++)
        {
            closevector.Add(close[i].arena);
            label = Instantiate<Text>(prefabtext);
            textpref.Add(label);
            label.transform.SetParent(canvastext.transform, false);
            label.transform.position = new Vector2(closevector[i].x, closevector[i].y);
            textpref[i].text = "g= " + close[i].gcost.ToString() + "\nh= " + close[i].hcost.ToString() ;
        }*/
        return pathpos;
    }

    Vector2[] getpathmusuh2(Node nodeawal, Node nodeakhir)
    {
        List<Node> path = new List<Node>();
        Node currentnode = nodeakhir;

        while(currentnode != nodeawal)
        {
            path.Add(currentnode);
            currentnode = currentnode.Parent;
        }

        List<Vector2> pathpos = new List<Vector2>();
        Vector2 directionold = Vector2.zero;
        for (int i = 0; i < path.Count; i++)
        {
            Vector2 directionnew = new Vector2(path[i].gridx, path[i].gridy);
            if (directionnew != directionold)
            {
                pathpos.Add(path[i].arena);
            }
            directionold = directionnew;
        }
        grid.path = path;
        pathpos.Reverse();
        return pathpos.ToArray();
    }

   
    int Jarakgcost2(Node nodeA, Node nodeB)
    {
        int distancex = Mathf.Abs(nodeA.gridx - nodeB.gridx);
        int distancey = Mathf.Abs(nodeA.gridy - nodeB.gridy);
        if (distancex > distancey)
            return 7 * (distancex - distancey);
        return 7 * (distancey - distancex);
    } 
    int Jarakhcost2(Node nodeA, Node nodeB)
    {
        int distancex = Mathf.Abs(nodeA.gridx - nodeB.gridx);
        int distancey = Mathf.Abs(nodeA.gridy - nodeB.gridy);


        return (distancex + distancey) * 7;
    }

    
}
