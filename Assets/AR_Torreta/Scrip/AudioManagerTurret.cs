using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTurret : MonoBehaviour
{
    public AudioClip shot;
    public AudioSource adSrc;

	void Start ()
    {
        adSrc = GetComponent<AudioSource>();
	}
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shotsound();
        }	
	}
    public void Shotsound()
    {
        adSrc.PlayOneShot(shot);
    }
}
