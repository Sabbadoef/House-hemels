using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FugueTrigger : MonoBehaviour
{
    [Header("Level objects: ")]
    [SerializeField] GameObject fugue;
    [SerializeField] GameObject stairs;
    [SerializeField] GameObject boss;

    [Header("UI objects")]
    [SerializeField] private GameObject loreUI;
    [SerializeField] private GameObject lorePanel;
    [SerializeField] private TextMeshProUGUI loreText;
    [SerializeField] private TextAsset Basement;
    [SerializeField] private AudioSource rustlingSound;

    private Animator anim;

    private void Awake()
    {
        lorePanel.SetActive(false);
        anim = boss.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("COLLISION!");
            Time.timeScale = 0f;
            rustlingSound.Play();
            lorePanel.SetActive(true);
            loreText.text = Basement.text;

            fugue.SetActive(true);
            stairs.SetActive(false);
            anim.SetTrigger("Hunt_Trigger");
        }
        
    }
}
