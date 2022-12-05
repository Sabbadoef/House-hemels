using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseResume : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] AudioSource buttonClickSound;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ClickSound()
    {
        buttonClickSound.Play();
    }
}
