using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.AI;
using System.Text;
using UnityEngine;

public class giris : MonoBehaviour
{

    //Tanımlamalar
    float deprem_suresi;
    int dizi_eleman;
    public string eq_light_x_File, eq_light_z_File, eq_strong_x_File, eq_strong_z_File;
    string eq_light_x_Contents, eq_light_z_Contents, eq_strong_x_Contents, eq_strong_z_Contents;
    public GUIStyle GUIStyle, GUIStyle2;
    string[] eq_light_x_dizi, eq_light_z_dizi, eq_strong_x_dizi, eq_strong_z_dizi;
    
    void Start()
    {
        dosyaların_atanması();
        dosyaların_okunması();
        Time.timeScale = 0.0f;
        dizi_eleman = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1.0f && dizi_eleman != eq_light_x_dizi.Length)
        {
            dizi_eleman++;
        }


        deprem_suresi = islemler.depremsuresi;

    }


    //Simülasyon Ekranı
    private void OnGUI()
    {

        GUI.Label(new Rect(600, 150, Screen.width, Screen.height), "Ortalama İvme", GUIStyle2);
        GUI.Label(new Rect(600, 195, Screen.width, Screen.height), "Anlık İvme", GUIStyle2);

        //Deprem sürelerinin (light/strong) ekrana yazdırımı
        if (Time.time < deprem_suresi)
        {
            GUI.Label(new Rect(600, 125, Screen.width, Screen.height), Time.time + "/" + deprem_suresi, GUIStyle);
        }
        else
        {
            GUI.Label(new Rect(600, 125, Screen.width, Screen.height), deprem_suresi + "/" + deprem_suresi, GUIStyle);
        }

        // Deprem verilerinin seçime göre (light/strong) ekrana yazdırımı 
        if (deprem_suresi == 149.03f && dizi_eleman < eq_light_x_dizi.Length)
        {
            GUI.Label(new Rect(600, 170, Screen.width, Screen.height), "(0.00,0.00,0.00)", GUIStyle2);
            GUI.Label(new Rect(600, 215, Screen.width, Screen.height), eq_light_x_dizi[dizi_eleman] + "/0.0/" + eq_light_z_dizi[dizi_eleman], GUIStyle);
        }

        else if (deprem_suresi == 27.15f && dizi_eleman < eq_strong_x_dizi.Length)
        {
            GUI.Label(new Rect(600, 215, Screen.width, Screen.height), eq_strong_x_dizi[dizi_eleman] + "/0.0/" + eq_strong_z_dizi[dizi_eleman], GUIStyle);
            GUI.Label(new Rect(600, 170, Screen.width, Screen.height), "(0.18,0.00,0.07)", GUIStyle2);
        }
        else
        {
            GUI.Label(new Rect(600, 215, Screen.width, Screen.height), "0", GUIStyle);
            GUI.Label(new Rect(600, 170, Screen.width, Screen.height), "0", GUIStyle2);
        }


    }

    //Dosyaların okunması
    void dosyaların_okunması()
    {

        //eq_light_x dosyasının okunması
        TextAsset eq_light_x_Assets = (TextAsset)Resources.Load(eq_light_x_File);
        eq_light_x_Contents = eq_light_x_Assets.text;

        //eq_light_z dosyasının okunması
        TextAsset eq_light_z_Assets = (TextAsset)Resources.Load(eq_light_z_File);
        eq_light_z_Contents = eq_light_z_Assets.text;

        //eq_strong_x dosyasının okunması
        TextAsset eq_strong_x_Assets = (TextAsset)Resources.Load(eq_strong_x_File);
        eq_strong_x_Contents = eq_strong_x_Assets.text;

        //eq_strong_z dosyasının okunması
        TextAsset eq_strong_z_Assets = (TextAsset)Resources.Load(eq_strong_z_File);
        eq_strong_z_Contents = eq_strong_z_Assets.text;

        //Dosyalardan okunan verilerin teker teker ayrıştırılıp dizilere atanması
        eq_light_x_dizi = eq_light_x_Contents.Split(',');
        eq_light_z_dizi = eq_light_z_Contents.Split(',');
        eq_strong_x_dizi = eq_strong_x_Contents.Split(',');
        eq_strong_z_dizi = eq_strong_z_Contents.Split(',');

    }

    //Okunacak dosyaların atanması
    void dosyaların_atanması()
    {
        eq_light_x_File = "eq-light-x";
        eq_light_z_File = "eq-light-z";
        eq_strong_x_File = "eq-strong-x";
        eq_strong_z_File = "eq-strong-z";

    }

}
