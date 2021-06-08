using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private  Transform targetLook;

    [SerializeField] private  GameObject cameraMain;
    [SerializeField] private GameObject bullet;

    [SerializeField] private ParticleSystem muzzleFlash;
    void Update()
    {
        shotPoint.LookAt(targetLook);
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;

        RaycastHit hit;
        Debug.DrawLine(origin, dir, Color.red, 0.0f, true);
        Debug.DrawLine(cameraMain.transform.position, dir, Color.red);

        // if (Physics.Linecast(origin, dir, out hit))
        // {
        //     decal.SetActive(true);
        //     decal.transform.position = hit.point + hit.normal * 0.05f;
        //     decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
        // }
    }

    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        muzzleFlash.Play();
    }
}
