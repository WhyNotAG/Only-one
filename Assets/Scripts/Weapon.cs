using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPoint;
    public Transform publicLook;

    public GameObject cameraMain;
    public GameObject decal;    
    
    void Update()
    {
        Vector3 origin = shotPoint.position;
        Vector3 dir = publicLook.position;

        RaycastHit hit;
        
        Debug.DrawLine(origin, dir, Color.red, 0.0f, true);
        Debug.DrawLine(cameraMain.transform.position, dir, Color.red);
    }
}
