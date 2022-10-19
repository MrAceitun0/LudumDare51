using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public AudioSource backgroundMusic;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        backgroundMusic.pitch = 0.5f;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        backgroundMusic.pitch = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
