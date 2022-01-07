using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class camerafollow : MonoBehaviour
{

    public GameObject followobject;
    public Vector2 followoffset;
    public float speed;
    private Vector2 threshold;

    private void Start()
    {
        threshold = calculatethreshold();
        speed = 8.5f;
    }

    private void FixedUpdate()
    {
        Vector2 follow = followobject.transform.position;
        float xdiffrence = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float ydiffrence = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newpos = transform.position;
        if(Mathf.Abs(xdiffrence) >= threshold.x)
        {
            newpos.x = follow.x;

        }
        if (Mathf.Abs(ydiffrence) >= threshold.y)
        {
            
                newpos.y = follow.y;
            
            
        }

        transform.position = Vector3.MoveTowards(transform.position, newpos, speed * Time.deltaTime);
    }
    private Vector3 calculatethreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followoffset.x;
        t.y -= followoffset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector2 border = calculatethreshold();
        //Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
