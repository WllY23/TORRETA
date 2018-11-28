using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inicializador : MonoBehaviour {
    
    public int cant;
    public GameObject navi_01;
	// Use this for initialization
	void Start () {
        cant = 10;
        inicializar();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void inicializar()
    {
        for (int i=0; i < cant; i++)
        {
           GameObject ob = Instantiate(navi_01);
            ob.transform.position = Asignar_posicion();
        }
    }

    Vector3 Asignar_posicion()
    {
        Vector3 Asignar_posicion;

        Asignar_posicion.x = Random.Range(-100f, 100f); ;
        Asignar_posicion.y = Random.Range(0f, 50f);
        Asignar_posicion.z = Random.Range(-200f,200f);
        return Asignar_posicion;
    }


}
