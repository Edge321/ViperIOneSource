using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenBehavior : MonoBehaviour
{
    public Button[] buttons;

    public GameObject titleScreenCanvas;
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject creditsCanvas;

    public AudioClip clip1;
    public AudioClip clip2;

    private int spaceScene = 1;

    private void Update()
    {
        if(titleScreenCanvas.activeSelf && Input.anyKeyDown)
        {
            titleScreenCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }
    public void PlayGame()
    {
        AudioBehavior.Instance.PlayAudio(clip1);
        SceneManager.LoadScene(spaceScene);
    }
    public void QuitGame()
    {
        AudioBehavior.Instance.PlayAudio(clip1);
        Application.Quit();
    }
    public void ShowSettings()
    {
        AudioBehavior.Instance.PlayAudio(clip1);
        DisableMenuButtons();
        settingsCanvas.SetActive(true);
    }
    public void ShowCredits()
    {
        AudioBehavior.Instance.PlayAudio(clip1);
        DisableMenuButtons();
        creditsCanvas.SetActive(true);
    }
    public void BackToMenu()
    {
        AudioBehavior.Instance.PlayAudio(clip2);
        EnableMenuButtons();
        creditsCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
    }
    private void DisableMenuButtons()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }
    private void EnableMenuButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
