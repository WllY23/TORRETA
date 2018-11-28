using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acamaraa : MonoBehaviour
{
    public GameObject planecam;
    public Transform camara;

    void Start ()
    {
        Input.gyro.enabled = true;
        WebCamTexture m_webcam = new WebCamTexture();
        planecam.GetComponent<MeshRenderer>().material.mainTexture = m_webcam;
        m_webcam.Play();
    }
	
	void Update ()
    {
        Quaternion rotationcamara = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        camara.localRotation = rotationcamara;
    }
}
