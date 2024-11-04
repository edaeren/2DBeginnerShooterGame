using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKod : MonoBehaviour
{
    int yasam=5;
    [SerializeField] GameObject _mermiSablonu;
    [SerializeField] float _mermiFirlatmaAraligi=0.4f;
    float _mermiGecenSure=0.0f;
     OyunYoneticiKod _oyunYoneticiKod;
     UcakKod _ucakKod;
    void Awake()
    {
         _oyunYoneticiKod=GameObject.Find("OyunYonetici").GetComponent<OyunYoneticiKod>();
        GetComponent<Rigidbody2D>().velocity=new Vector2(-10.0f,0.0f);
         _ucakKod=GameObject.Find("Ucak").GetComponent<UcakKod>();
    }
    
    public int Vuruldu(){
        yasam--;
        if(yasam==0){
            Destroy(gameObject);
        }
        return yasam;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("solSinir")){
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ucak")){
            
            Debug.Log("Collision with Ucak detected, destroying Dusman.");
            Destroy(gameObject);
            _ucakKod.YasamAzalt(UcakHasarlari.DusmanCarpti);
        }

      if(collision.CompareTag("UcakMermi")){
        Destroy(collision.gameObject);
        //oyun icerisinde adini bildigimiz bi gameobjecte erisebilmemizi saglar
        _oyunYoneticiKod.PuanArttir(Puanlar.DusmanVuruldu);

        //Destroy(collision.gameObject);
        if(Vuruldu()==0){
         _oyunYoneticiKod.PuanArttir(Puanlar.DusmanYokEdildi);
        }
      }
    
    }
    // Update is called once per frame
    void Update()
    {
        MermiFirlat();
    }

    void MermiFirlat(){
        if(_mermiGecenSure>=_mermiFirlatmaAraligi){
            var yeniMermi= Instantiate(_mermiSablonu);
            yeniMermi.transform.position=transform.position;
            yeniMermi.GetComponent<MermiKod>().YonAta(Yon.Sol);
            yeniMermi.tag="DusmanMermi";
            _mermiGecenSure=0.0f;
        }
        else{
             _mermiGecenSure+=Time.deltaTime;
        }
       
    }
}
