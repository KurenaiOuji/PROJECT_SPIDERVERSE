using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static Action OnPauseGame;

    public Canvas pauseMenuUI;
    public AudioSource openPauseSound;
    public AudioSource closePauseSound;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }


    void PauseGame()
    {
        isPaused = !isPaused;
        pauseMenuUI.enabled = isPaused ? true : false;
        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused ? true : false;

        if (isPaused) openPauseSound.Play();
        else closePauseSound.Play();

        OnPauseGame?.Invoke();
    }
}
