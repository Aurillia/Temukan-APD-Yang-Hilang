using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh : MonoBehaviour
{
    public Transform target1,target2;
    Transform pemainkarakter;
    
    public float speed_musuh;
    public int timer;
    public Vector2[] path_musuh;
    
    int targetindex;
    
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(jalan_musuh1());
    }

    // Update is called once per frame
    void Update()
    {
        if (!btnmenu.menu_isbool)
        {

            pemainkarakter = target1;
            
        }
        if (btnmenu.menu_isbool)
        {
            target2.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            pemainkarakter = target2;

            //StopCoroutine(jalan_musuh1());
        }
    }
    IEnumerator jalan_musuh1()
    {
        
        if (!btnmenu.menu_isbool)
        {
            pemainkarakter = target1;
        }
        if (btnmenu.menu_isbool)
        {
            pemainkarakter = target2;
        }
        if (this.gameObject.name == "musuh1")
        {
            Vector2 posisiawaltarget = (Vector2)pemainkarakter.position + Vector2.up;
            while (true)
            {
                if (posisiawaltarget != (Vector2)pemainkarakter.position)
                {
                    posisiawaltarget = (Vector2)pemainkarakter.position;

                    path_musuh = pathfinding.runpathfind(this.transform.position, pemainkarakter.transform.position);
                    StopCoroutine("movement_musuh1");
                    StartCoroutine("movement_musuh1");

                }
                yield return new WaitForSeconds(.25f);
            }
        }
        if (this.gameObject.name == "musuh2")
        {
            Vector2 posisiawaltarget = (Vector2)pemainkarakter.position + Vector2.up;
            while (true)
            {
                if (posisiawaltarget != (Vector2)pemainkarakter.position)
                {
                    posisiawaltarget = (Vector2)pemainkarakter.position;

                    path_musuh = pathfinding.runpathfind2(this.transform.position, pemainkarakter.transform.position);
                    StopCoroutine("movement_musuh1");
                    StartCoroutine("movement_musuh1");

                }
                yield return new WaitForSeconds(.25f);
            }
        }
      
    }

    IEnumerator movement_musuh1()
    {
        if (path_musuh.Length > 0)
        {
            targetindex = 0;
            Vector2 currentpathpoint = path_musuh[0];

            while (true)
            {
                if ((Vector2)this.transform.position == currentpathpoint)
                {
                    targetindex++;
                    if (targetindex >= path_musuh.Length)
                    {
                        yield break;
                    }
                    currentpathpoint = path_musuh[targetindex];
                }
                this.transform.position = Vector2.MoveTowards(this.transform.position, currentpathpoint, speed_musuh * Time.deltaTime);
                yield return null;
            }
        }
    }
    
}
