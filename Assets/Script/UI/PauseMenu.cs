using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("AllMenus Settings")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject hud;

    /* SE VAN A DESCOMENTAR CUANDO ESTEN ARMADOS */
    //[SerializeField] private AudioSource musicLevel = null;
    //[SerializeField] private float lowerVolume = 1f;

    [Header("PauseMenu Settings")]
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    //[SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitButton;

    //Extras
    private bool isActive;

    void Start()
    {
        InputController.instance.OnPause += CheckIsActive;
        AssingListeners();
        ExitMenu();
    }

    #region Private
    private void AssingListeners()
    {
        resumeButton.onClick.AddListener(OnResumeHandler);
        restartButton.onClick.AddListener(OnRestartHandler);
        //mainMenuButton.onClick.AddListener(OnMenuHandler);
        quitButton.onClick.AddListener(OnQuitHandler);
    }
    private void CheckIsActive()
    {
        if (!isActive)
        {
            Pause();
        }
        else
        {
            ExitMenu();
        }
    }
    private void OnResumeHandler()
    {
        //AudioManager.instance.PlaySound(SoundClips.MouseClick);
        ExitMenu();
    }

    private void OnRestartHandler()
    {
        GameManager.instance.Pause(false);
        //AudioManager.instance.PlaySound(SoundClips.MouseClick);
        SceneManager.LoadScene(GameManager.instance.CurrentLevel);
    }

    private void OnMenuHandler()
    {
        GameManager.instance.Pause(false);
        //AudioManager.instance.PlaySound(SoundClips.MouseClick);
        //SceneManager.LoadScene("MainMenu");
    }

    private void OnQuitHandler()
    {
        //AudioManager.instance.PlaySound(SoundClips.MouseClick);
        Application.Quit();
        Debug.Log("Se cierra el juego");
    }
    #endregion

    #region Public
    public void Pause()
    {
        GameManager.instance.Pause(true);
        isActive = true;
        hud.SetActive(false);
        pauseMenu.SetActive(true);
        //musicLevel.volume -= lowerVolume;
        //timerObject.SetActive(false);
    }

    public void ExitMenu()
    {
        GameManager.instance.Pause(false);
        isActive = false;
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        //musicLevel.volume += lowerVolume;
        //timerObject.SetActive(true);
    }
    #endregion
}
