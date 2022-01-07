using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject panel_kredit;
    public GameObject panel_cara;
    public GameObject panel_keluar;
    public Button main;
    public Button cara_main;
    public Button keluar;
    public Button kredit;
    public AudioSource backgound;
    public AudioSource button;

    public static int level;

    private void Awake()
    {
        backgound.Play();
        backgound.loop = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        pemain.nyawa_pemain = 3;
        catch_controller.minigames = 0;
        pemain.jumlah_masker = 0;
        pemain.jumlah_sarung = 0;
        panel_cara.SetActive(false);
        panel_kredit.SetActive(false);
        panel_keluar.SetActive(false);
        main.enabled = true;
        cara_main.enabled = true;
        keluar.enabled = true;
        kredit.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void main_down()
    {
        if (level == 1)
        {
            pemain.jumlah_masker = 0;
            pemain.jumlah_sarung = 0;
            button.Play();
            StartCoroutine(wait());
            SceneManager.LoadScene(1);
        }
    }

    public void cara_main_down()
    {
        button.Play();
        StartCoroutine(wait());

        panel_cara.SetActive(true);
        panel_kredit.SetActive(false);
        panel_keluar.SetActive(false);
        main.enabled = false;
        cara_main.enabled = false;
        keluar.enabled = false;
        kredit.enabled = false;
       
    }

    public void kredit_down()
    {
        button.Play();
        StartCoroutine(wait());
        panel_cara.SetActive(false);
        panel_keluar.SetActive(false);
        panel_kredit.SetActive(true);
        main.enabled = false;
        cara_main.enabled = false;
        keluar.enabled = false;
        kredit.enabled = false;

        
    }
    public void keluar_down()
    {
        button.Play();
        StartCoroutine(wait());
        panel_cara.SetActive(false);
        panel_keluar.SetActive(true);
        panel_kredit.SetActive(false);
        main.enabled = false;
        cara_main.enabled = false;
        keluar.enabled = false;
        kredit.enabled = false;

        
    }

    public void oke_down() {
        button.Play();
        panel_cara.SetActive(false);
        panel_kredit.SetActive(false);
        panel_keluar.SetActive(false);
        main.enabled = true;
        cara_main.enabled = true;
        keluar.enabled = true;
        kredit.enabled = true;
    }

    public void yes_down() {
        button.Play();
        Application.Quit();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(.2f);
    }
}
