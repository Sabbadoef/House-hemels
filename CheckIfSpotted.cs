using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfSpotted : MonoBehaviour
{
    [SerializeField] private LayerMask spotlightLayerMask;

    void OnTriggerEnter2D(Collider2D col)
    {
        

        if (col.gameObject.layer == gameObject.layer)
        {
            Destroy(gameObject);
        }
            
    }

}
