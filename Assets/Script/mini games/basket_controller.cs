using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket_controller : MonoBehaviour
{
    public float startposx;
    public bool holding = false;

    public AudioSource getapd;
    public AudioSource getnotapd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (holding)
        {
            Vector2 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);

            this.transform.localPosition = new Vector2(mousepos.x - startposx, this.transform.localPosition.y);
            if(this.transform.localPosition.x >= 3.25f)
            {
                this.transform.localPosition = new Vector2(3.25f, this.transform.localPosition.y);
            }
            if(this.transform.localPosition.x <= -8.8f)
            {
                this.transform.localPosition = new Vector2(-8.8f, this.transform.localPosition.y);
            }
        }

       
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos;
            mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            startposx = mousepos.x - this.transform.localPosition.x;

            holding = true;
        }
    }
    private void OnMouseUp()
    {
        holding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="masker"|| collision.gameObject.tag == "sarung" || collision.gameObject.tag == "faceshield"
            || collision.gameObject.tag == "kacamata"|| collision.gameObject.tag == "sarungkaki"|| collision.gameObject.tag == "hazmat")
        {
            getapd.Play();
        }
        if (collision.gameObject.tag == "bomb")
        {
            getnotapd.Play();
        }
    }
}
