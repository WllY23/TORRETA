using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shot : MonoBehaviour {

    public bool reheated;
    public float hot; 
    public AudioClip shot_;
    public AudioSource adSrc;
    public GameObject laser;
    GameObject LaserClone;
    public float force;

    public Image image_hot;
    public float max_imagen, min_imagen;
    
    // Use this for initialization
    void Start () {
        hot = 0;
        reheated = false;
        force = 50f;
        adSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!reheated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shotsound();
                disparaLaser();
            }
        }   
        if(hot >0)
        {
            hot -= (Time.deltaTime * 2f);
            image_hot.fillAmount = (hot) / max_imagen;
        }
        else
        {
            reheated = false;
        }
    }

    public void disparaLaser()
    {
        LaserClone = Instantiate(laser, transform.position, transform.rotation);
        LaserClone.GetComponent<Rigidbody>().AddForce(LaserClone.transform.forward * force, ForceMode.Impulse);
        LaserClone.tag = "towBullet";
        Destroy(LaserClone.gameObject, 3f);
        if(hot < max_imagen)
        {
            hot += 2;
        }
        else
        {
            reheated = true;
        }
    }
    public void Shotsound()
    {
        adSrc.PlayOneShot(shot_);
    }

}
