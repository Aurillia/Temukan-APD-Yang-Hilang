using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnmenu : MonoBehaviour
{
    public static bool menu_isbool;
    

    public Button buttonmenu;
    public Button kanan;
    public Button kiri;
    public Button atas;
    public Button bawah;

    public Text item1;
    public Text item2;
    
    public Text minigamesitem1;
    public Text minigamesitem2;

    public GameObject panel_menu;
    public GameObject panel_gameover;

    public AudioSource button;

    
    // Start is called before the first frame update
    void Start()
    {
        
        menu_isbool = false;
        panel_gameover.SetActive(false);
        if (catch_controller.minigames == 0)
        {
            minigamesitem1.enabled = false;
            minigamesitem2.enabled = false;
        }
        if (catch_controller.minigames == 1)
        {
            minigamesitem1.enabled = true;
            minigamesitem2.enabled = true;
            StartCoroutine(fadetext(Color.white, Color.clear, 0.3f));
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (menu_isbool == false)
        {
            panel_menu.SetActive(false);
            buttonmenu.enabled = true;

            kanan.enabled = true;
            kiri.enabled = true;
            atas.enabled = true;
            bawah.enabled = true;
        }
        if (menu_isbool == true)
        {
            panel_menu.SetActive(true);
            buttonmenu.enabled = false;

            kanan.enabled = false;
            kiri.enabled = false;
            atas.enabled = false;
            bawah.enabled = false;
        }

        if (menu.level == 1)
        {
            item1.text = pemain.jumlah_masker + " / " + pemain.target;
            item2.text = pemain.jumlah_sarung + " / " + pemain.target;
        }
        if (menu.level == 2)
        {
            item1.text = pemain.jumlah_kacamata + " / " + pemain.target;
            item2.text = pemain.jumlah_faceshield + " / " + pemain.target;
        }
        if (menu.level == 3)
        {
            item1.text = pemain.jumlah_sarungkaki + " / " + pemain.target;
            item2.text = pemain.jumlah_hazmat + " / " + pemain.target;
        }

        if (pemain.nyawa_pemain == 0)
        {
           panel_gameover.SetActive(true);
        }

        if (catch_controller.minigames == 1)
        {
            if (menu.level == 1)
            {
                minigamesitem1.text = " Masker +" + catch_controller.masker;
                minigamesitem2.text = " Sarung Tangan +" + catch_controller.sarung;
            }
            if (menu.level == 2)
            {
                minigamesitem1.text = "Kacamata +" + catch_controller.kacamata;
                minigamesitem2.text = "Faceshield +" + catch_controller.faceshield;
            }
            if (menu.level == 3)
            {
                minigamesitem1.text = "Sarung Kaki +" + catch_controller.sarung_kaki;
                minigamesitem2.text = "Hazmat +" + catch_controller.hazmat;
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.1f);
    }

    public void menu_down()
    {
        button.Play();
        StartCoroutine(wait());
        menu_isbool = true;
    }
    public void lanjut_down()
    {
        button.Play();
        StartCoroutine(wait());
        menu_isbool = false;
    }
    public void mainmenu_down()
    {
        button.Play();
        StartCoroutine(wait());
        SceneManager.LoadScene(0);
    }
    public void muat_ulang_down()
    {
        button.Play();
        if (menu.level == 1)
        {
            StartCoroutine(wait());
            pemain.nyawa_pemain = 3;
            pemain.jumlah_masker = 0;
            pemain.jumlah_sarung = 0;
            SceneManager.LoadScene(1);
        }
        if (menu.level == 2)
        {
            StartCoroutine(wait());
            pemain.nyawa_pemain = 3;
            pemain.jumlah_kacamata = 0;
            pemain.jumlah_faceshield = 0;
            SceneManager.LoadScene(2);
        }
        if (menu.level == 3)
        {
            StartCoroutine(wait());
            pemain.nyawa_pemain = 3;
            pemain.jumlah_hazmat = 0;
            pemain.jumlah_sarungkaki = 0;
            SceneManager.LoadScene(3);
        }

    }

    public IEnumerator fadetext(Color from, Color to, float time)
    {
        yield return new WaitForSeconds(0.15f);
        minigamesitem1.enabled = true;
        minigamesitem1.color = new Color(1, 1, 1, 1);
        minigamesitem2.enabled = true;
        minigamesitem2.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.5f);
        float speed = 0.5f / time;
        float percent = 0;
        while (percent < 1)
        {
            percent += Time.deltaTime * speed;
            minigamesitem1.color = Color.Lerp(from, to, percent);
            minigamesitem2.color = Color.Lerp(from, to, percent);
            if (menu.level == 1)
            {
                pemain.jumlah_masker += catch_controller.masker;
                catch_controller.masker = 0;
                pemain.jumlah_sarung += catch_controller.sarung;
                catch_controller.sarung = 0;
                catch_controller.minigames = 0;
            }
            if (menu.level == 2)
            {
                pemain.jumlah_kacamata += catch_controller.kacamata;
                catch_controller.kacamata = 0;
                pemain.jumlah_faceshield += catch_controller.faceshield;
                catch_controller.faceshield = 0;
                catch_controller.minigames = 0;
            }
            if (menu.level == 3)
            {
                pemain.jumlah_sarungkaki += catch_controller.sarung_kaki;
                catch_controller.sarung_kaki = 0;
                pemain.jumlah_hazmat += catch_controller.hazmat;
                catch_controller.hazmat = 0;
                catch_controller.minigames = 0;
            }
            yield return null;
        }
        if(minigamesitem1.color==Color.clear && minigamesitem2.color==Color.clear)
        {
            minigamesitem1.enabled = false;
            minigamesitem2.enabled = false;
        }
    }
}
