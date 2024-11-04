using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using Random=UnityEngine.Random;

public class UcakKod : MonoBehaviour
{
    //burada deger atamaktansa startta veya awakete deger atamak lazim cunku editorde vs atanan degerler, bu degerin ustune yaziyor.
    //public yaparsak editor tarafindan gorulebilir ancak public yapmak hos degil. onun yerine serialized field kullaniyoruz

    [SerializeField] float hizCarpani;
    //getKeyDownin calisma mantigi yuzunden her bir tus icin baska bir boolean tanimlamiyiz. mesela buradaki tusabasildi
    //mi booleanini, asagi ok tusu icin de kullanamayiz.
   // Boolean tusaBasildiMi=false;  --ZZZ getkeydown kullanirsak gerek kalmiyr

   [SerializeField] Rigidbody2D _rigidBody;
   [SerializeField] GameObject _cikisNoktasi;
   [SerializeField] GameObject _mermiSablonu;
   [SerializeField] float _MermiCikisAraligi = 0.4f; //getKeyDown yerine getKey kullanicaz ama cikis araligini
   //ayarlamazsak bir anda bir sürü atiyor
   float _MermiGecenSuresi;
   Vector2 hiz;
  
   OyunYoneticiKod _oyunYoneticiKod;
    int _yasam=900;
    void Start()
    {
        //hizCarpani=10.0f;
       _rigidBody= GetComponent<Rigidbody2D>();
       //bunu gidip editorden de tasiyabiliriz
       _oyunYoneticiKod=GameObject.Find("OyunYonetici").GetComponent<OyunYoneticiKod>();
       _oyunYoneticiKod.YasamAta(_yasam);
    }

    void Update()
    {
        
        //ayni isi GetKeyDown ile, bu ifleri yazzamaya gerek kalmadan da yazabilriz.
        /*
        if(Input.GetKey(KeyCode.UpArrow)){
            if(!tusaBasildiMi){
                mesafe=yHiz*Time.deltaTime;   
            }
           tusaBasildiMi=true; 
        } else{
                tusaBasildiMi=false;
        }*/
        HareketEt();
        AtesKontrol();
       
    }
    /*
    void HareketEt(){
        hiz.x=0.0f;
        hiz.y=0.0f;
        //float y=0.0f;
        //float x=0.0f;
         //getKeyDown ile y
         if(Input.GetKey(KeyCode.UpArrow)){
            hiz.y=hizCarpani;
           // _rigidBody.velocity=new Vector2(0,10);
            //y=hizCarpani*Time.deltaTime;   
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            hiz.y=-hizCarpani;
           // _rigidBody.velocity=new Vector2(0,-10);
           // y=-hizCarpani*Time.deltaTime;   
        }
       // transform.position+= new Vector3(0.0f,y,0.0f);
     //x
        if(Input.GetKey(KeyCode.RightArrow)){
            hiz.x=hizCarpani;
           // x=hizCarpani*Time.deltaTime;   
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
            hiz.x=-hizCarpani;
            //x=-hizCarpani*Time.deltaTime;   
        }
       
      //  transform.position+= new Vector3(x,0.0f,0.0f);
       _rigidBody.velocity=hiz;
    }*/
     void HareketEt(){
        hiz.x=0.0f;
        hiz.y=0.0f;
      
      hiz.x=Input.GetAxis("Horizontal")*hizCarpani;
      hiz.y=Input.GetAxis("Vertical")*hizCarpani;

       _rigidBody.velocity=hiz;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Yon mermiYonu=collision.gameObject.GetComponent<MermiKod>().Yon;

        bool DusmanMermisiCarptiMi=collision.CompareTag("DusmanMermi");
        if(DusmanMermisiCarptiMi){
           YasamAzalt(UcakHasarlari.MermiCarpti);
           Destroy(collision.gameObject);
        }
    }
    public void YasamAzalt(UcakHasarlari hasar){
         _yasam-=(int)hasar;
         _oyunYoneticiKod.YasamAta(_yasam);
    }


    public void AtesKontrol(){
        /* getkeydown versionu
         if(Input.GetKeyDown(KeyCode.Space)){
        //Instantiate(_mermiSablonu).transform.position=new Vector3(Random.Range(-10,10), Random.Range(-10,10),0.0f);
        Instantiate(_mermiSablonu).transform.position=_cikisNoktasi.transform.position;
      }*/

        //getkey versiou
        //ne kadar basili tutarsak tutalim hep belirli araliklarla atacak. mermigecesuresi bi sayac olarak is gorur
        if(Input.GetKey(KeyCode.Space)){
            if(_MermiGecenSuresi >= _MermiCikisAraligi){
               // Instantiate(_mermiSablonu).transform.position=_cikisNoktasi.transform.position;
               var yeniMermi= Instantiate(_mermiSablonu);
               yeniMermi.transform.position=_cikisNoktasi.transform.position;
               yeniMermi.GetComponent<MermiKod>().YonAta(Yon.Sag);
               yeniMermi.tag="UcakMermi";
                _MermiGecenSuresi=0.0f;
            }
        }
         _MermiGecenSuresi += Time.deltaTime;
        
    }
}
