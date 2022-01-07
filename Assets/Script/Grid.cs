using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    public LayerMask layerobstacle;
    public Vector2 arena;
    public float radiusgrid;
    public float jarak_grid;
    public bool displaygizmoz;
    public Transform pemain;
    public Transform musuh;

    Node[,] grid;
    int arenax, arenay;
    float diameternode;
    public List<Node> path;
    

    public AudioSource background;


    private void Awake()
    {
        
        diameternode = radiusgrid * 2;
        arenax = Mathf.RoundToInt(arena.x / diameternode);
        arenay = Mathf.RoundToInt(arena.y / diameternode);

        creategrid();

        background.Play();
        background.loop = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (menu.level == 1)
        {
            pemain.transform.position = new Vector2(4.6f, 1.7f);
            if (catch_controller.minigames == 1)
            {
                pemain.transform.position = new Vector2(10.6f, -5.3f);
            }
        }
        if (menu.level == 2)
        {
            pemain.transform.position = new Vector2(13.6f, -6.3f);
            if (catch_controller.minigames == 1)
            {
                pemain.transform.position = new Vector2(1.6f, -5.3f);
            }
        }
        if (menu.level == 3)
        {
            pemain.transform.position = new Vector2(0.6f, -9.3f);
            if (catch_controller.minigames == 1)
            {
                pemain.transform.position = new Vector2(10.6f, -5.3f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void creategrid()
    {
        grid = new Node[arenax, arenay];
        Vector2 worldbottomleft = (Vector2)transform.position - Vector2.right * arena.x / 2 - Vector2.up * arena.y / 2;

        for (int x = 0; x < arenax; x++)
        {
            for (int y = 0; y < arenay; y++)
            {
                Vector2 worldpoint = worldbottomleft + Vector2.right * (x * diameternode + radiusgrid) + Vector2.up * (y + diameternode - radiusgrid);
                bool path = (Physics2D.OverlapCircle(worldpoint, radiusgrid, layerobstacle) == null);// membedakan grid yang bisa dilalui dan tidak.
                grid[x, y] = new Node(path, worldpoint, x, y);

            }
        }
    }

    // Deklarasi Node yang berdampingan dengan current node
    public List<Node> GetNeighbours(Node node)
    {
         List<Node> neighbornode = new List<Node>();
         int checkx;
         int checky;

         //kanan
         checkx = node.gridx + 1;
         checky = node.gridy;

         if (checkx >= 0 && checkx < arenax)
         {
             if (checky >= 0 && checky < arenay)
             {
                 neighbornode.Add(grid[checkx, checky]);
             }
         }
         //kiri
         checkx = node.gridx - 1;
         checky = node.gridy;

         if (checkx >= 0 && checkx < arenax)
         {
             if (checky >= 0 && checky < arenay)
             {
                 neighbornode.Add(grid[checkx, checky]);
             }
         }
         //atas
         checkx = node.gridx;
         checky = node.gridy + 1;

         if (checkx >= 0 && checkx < arenax)
         {
             if (checky >= 0 && checky < arenay)
             {
                 neighbornode.Add(grid[checkx, checky]);
             }
         }
         //bawah
         checkx = node.gridx;
         checky = node.gridy - 1;

         if (checkx >= 0 && checkx < arenax)
         {
             if (checky >= 0 && checky < arenay)
             {
                 neighbornode.Add(grid[checkx, checky]);
             }
         }
         return neighbornode;
    }

    //mengambil titik posisi node
    public Node pointNode(Vector2 arenapos)
    {
        float posisix = ((arenapos.x + (0 - this.transform.position.x)) + arena.x / 2) / arena.x;
        float posisiy = ((arenapos.y + (0 - this.transform.position.y)) + arena.y / 2) / arena.y;

        posisix = Mathf.Clamp01(posisix);
        posisiy = Mathf.Clamp01(posisiy);

        int x = Mathf.RoundToInt((arenax - 1) * posisix);
        int y = Mathf.RoundToInt((arenay - 1) * posisiy);
        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position, new Vector3(arena.x, arena.y, 0));
        if(grid!=null && displaygizmoz)
        {
            Node nodepemain = pointNode(pemain.transform.position);
            Node nodemusuh = pointNode(musuh.transform.position);
            foreach (Node n in grid)
            {
               // Gizmos.color = Color.red;
                Gizmos.color = new Color(1, 0.1f, 0, 0);
                if (n.path)
                {
                   // Gizmos.color = Color.white;
                    Gizmos.color = new Color(1, 0.1f, 0, 0);
                }
                if (nodepemain == n)
                {
                   // Gizmos.color = Color.green;
                    Gizmos.color = new Color(1, 0.1f, 0, 0);
                }
                if (nodemusuh == n)
                {
                    //Gizmos.color = Color.yellow;
                    Gizmos.color = new Color(1, 0.1f, 0, 0);
                }
                if (path!=null)
                {
                    if (path.Contains(n))
                    {
                       // Gizmos.color = Color.black;
                       Gizmos.color = new Color(0, 0, 0, 0f);
                       // gizmoscolor(Color.black, Color.clear, 0.05f);
                    }
                }
                Gizmos.DrawCube(n.arena, Vector3.one * (diameternode - jarak_grid));
            }
        }
    }

    
}
