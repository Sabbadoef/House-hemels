using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateApparatablePlatforms : MonoBehaviour
{
    public float platformNumber;
    // Start is called before the first frame update
    void Start()
    {
        platformNumber = 1;
    }

    public void IncreasePlatformNumber()
    {
        platformNumber++;
    }

}
