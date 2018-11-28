using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelCam : MonoBehaviour
{
    
    private bool CamAviable;
    private WebCamTexture backcam;
    private Texture defaultBackground;
    [Header(".::RawImage del background del cambas::.")]
    public RawImage background;
    public AspectRatioFitter fit;

	void Start ()
    {
        Input.gyro.enabled = true; //Habilitar el giroscopio
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            print("Camara No detectada");
            CamAviable = false;
            return;
        }
        for (int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backcam = new WebCamTexture(devices[i].name,Screen.width,Screen.height);
            }
        }
        if (backcam == null)
        {
            print("incapaz de encontrar camara trasera (backcamera)");
            return;
        }
        backcam.Play();
        background.texture = backcam;

        CamAviable = true;
	}

    //void FixedUpdate()
    //{
    //    Debug.Log("Rotacion: " + Input.gyro.attitude); //Rotación del giroscopio
    //    Debug.Log("Aceleracion: " + Input.gyro.userAcceleration); //Aceleración del dispositivo
    //    Debug.Log("Gravedad: " + Input.gyro.gravity); //Gravedad  del dispositivo
    //}

    void Update ()
    {
        if (!CamAviable)
            return;
        float ratio = (float)backcam.width / (float)backcam.height;
        fit.aspectRatio = ratio;

        float scaleY = backcam.videoVerticallyMirrored ? -1f: 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backcam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0,0,orient);
		
	}
}
