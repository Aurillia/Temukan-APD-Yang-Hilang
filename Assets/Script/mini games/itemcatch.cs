using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;

public class itemcatch : MonoBehaviour
{
    public float speed;
    //public AudioSource getapd;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if(!catch_controller.ismenu)
            this.transform.Translate(-Vector3.up * Time.deltaTime * speed);
        if(catch_controller.ismenu)
            this.transform.Translate(-Vector3.up * Time.deltaTime * 0);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.gameObject.tag== "masker")
        {
           if (collision.gameObject.tag == "basket")
           {
               // getapd
                catch_controller.masker += 1;
               // pemain.jumlah_masker += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "ground")
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "sarung")
        {
           
            if (collision.gameObject.tag == "basket")
            {
                catch_controller.sarung += 1;
                //pemain.jumlah_sarung += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "ground")
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "faceshield")
        {
            if (collision.gameObject.tag == "basket")
            {
                catch_controller.faceshield += 1;
                //pemain.jumlah_faceshield += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag== "ground") 
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "kacamata")
        {
            if (collision.gameObject.tag == "basket")
            {
                catch_controller.kacamata += 1;
                pemain.jumlah_kacamata += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "ground")
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "sarungkaki")
        {
            if (collision.gameObject.tag == "basket")
            {
                catch_controller.sarung_kaki += 1;
                pemain.jumlah_sarungkaki += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "ground")
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }
        if (this.gameObject.tag == "hazmat")
        {
            if (collision.gameObject.tag == "basket")
            {
                catch_controller.hazmat += 1;
                pemain.jumlah_hazmat += 1;
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag == "ground")
            {
                catch_controller.fail += 1;
                Destroy(this.gameObject);
            }
        }      
        if (this.gameObject.tag == "bomb")
        {
            if (collision.gameObject.tag == "basket")
            {
                if (menu.level == 1)
                {
                    catch_controller.masker = Mathf.RoundToInt(catch_controller.masker * 0.5f);
                    catch_controller.sarung = Mathf.RoundToInt(catch_controller.sarung * 0.5f);
                    Destroy(this.gameObject);
                }
                if (menu.level == 2)
                {
                    catch_controller.faceshield = Mathf.RoundToInt(catch_controller.faceshield * 0.5f);
                    catch_controller.kacamata = Mathf.RoundToInt(catch_controller.kacamata * 0.5f);
                    Destroy(this.gameObject);
                }
                if (menu.level == 3)
                {
                    catch_controller.sarung_kaki = Mathf.RoundToInt(catch_controller.sarung_kaki * 0.5f);
                    catch_controller.hazmat = Mathf.RoundToInt(catch_controller.hazmat * 0.5f);
                    Destroy(this.gameObject);
                }
            }
            if (collision.gameObject.tag == "ground")
            {
                Destroy(this.gameObject);
            }
        }       
    }
}
