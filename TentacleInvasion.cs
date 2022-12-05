using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleInvasion : MonoBehaviour
{
    [SerializeField] GameObject tentacle;
    private Animator anim;

    private void Start()
    {
        anim = tentacle.GetComponent<Animator>();
        tentacle.tag = "Untagged";
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            tentacle.tag = "Trap";
            anim.SetBool("whileInvaded", true);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            tentacle.tag = "Untagged";
            anim.SetBool("whileInvaded", false);
        }

    }
}
