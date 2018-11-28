using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject[] orbits;
    public GameObject orbitPoint;
    GameObject orbitClone;

	// Use this for initialization
	void Start ()
    {
        orbits = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            orbitClone = Instantiate(orbitPoint, transform.position, Quaternion.identity);
            Vector3 orbita = new Vector3();
            orbita.x = Random.Range(-30, 30);
            orbita.y = Random.Range(-30, 30);
            orbita.z = Random.Range(-30, 30);
            orbitClone.transform.position = orbita;
            GameObject wayPoint = orbitClone;
            orbits[i] = wayPoint;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
