using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pemain : MonoBehaviour
{
    
    public static bool ismoving;
    public bool isminigame ;
    public bool islife;
    //public static bool finding;
    public float timetomove = 0.1f;
    public LayerMask layerobstacle;
    public Transform minigames;


    public static int nyawa_pemain;
    public static int target;
    public static int jumlah_masker;
    public static int jumlah_sarung; 
    public static int jumlah_kacamata;
    public static int jumlah_faceshield; 
    public static int jumlah_sarungkaki;
    public static int jumlah_hazmat;

    public Image fading;
    public Image hm1;
    public Image hm2;
    public Image hm3;
    public Image hb1;
    public Image hb2;
    public Image hb3;

    public AudioSource getmusuh;
    public AudioSource getapd;
    public AudioSource button;

    // Start is called before the first frame update
    void Start()
    {
       
        islife = true;
        fading.enabled = false;
        target = 100;        
        isminigame = false;
        if (catch_controller.minigames == 1)
        {
            minigames.transform.position = new Vector2(1.6f, 10.0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(menu.level == 1 && jumlah_masker >= target && jumlah_sarung >= target)
        {
            islife = false;
            fading.enabled = true;
            StartCoroutine(akhir(Color.clear, Color.black,0.5f));
            jumlah_kacamata = 0;
            jumlah_faceshield = 0;
            menu.level = 2;
            catch_controller.minigames = 0;
            print(menu.level);
        }

        if(menu.level == 2 && jumlah_kacamata >= target && jumlah_faceshield >= target)
        {
            islife = false;
            jumlah_sarungkaki = 0;
            jumlah_hazmat = 0;
            fading.enabled = true;
            StartCoroutine(akhir(Color.clear, Color.black, 0.5f));
            menu.level = 3;
            catch_controller.minigames = 0;
            print(menu.level);
        }
        if(jumlah_sarungkaki >= target && jumlah_hazmat >= target)
        {
            islife = false;
            fading.enabled = true;
            StartCoroutine(akhir(Color.clear, Color.black, 0.5f));
            menu.level = 4;
            catch_controller.minigames = 0;

        }

        if (nyawa_pemain == 3)
        {
            hm1.enabled = true;
            hm2.enabled = true;
            hm3.enabled = true;
            hb1.enabled = false;
            hb2.enabled = false;
            hb3.enabled = false;
        }
        if (nyawa_pemain == 2)
        {
            hm1.enabled = true;
            hm2.enabled = true;
            hm3.enabled = false;
            hb1.enabled = false;
            hb2.enabled = false;
            hb3.enabled = true;
        }
        if (nyawa_pemain == 1)
        {
            hm1.enabled = true;
            hm2.enabled = false;
            hm3.enabled = false;
            hb1.enabled = false;
            hb2.enabled = true;
            hb3.enabled = true;
        }
        if (nyawa_pemain == 0)
        {
            hm1.enabled = false;
            hm2.enabled = false;
            hm3.enabled = false;
            hb1.enabled = true;
            hb2.enabled = true;
            hb3.enabled = true;
        }
    }
    IEnumerator movementpemain(Vector2 direction)
    {
        ismoving = true;
        Vector2 posisiawal, posisibaru;
        posisiawal = this.transform.position;
        posisibaru = posisiawal + direction;
        float elapsedtime = 0;


        if (!Physics2D.Linecast(posisiawal, posisibaru, layerobstacle))
        {
            while (elapsedtime < timetomove)
            {
                this.transform.position = Vector2.Lerp(posisiawal, posisibaru, elapsedtime / timetomove);
                elapsedtime += Time.deltaTime;
                yield return null;
            }
            this.transform.position = posisibaru;
        }
        ismoving = false;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow) && !ismoving && islife && !isminigame && !btnmenu.menu_isbool)
        {
            StartCoroutine(movementpemain(Vector2.left));
        }
        if(Input.GetKey(KeyCode.RightArrow)&& !ismoving && islife && !isminigame && !btnmenu.menu_isbool)
        {
            StartCoroutine(movementpemain(Vector2.right));
        }
        if(Input.GetKey(KeyCode.UpArrow)&& !ismoving && islife && !isminigame && !btnmenu.menu_isbool)
        {
            StartCoroutine(movementpemain(Vector2.up));
        }
        if(Input.GetKey(KeyCode.DownArrow)&& !ismoving && islife && !isminigame && !btnmenu.menu_isbool)
        {
            StartCoroutine(movementpemain(Vector2.down));
        }
    }

    public void btnkanan()
    {
        if (islife&&!ismoving && !isminigame && !btnmenu.menu_isbool)
        {
            button.Play();
            StartCoroutine(movementpemain(Vector2.right));
        }
    }
    public void btnkiri()
    {
        if (islife && !ismoving && !isminigame && !btnmenu.menu_isbool)
        {
            button.Play();
            StartCoroutine(movementpemain(Vector2.left));
        }
    }
   public  void btnatas()
    {
        if (islife && !ismoving && !isminigame && !btnmenu.menu_isbool)
        {
            button.Play();
            StartCoroutine(movementpemain(Vector2.up));
        }
    }
    public void btnbawah()
    {
        if (islife && !ismoving && !isminigame && !btnmenu.menu_isbool)
        {
            button.Play();
            StartCoroutine(movementpemain(Vector2.down));
        }
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag=="musuh" && islife)
        {
            getmusuh.Play();
            if (menu.level == 1)
            {  
                nyawa_pemain -= 1;
                islife = false;
                
                
                if (nyawa_pemain > 0)
                {
                    catch_controller.minigames = 0;
                    fading.enabled = true;
                    StartCoroutine(fademusuh(Color.clear, Color.black, 0.5f));
                }
                   
                print(nyawa_pemain);
            }
            if (menu.level == 2)
            {  
                nyawa_pemain -= 1;
                islife = false;
                
                if (nyawa_pemain > 0)
                {
                    catch_controller.minigames = 0;
                    fading.enabled = true;
                    StartCoroutine(fademusuh(Color.clear, Color.black, 0.5f));
                }
                    
                print(nyawa_pemain);
            }
            if (menu.level == 3)
            {  
                nyawa_pemain -= 1;
                islife = false;
               
                if (nyawa_pemain > 0)
                {
                    catch_controller.minigames = 0;
                    fading.enabled = true;
                    StartCoroutine(fademusuh(Color.clear, Color.black, 0.5f));
                }
                   
                
            }

            if (nyawa_pemain <= 0)
            {
                nyawa_pemain = 0;
                
            }
        }

        if (collision.gameObject.tag == "masker" || collision.gameObject.tag == "sarung" || collision.gameObject.tag == "faceshield"
            || collision.gameObject.tag == "kacamata" || collision.gameObject.tag == "sarungkaki" || collision.gameObject.tag == "hazmat")
        {
            getapd.Play();
        }

        if (collision.gameObject.tag=="minigames" && islife)
        {
            isminigame = true;
            getapd.Play();
            fading.enabled = true;
            StartCoroutine(minigamesfade(Color.clear, Color.black, 0.5f));
            Destroy(collision);
        }

        
    }

    public IEnumerator akhir(Color from, Color to, float time)
    {
        float speed = 0.5f / time;
        float percent = 0;


        while (percent<1)
        {
            percent += Time.deltaTime * speed;
            fading.color = Color.Lerp(from, to, percent);
            yield return null;
        }

        SceneManager.LoadScene(4);
    }

    public IEnumerator minigamesfade(Color from, Color to, float time)
    {
        float speed = 0.5f / time;
        float percent = 0;


        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            fading.color = Color.Lerp(from, to, percent);
            yield return null;
        }

        SceneManager.LoadScene(5);
    }

    public IEnumerator fademusuh(Color from, Color to, float time)
    {
        float speed = 0.5f / time;
        float percent = 0;


        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            fading.color = Color.Lerp(from, to, percent);
            yield return null;
        }

        if (menu.level == 1)
        {
            
            SceneManager.LoadScene(1);
            
        }
        if (menu.level == 2)
        {
           
            SceneManager.LoadScene(2);
            
        }
        if (menu.level == 3)
        {
            
            SceneManager.LoadScene(3);
            
        }
    }

    
}
