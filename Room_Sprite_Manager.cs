using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Sprite_Manager : MonoBehaviour
{
    [SerializeField] private GameObject roomThreats;
    private GameObject[] rooms;

    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");

        for(int i = 0; i < rooms.Length; i++)
        {
            rooms[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roomThreats.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            roomThreats.SetActive(false);
        }
    }
}
