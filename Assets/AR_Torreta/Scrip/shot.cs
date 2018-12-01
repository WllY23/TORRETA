using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shot : MonoBehaviour {

    public bool reheated;
    public bool active_shield;

    public float hot; 
    public AudioClip shot_;
    public AudioSource adSrc;

    public GameObject laser;
    public GameObject shield_object;


    GameObject LaserClone;
    public float force;

    public Image image_hot;
    public Image image_shield;
    public Image image_healt;

    public float max_imagen;
    public float max_shield;
    public float max_healt;
    public float shield_state;
    public float healt_state;

    
    // Use this for initialization
    void Start () {
        shield_state = 30;
        healt_state = 30;
        hot = 0;
        reheated = false;
        force = 50f;
        adSrc = GetComponent<AudioSource>();
        max_shield = 30f;
        max_healt = 30;
        active_shield = false;

        image_healt.fillAmount = (healt_state) / max_healt;
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
        if (active_shield)
        {
            shield_state -= (Time.deltaTime * 2f);
            image_shield.fillAmount = (shield_state) / max_shield;
            if (shield_state <= 0)
            {
                shield_object.SetActive(false);
                active_shield = false;
            }
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
