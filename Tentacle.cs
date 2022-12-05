using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    public Vector3[] segmentVels;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    private float leftRight;
    private float dx;
    private float dy;


    // Start is called before the first frame update
    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVels = new Vector3[length];
    }

    // Update is called once per frame
    void Update()
    {
        dx = leftRight > 0 ? 0.15f : -0.03f;
        dy = 0.05f * Mathf.Sin(Time.time * 2*Mathf.PI*2);

        segmentPoses[0] = targetDir.position + new Vector3(-dx, 0.6f + dy, 0);
        leftRight = Mathf.Sign(targetDir.localScale.x);

        for(int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + (new Vector3 ( -leftRight * 0.2f * (i-1),-1,0)) * targetDist, ref segmentVels[i], smoothSpeed + i / trailSpeed);
        }

        lineRend.SetPositions(segmentPoses);
        //-1 * Mathf.Sign(targetDir.localScale.x)
    }
}
