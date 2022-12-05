using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparatePlatform :  CreateApparatablePlatforms
{
    [SerializeField] private GameObject nextPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            nextPlatform.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //this.gameObject.SetActive(false);
        }
    }
}
