using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySystem
{
    public delegate void ClueFind();
    public static event ClueFind OnCluesAdded;

    public delegate void MemoryUnlocked();
    public static event MemoryUnlocked OnMemoryAdded;

    private int memories;
    private int clues;
    private int[] cluesToNextMemory;

    public MemorySystem()
    {
        memories = 0;
        clues = 0;
        cluesToNextMemory = new int[] {3, 4, 4, 4, 3};

    }

    public void AddClue()
    {  
        clues++;
        if (clues == cluesToNextMemory[memories])
        {
            LevelUp();

            if (OnMemoryAdded != null)
                OnMemoryAdded();
        }
        
        if (OnCluesAdded != null)
            OnCluesAdded();  
    }

    private void LevelUp()
    {
        memories++;
        clues = 0;
    }
    public int GetMemories()
    {
        return memories;
    }

    public int GetClues()
    {
        return clues;
    }

    public int[] GetCluesToNextMemory()
    {
        return cluesToNextMemory;
    }

}
