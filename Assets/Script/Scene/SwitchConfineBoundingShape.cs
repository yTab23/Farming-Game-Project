using UnityEngine;
using Cinemachine;

public class SwitchConfineBoundingShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    private void SwitchBoundingShape()
    {
        //Get the polygon collider on the 'boundsconfiner' gameobject which is used by Cinemachine to  prevent the camera going beyond the screen edges.
        PolygonCollider2D polygonCollider2D = GameObject.FindGameObjectWithTag(Tags.BoundsConfiner).  GetComponent<PolygonCollider2D>();

        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();

        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        //Since the confiner bounds have changed need to call this clear to cache.

        cinemachineConfiner.InvalidatePathCache(); 
    }
}
