using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMessageUI : MonoBehaviour
{

    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private TextMeshProUGUI deathText;
    [SerializeField] private TextAsset premadeTextAsset;

    [SerializeField] AudioSource buttonClickSound;

    // Start is called before the first frame update
    void Start()
    {
        deathText.text = premadeTextAsset.text;
        deathPanel.SetActive(false);
    }

    // Update is called once per frame
    public void DeathMessage()
    {
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }

    public void RestartFromCheckpoint()
    {
        Time.timeScale = 1f;
        deathPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ClickSound()
    {
        buttonClickSound.Play();
    }
}
