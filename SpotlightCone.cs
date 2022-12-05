using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class SpotlightCone : MonoBehaviour
{
    [SerializeField] private Light2D spotLight;
    [SerializeField] private GameObject player;
    private Light2D lightCone;
    private float dx;
    private float dy;
    private float distance;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        lightCone = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2 (player.transform.position.x, player.transform.position.y - 0.7f);
        Vector2 aim = spotLight.transform.position;
        dx = aim.x - transform.localPosition.x;
        dy = aim.y - transform.localPosition.y;
        distance = Vector2.Distance( transform.localPosition, aim);
        
        if(dy > 0)
            angle = 180 * Mathf.Acos(dx / distance) / Mathf.PI;
        else
            angle = -180 * Mathf.Acos(dx / distance) / Mathf.PI;

        transform.localRotation = Quaternion.Euler(0,0,angle-90);

        lightCone.pointLightOuterRadius = distance;
        lightCone.pointLightInnerRadius = distance / 3;

        spotLight.pointLightOuterRadius = Mathf.Sin(lightCone.pointLightOuterAngle) * lightCone.pointLightInnerRadius;
        spotLight.pointLightInnerRadius = 3 * spotLight.pointLightOuterRadius / 4;


    }
}
