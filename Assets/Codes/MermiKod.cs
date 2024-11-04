using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKod : MonoBehaviour
{
    float hizCarpani=20.0f;
   
    Yon _yon;
    Rigidbody2D _rigidBody2D;
    void Awake()
    {
        //GetComponent<Rigidbody2D>().velocity=new Vector2(hizCarpani,0.0f); //burada kendisi zamanla hizi carpar ve pozisyonun ne 
        //kadar degistigini bulur 
        //update'de yazdigimiz  transform.position+= new Vector3(0.06f,0.0f,0.0f); kodu yerine bunu yazdik.
        //boylece sinirlari gecmemis olacak. diger turlu, bizim yazdigimiz kod, unitynin yazgidinin uzerine yazdigi icin
        //mermi disari cikiyordu.
       
        _rigidBody2D=GetComponent<Rigidbody2D>();
        //eger bir nesneyi instantiate ile olusturuyorsan starti daha sonra cagiriyor veya cagirma sirasi farkli
        //buranin cagrilmasinin garanti olmasi icin awake kullaniyoruz
    }

    public Yon Yon
    {get {return _yon;}}

    public void YonAta(Yon yeniYon){
        _yon=yeniYon;
        switch(_yon){
            case Yon.Sag:
                _rigidBody2D.velocity=new Vector3(hizCarpani,0.0f,0.0f);
                break;
            case Yon.Sol:
                _rigidBody2D.velocity=new Vector3(-hizCarpani,0.0f,0.0f);
                transform.Rotate(0.0f,0.0f,180.0f); //mermiyi ters yone cevirdik. Dusmanda ayni prefabi kullanicaz sadece yonunu dgistirik.
                break;
        }
    }
//mermiler carpisirsa silinmeleri icin
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("DusmanMermi")||collision.CompareTag("UcakMermi")){
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

   
    //mermi sahneden ciktiktan sonra yok olsun
    private void OnTriggerExit2D(Collider2D collision) {
         if(collision.CompareTag("Sinirlar")){
        Destroy(gameObject);
       }
    }
  
    void Update()
    {
       
    }
}
