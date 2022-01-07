using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool path;
    public Vector2 arena;
    public int gridx;
    public int gridy;

    public int gcost;
    public int hcost;
    public Node Parent;

    public Node(bool ispath, Vector2 isarena, int isgridx, int isgridy)
    {
        path = ispath;
        arena = isarena;
        gridx = isgridx;
        gridy = isgridy;
    }
    public int fcost
    {
        get
        {
            return gcost + hcost;
        }
    }
}
