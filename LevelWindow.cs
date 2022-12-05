using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{ /*

    [SerializeField] private Text clueCount;
    private MemorySystem memorySystem;

    private void Awake()
    {
        memorySystem = new();

        int cluesToNextMemory = memorySystem.GetCluesToNextMemory();

        clueCount.text = "Hints:" + 0 + "/" + cluesToNextMemory;
    }

    private void UpdateCluesMemories(int clue, int clueToNext)
    {
        clueCount.text = "Hints:" + clue + "/" + clueToNext;
    }

    public void SetMemorySystem(MemorySystem memorySystem)
    {
        this.memorySystem = memorySystem;
        UpdateCluesMemories(memorySystem.GetClues(), memorySystem.GetCluesToNextMemory());

        memorySystem.OnCluesAdded += MemorySystem_OnCluesAdded;

    }

    private void MemorySystem_OnCluesAdded(object sender, EventArgs e)
    {
        UpdateCluesMemories(memorySystem.GetClues(), memorySystem.GetCluesToNextMemory());
    } */
}
