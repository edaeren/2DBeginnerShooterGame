using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OyunYoneticiKod : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI _txtPuan;
   [SerializeField] TextMeshProUGUI _txtYasam;
   int _puan; //baslangicta kendi 0 atar zaten benim 0 dememe gerek yok
    void Start()
    {
        PuanAta(0);
    
    }

    public void YasamAta(int yasam){
        _txtYasam.text="Yasam: " + yasam;
        if(yasam<=0){
            Time.timeScale=0.0f;  //timescale 0 olursa artik cizim yapmaz(pozisyon vs degismsez oyun durur)
        }
            
    }
    void PuanAta(int puan){
        _txtPuan.text= "Puan: " + puan;
    }

    public void PuanArttir(Puanlar yenipuan){
        _puan +=(int)yenipuan;
        PuanAta(_puan);
    }


    void Update()
    {
        
    }
}
