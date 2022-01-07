using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class catch_controller : MonoBehaviour
{
    
    public static int minigames = 0;

    public bool stopspawn;
    public static bool ismenu;

    public float spawntime;
    public float spawndelay;
    public float speedbasket;
   
    public GameObject[] spawning1;
    public GameObject[] spawning2;
    public GameObject[] spawning3;
    public GameObject panel_menu;
    public GameObject image_masker;
    public GameObject image_sarung;
    public GameObject image_faceshield;
    public GameObject image_kacamata;
    public GameObject image_sarungkaki;
    public GameObject image_hazmat;

    public Transform basket;
    public Button btn_menu;

    public Text scoretext1;
    public Text scoretext2;
    public Text textfail;

    public static int masker;
    public static int sarung;
    public static int faceshield;
    public static int kacamata;
    public static int sarung_kaki;
    public static int hazmat;
    public static int fail;

    public AudioSource button;
    public AudioSource background;


    private void Awake()
    {
        background.Play();
        background.loop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawndelay = 0.95f;
        spawntime = 1f;
        speedbasket = 4f;
        ismenu = false;

        InvokeRepeating("spawnitem", spawntime, spawndelay);


        panel_menu.SetActive(false);
        btn_menu.enabled=true;

        if (menu.level == 1)
        {
            image_masker.SetActive(true);
            image_sarung.SetActive(true);
            image_faceshield.SetActive(false);
            image_kacamata.SetActive(false);
            image_sarungkaki.SetActive(false);
            image_hazmat.SetActive(false);
        }
        if (menu.level == 2)
        {
            image_masker.SetActive(false);
            image_sarung.SetActive(false);
            image_faceshield.SetActive(true);
            image_kacamata.SetActive(true);
            image_sarungkaki.SetActive(false);
            image_hazmat.SetActive(false);
        }
        if (menu.level == 3)
        {
            image_masker.SetActive(false);
            image_sarung.SetActive(false);
            image_faceshield.SetActive(false);
            image_kacamata.SetActive(false);
            image_sarungkaki.SetActive(true);
            image_hazmat.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void spawnitem()
    {
        Vector3 postspawn = new Vector3(Random.Range(-8.5f, 3f), 6.5f, 0);
        if (!ismenu)
        {
            if (menu.level == 1)
            {
                GameObject spawnobject = spawning1[Random.Range(0, spawning1.Length)];
                Instantiate(spawnobject, postspawn, Quaternion.identity);
            }
            if (menu.level == 2)
            {
                GameObject spawnobject = spawning2[Random.Range(0, spawning2.Length)];
                Instantiate(spawnobject, postspawn, Quaternion.identity);
            }
            if (menu.level == 3)
            {
                GameObject spawnobject = spawning3[Random.Range(0, spawning3.Length)];
                Instantiate(spawnobject, postspawn, Quaternion.identity);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(wait_fail());
        if (!ismenu)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                basket.transform.Translate(-Vector3.right * Time.deltaTime * speedbasket);
                if (basket.transform.position.x <= -8.8f)
                {
                    basket.transform.position = new Vector3(-8.8f, basket.transform.position.y, 1);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                basket.transform.Translate(Vector3.right * Time.deltaTime * speedbasket);
                if (basket.transform.position.x >= 3.25f)
                {
                    basket.transform.position = new Vector3(3.25f, basket.transform.position.y, 1);
                }
            }
        }
        if (menu.level == 1)
        {
            scoretext1.text = " = " + masker;
            scoretext2.text = " = " + sarung;
            textfail.text =" = " + fail + " / 5";
        }
        if (menu.level == 2)
        {
            scoretext1.text = " = " + kacamata;
            scoretext2.text = " = " + faceshield;
            textfail.text =" = " + fail + " / 5";
        }
        if (menu.level == 3)
        {
            scoretext1.text = " = " + sarung_kaki;
            scoretext2.text = " = " + hazmat;
            textfail.text =" = " + fail + " / 5";
        }

    }

   IEnumerator wait_fail()
    {
       if (fail == 5 && menu.level==1)
       {
            minigames = 1;
         SceneManager.LoadScene(1);
       }
       if (fail == 5 && menu.level==2)
       {
            minigames = 1;
         SceneManager.LoadScene(2);
       }
       if (fail == 5 && menu.level==3)
       {
            minigames = 1;
         SceneManager.LoadScene(3);
       }
        yield return new WaitForSeconds(0.1f);
       
    }

    public void menu_down()
    {
        StartCoroutine(waitmenu());
    }
     public void lanjut_down()
    {
        StartCoroutine(lanjut());
    }
     public void selesai()
    {
        StartCoroutine(backtogame());
    }

    IEnumerator waitmenu()
    {
        button.Play();
        panel_menu.SetActive(true);
        ismenu = true;
        btn_menu.enabled = false;
        yield return new WaitForSeconds(0.25f);
    }

    IEnumerator lanjut()
    {
        button.Play();
        panel_menu.SetActive(false);
        ismenu = false;
        btn_menu.enabled = false;
        yield return new WaitForSeconds(0.25f);
    }
    IEnumerator backtogame()
    {
        button.Play();
        panel_menu.SetActive(false);

        if (menu.level == 1)
        {
            minigames = 1;
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.25f);
        }
        if (menu.level == 2)
        {
            minigames = 1;
            SceneManager.LoadScene(2);
            yield return new WaitForSeconds(0.25f);
        }
        if (menu.level == 3)
        {
            minigames = 1;
            SceneManager.LoadScene(3);
            yield return new WaitForSeconds(0.25f);
        }
       
    }
}
