using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanUreticiKod : MonoBehaviour
{
   [SerializeField] GameObject _DusmanSablon;
   [SerializeField] float _DusmanUretmeAraligi=0.4f;
   float _dusmanUretmeSayaci;
   [SerializeField] Transform _ustUretmeNoktasi;
   [SerializeField] Transform _altUretmeNoktasi;
   float _MaxY;
   float _MinY;
   float x;
   float y;
    void Start()
    {
        _MinY=_altUretmeNoktasi.position.y;
        _MaxY=_ustUretmeNoktasi.position.y;
        x=_altUretmeNoktasi.position.x;

    }

   
    void Update()
    {
        DusmanUret();
        /*
        if(Input.GetKey(KeyCode.K)){
            Instantiate(_DusmanSablon).transform.position=new Vector3(10.0f,10.0f,0.0f);
        }*/
    }

    public void DusmanUret(){
        if(_dusmanUretmeSayaci>= _DusmanUretmeAraligi){
            y=Random.Range(_MinY,_MaxY);
            Instantiate(_DusmanSablon).transform.position=new Vector3(x,y,0.0f);
            _dusmanUretmeSayaci=0.0f;
        }
        _dusmanUretmeSayaci += Time.deltaTime;
    }
}
