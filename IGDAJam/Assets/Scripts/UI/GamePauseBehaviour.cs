using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//reference:
//https://youtu.be/JivuXdrIHK0

public class GamePauseBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;    
    }

    public void Toggle(InputAction.CallbackContext context)
    {
        if (GameIsPaused && context.started)
            Resume();

        else if (!GameIsPaused && context.started)
            Pause();
    }

    public void Pause()
    {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
    }
}
