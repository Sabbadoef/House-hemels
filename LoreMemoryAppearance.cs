using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoreMemoryAppearance : MonoBehaviour
{
    public LevelLoad levelLoader;
    [SerializeField] private FearBar fearBar;
    [SerializeField] private GameObject Lights;
    [SerializeField] private GameObject loreUI;
    [SerializeField] private GameObject lorePanel;
    [SerializeField] private TextMeshProUGUI loreText;
    [SerializeField] private TextAsset Intro;
    [SerializeField] private TextAsset Entrance;
    [SerializeField] private TextAsset Piano;
    [SerializeField] private TextAsset Attic;
    [SerializeField] private TextAsset Library;
    [SerializeField] private TextAsset Dining;
    [SerializeField] private TextAsset Basement;

    [SerializeField] AudioSource newMemorySound;

    private GameObject[][] threats;
    private int memories;
    private int madnessThreat;

    void Awake()
    {
        Time.timeScale = 1f;
        lorePanel.SetActive(true);
        loreText.text = Intro.text;

        Lights.SetActive(false);

        memories = 0;
        madnessThreat = 1;

        threats = new GameObject[5][];

        for(int i = 0; i < 3; i++)
        {
            threats[i] = GameObject.FindGameObjectsWithTag("Threats_" + (i + 1));
        }

 
        for (int i = 0; i<3; i++)
        {
            for (int j = 0; j < threats[i].Length; j++)
            {
                threats[i][j].SetActive(false);
            }

        }
    }

    

    // Update is called once per frame
    void Update()
    {
        //fearBar.SetFear(fearBar.GetFear() + madnessThreat * 0.1f * Time.deltaTime);
    }

    void OnEnable()
    {
        MemorySystem.OnMemoryAdded += DisplayMemory;
    }


    void OnDisable()
    {
        MemorySystem.OnMemoryAdded -= DisplayMemory;
    }

    private void DisplayMemory()
    {
        Time.timeScale = 0f;
        lorePanel.SetActive(true);

        if (madnessThreat == 1)
            Lights.SetActive(true);
         else if (threats[madnessThreat - 2] != null)
        {
            for (int i = 0; i < threats[madnessThreat - 2].Length; i++)
            {
                threats[madnessThreat - 2][i].SetActive(true);
            }
                
        }
            

        memories++;
        madnessThreat++;
        //fearBar.SetFear(fearBar.GetFear() - 20);

        Debug.Log("Memories count: " + memories);

        newMemorySound.Play();

        switch (memories)
        {
            case 6:
                loreText.text = Basement.text;
                break;

            case 5:
                loreText.text = Library.text;
                break;

            case 4:
                loreText.text = Attic.text;
                break;

            case 3:
                loreText.text = Dining.text;
                break;

            case 2:
                loreText.text = Piano.text;
                break;

            case 1:
                loreText.text = Entrance.text;
                break;
        }

    }
    public void ButtonClose()
    {
        if(memories > 4)
        {
           SceneManager.LoadScene("Basement");
        }
        Time.timeScale = 1f;
        lorePanel.SetActive(false);
    }
}
