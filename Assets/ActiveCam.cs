    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCam : MonoBehaviour {


    public void Start()
    {
        Input.gyro.enabled = true;//activar el giroscopio

        StartCoroutine("WaitForCam");
    }

 

    public IEnumerator WaitForCam()
    {
        yield  return new WaitForSeconds(2);
        this.gameObject.GetComponent<CelCam>().enabled = true;
    }
}
