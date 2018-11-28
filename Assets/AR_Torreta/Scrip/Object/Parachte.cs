using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachte : MonoBehaviour {
    float a;
    public bool sw;
    float timer = 0;
    float timer_destroy = 0;
    float speed;
    void Start () {
        a = 10;
        sw = false;
        timer = 1;
        timer_destroy = 0;
        speed = 5;
	}
	void Update () {
        timer_destroy += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >=2)
        {
            if(sw)
            {
                sw = false;
            }
            else
            {
                sw = true;
            }
            timer = 0;
        }
        if (sw)
        {
            transform.Rotate(0, 0, a * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -a * Time.deltaTime);
        }
        if(timer_destroy > 10f)
        {
            Destroy(this.gameObject);
        }
        transform.position -= (transform.up * speed*Time.deltaTime );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.tag == "Bala")
        {
            Destroy(this.gameObject);
        }
    }

}