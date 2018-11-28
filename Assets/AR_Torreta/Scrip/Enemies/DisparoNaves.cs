using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadosEnemi//si esta en calma o en ataque
{
    patrolling, atack
}

public class DisparoNaves : MonoBehaviour
{
    public GameObject torreta;
    public GameObject particleEfect;
    public GameObject generador;
    public float rangoAtack;

    public GameObject laser;//bala
    public float force;
    public float correT = 0f;
    public float maximoT;

    public EstadosEnemi estados;

	void Start () {
        maximoT = 2;
        force = 50f;
        torreta = GameObject.Find("torreta_01");
	}
	
	void Update () {
        if ((torreta.transform.position - transform.position).magnitude <= rangoAtack)
        {
            estados = EstadosEnemi.atack;
        }
        else
        {
            estados = EstadosEnemi.patrolling;
        }

        switch (estados)
        {
            case EstadosEnemi.patrolling:
                particleEfect.SetActive(false);
                maximoT = 2;
                break;
            case EstadosEnemi.atack:
                particleEfect.SetActive(true);
                DispararTorreta();
                break;
        }
    }

    public void DispararTorreta()
    {
        correT += Time.deltaTime;
        if (correT >= maximoT)
        {
            maximoT = 0.4f;
            correT = 0f;
            DisparaLaser();
        }
    }
    public void DisparaLaser()
    {
        GameObject proyectil = Instantiate(laser, transform.position, transform.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(proyectil.transform.forward* force, ForceMode.Impulse);
        proyectil.tag = "desBullet";
        Destroy(proyectil.gameObject, 3f);
    }
}
