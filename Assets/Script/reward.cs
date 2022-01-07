using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reward : MonoBehaviour
{
    public GameObject reward1;
    public GameObject reward2;
    public GameObject reward3;

    public AudioSource button;


    // Start is called before the first frame update
    void Start()
    {
       
        if (pemain.jumlah_masker>=pemain.target &&  pemain.jumlah_sarung >= pemain.target)
        {
            reward1.SetActive(true);
            reward2.SetActive(false);
            reward3.SetActive(false);
        }
        if (pemain.jumlah_kacamata>=pemain.target &&  pemain.jumlah_faceshield >= pemain.target)
        {
            reward1.SetActive(false);
            reward2.SetActive(true);
            reward3.SetActive(false);
        }
        if (pemain.jumlah_hazmat>=pemain.target &&  pemain.jumlah_sarungkaki >= pemain.target)
        {
            reward1.SetActive(false);
            reward2.SetActive(false);
            reward3.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void oke_down()
    {
        if (menu.level == 2)
        {
            button.Play();
            SceneManager.LoadScene(2);
        }
        if (menu.level == 3)
        {
            button.Play();
            SceneManager.LoadScene(3);
        }
        if (menu.level == 4)
        {
            button.Play();
            SceneManager.LoadScene(0);
        }

    }
}
