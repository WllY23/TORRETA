using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool Pausas = false;

    public GameObject PauseMenuUI;

    void Start()
    {
        Pausas = false;
        Resume();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Men()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void EXITGAME()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Pausas)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Pausas = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Pausas = true;
    }
}
