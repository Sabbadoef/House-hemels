using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    

    [SerializeField] private GameObject player;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private Camera cameraStart;
    public float transitionSpeed;
    private float sizeVelocity = 0;
    private Vector3 camDetails;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        cameraMain.transform.position = cameraStart.transform.position;
        cameraMain.orthographicSize = 7f;
        camDetails = new Vector3(cameraStart.transform.position.x, cameraStart.transform.position.y, 7f);
    }


    // Update is called once per frame
    void Update()
    {
        cameraMain.transform.position = Vector3.SmoothDamp(cameraMain.transform.position, new Vector3(camDetails[0], camDetails[1], -10), ref velocity, transitionSpeed);
        cameraMain.orthographicSize = Mathf.SmoothDamp(cameraMain.orthographicSize, camDetails[2], ref sizeVelocity, transitionSpeed);
    }

    public void SetCamDetails(Transform pos, float size)
    {
        camDetails = new Vector3(pos.position.x, pos.position.y, size);

    }
}
