using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{ 

    private Transform currentCheckpoint;
    private Death death;

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        //death.Respawn();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            Debug.Log("Collided with checkpoint!");
        }

    }


}
