using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotlightController : MonoBehaviour
{
    
    [SerializeField] public float lightRange;
    [SerializeField] private CluesUI cluesUI;
    [SerializeField] AudioSource clueSound;

    private bool lightOn;
    private float distanceMousePlayer;
    private Vector2 mouse;
    private Vector2 target;
    private Vector2 player;
    private MemorySystem memorySystem;
    private CircleCollider2D spotCollider;
    private Light2D spotLight;

    // Start is called before the first frame update
    private void Awake()
    {
        lightOn = false;
        memorySystem = new();
        cluesUI.SetMemorySystem(memorySystem);
        spotCollider = GetComponent<CircleCollider2D>();
        spotLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Store player's coordinates
        player = new Vector2(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
        lightOn = false;

        //Toggle search light on/off + search light controls
        if (Input.GetMouseButton(1))
            lightOn = true;

        if (lightOn)
        {
            spotLight.enabled = true;
            spotCollider.enabled = true;
            spotCollider.radius = spotLight.pointLightInnerRadius;

            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            distanceMousePlayer = Vector2.Distance(player, mouse);

            if (distanceMousePlayer > lightRange)
            {
                float dx = mouse.x - player.x;
                float dy = mouse.y - player.y;

                target = player + new Vector2(lightRange * (dx / distanceMousePlayer), lightRange * (dy / distanceMousePlayer));
            }
            else
            {
                target = mouse;
            }

            transform.localPosition = new Vector2(target.x, target.y);
        }
        else
        { 
            transform.localPosition = new Vector2(player.x + (GameObject.Find("Player").transform.localScale.x * lightRange), player.y - 0.3f);
            spotLight.enabled = false;
            spotCollider.enabled = false;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {


        if (col.gameObject.layer == gameObject.layer)
        {
            memorySystem.AddClue();
            clueSound.Play();
        }

    }
}
