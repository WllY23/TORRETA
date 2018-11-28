using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movnave : MonoBehaviour
{
    public float speed;
    public float speed2;
    public int rnd;
    public int rnd2;

    void Start()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
        rnd = Random.Range(0, 2);
        rnd2 = Random.Range(0, 2);
    }

    void Update ()
    {
        movin();
        movin2();
    }

    public void movin()
    {
        switch (rnd)
        {
            case 0:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                break;
        }
    }

    public void movin2()
    {
        switch (rnd2)
        {
            case 0:
                transform.Rotate(Vector3.up, -speed2 * Time.deltaTime);
                break;
            case 1:
                transform.Rotate(Vector3.up, speed2 * Time.deltaTime);
                break;
        }
    }
}