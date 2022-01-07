using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject[] item;
    public Transform[] posisispawn;
    public float waktu;
    public  int i;
    

    // Start is called before the first frame update
    void Start()
    {
        waktu = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (btnmenu.menu_isbool == false)
        {
            waktu -= Time.deltaTime;
            if (waktu <= 0)
            {
                spawnobj();
                waktu = 1.5f;
            }
            
        }
    }

    void spawnobj()
    {
        //posisispawn = GetComponentInChildren<Transform>();
        i = Random.Range(0, posisispawn.Length);

        Instantiate(item[Random.Range(0, item.Length)], posisispawn[i].transform.position, Quaternion.identity);
        

    }

   
}
