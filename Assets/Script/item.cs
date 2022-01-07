using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (this.gameObject.tag == "masker")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_masker += 1;
                Destroy(this.gameObject);
            }
        } 
        if (this.gameObject.tag == "sarung")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_sarung += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "kacamata")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_kacamata += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "faceshield")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_faceshield += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "sarungkaki")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_sarungkaki += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "hazmat")
        {
            if (collision.gameObject.name == "pemain")
            {
                pemain.jumlah_hazmat += 1;
                Destroy(this.gameObject);
            }
        }
    }
}
