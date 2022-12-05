using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Death : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] AudioSource deathSound;
    //[SerializeField] GameObject specialPlatform;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.transform.CompareTag("Trap"))
        {
            GetComponent<Controller_V2>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            deathParticles.GetComponentInChildren<Light2D>().enabled = true;
            deathParticles.Play();
            deathSound.Play();
            anim.SetTrigger("Death");
        }

    }

    public void Respawn()
    {
        //if (specialPlatform != null)
            //specialPlatform.SetActive(true);

        anim.ResetTrigger("Death");
        anim.Play("Idle_Fede");
        GetComponent<Controller_V2>().enabled = true;
        deathParticles.Stop();
        deathParticles.GetComponentInChildren<Light2D>().enabled = false;

    }
}
