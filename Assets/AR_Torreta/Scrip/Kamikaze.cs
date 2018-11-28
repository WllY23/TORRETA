using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    KamikazeE bomb;
    public Transform target;
    const float trigger = 2f;

	// Use this for initialization
	void Start ()
    {
        bomb.KamSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movi();
    }

    public void Movi()
    {
        transform.LookAt(target.transform);
        transform.Translate(0.0f, 0.0f, bomb.KamSpeed * Time.deltaTime);
    }
}
