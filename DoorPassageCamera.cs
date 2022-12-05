using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPassageCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera cameraLeft;
    [SerializeField] private Camera cameraRight;
    [SerializeField] private CameraController cam;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Mathf.Abs(Vector2.Distance(player.transform.position, cameraLeft.transform.position)) > Mathf.Abs(Vector2.Distance(player.transform.position, cameraRight.transform.position)))
            {
                cam.SetCamDetails(cameraRight.transform, cameraRight.orthographicSize);
            }
            else
            {
                cam.SetCamDetails(cameraLeft.transform, cameraRight.orthographicSize);
            }
        }
    }
}
