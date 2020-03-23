using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class islemler : MonoBehaviour {

    public GameObject[] GameObject;

    public static float depremsuresi;

    public void Deprem_Siddeti_Sec(Dropdown drop)
    {
        if (drop.value == 0)
        {
            depremsuresi = 0.0f;
            Debug.Log(depremsuresi);
        }
        if (drop.value == 1)
        {
            depremsuresi = 27.15f;
            Debug.Log(depremsuresi);
        }
        if (drop.value == 2)
        {
            depremsuresi = 149.03f;
            Debug.Log(depremsuresi);
        }
        

    }




public void obje_dusur()
    {
        int sayi;
        sayi = Random.Range(0, 3);
        Vector3 sira = new Vector3(Random.Range(261, 268), 9, Random.Range(232, 237));
        Instantiate(GameObject[sayi], sira, gameObject.transform.rotation);
    }

 public void baslat()
    {
        Time.timeScale = 1.0f;
    }   

public void durdur()
    {
        Time.timeScale = 0.0f;
    }

}
