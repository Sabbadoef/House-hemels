using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonToCredits : MonoBehaviour
{
    [SerializeField] AudioSource buttonClickSound;
    [SerializeField] TextMeshProUGUI creditText;
    [SerializeField] TextMeshProUGUI titleText;
    private int clickCount;

    private void Start()
    {
        clickCount = 0;
        titleText.text = "THE END";
    }

    public void ClickSound()
    {
        buttonClickSound.Play();
    }

    public void showCredits()
    {
        
        switch (clickCount)
        {
            case 6:
                Application.Quit();
                break;
            case 5:
                titleText.text = " ";
                creditText.text = " ";
                break;
            case 4:
                titleText.text = "AUTHOR";
                creditText.text = "ALBERICO SABBADINI: Game - level - narrative - sound - assets design, programming.";
                break;
            case 3:
                titleText.text = "AUTHOR";
                creditText.text = "HANNA STALENHOEF: Sound design and QA.";
                break;
            case 2:
                titleText.text = "AUTHOR";
                creditText.text = "FEDERICO DE MUSSO: Backgrounds, character and level design.";
                break;
            case 1:
                titleText.text = "MUSIC";
                creditText.text = "STUDIO NOIR: 'Dalton Trumbo' & 'Samuel Ornitz' \n KEVIN MACLEOD: 'Unholy Knight' ";
                break;
            case 0:
                titleText.text = "CREDITS";
                creditText.text = " ";
                break;
        }
        clickCount++;

    }
}
