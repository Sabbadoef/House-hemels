using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPit : MonoBehaviour
{
    [SerializeField] GameObject pit;
    [SerializeField] GameObject motivationTextBox;
    private Animator anim;

    private void Start()
    {
        anim = pit.GetComponent<Animator>();
        motivationTextBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("STARTING PIT");
        if (col.gameObject.CompareTag("Player"))
        {
            motivationTextBox.SetActive(true);
            Time.timeScale = 0f;
            anim.SetTrigger("trigger_pit");
        }
    }
}
