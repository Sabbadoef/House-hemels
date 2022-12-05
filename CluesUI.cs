using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CluesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clueCount;
    private MemorySystem memorySystem;


    void OnEnable()
    {
        MemorySystem.OnCluesAdded += UpdateClues;
    }


    void OnDisable()
    {
        MemorySystem.OnCluesAdded -= UpdateClues;
    }

    private void UpdateClues()
    {
        int clue = memorySystem.GetClues();
        Debug.Log("Clues: " + clue);
        //clueCount.text = "Hints: " + clue + "/" + clueToNext;
    }

    public void SetMemorySystem(MemorySystem memSym)
    {
        this.memorySystem = memSym;
    }


}
