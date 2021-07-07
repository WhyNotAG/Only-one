using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private  Transform targetLook;

    [SerializeField] private  GameObject cameraMain;
    [SerializeField] private GameObject bullet;

    public ParticleSystem muzzleFlash;

    [SerializeField] private HandleWeapon weaponactiveGun;


    public void SetWeaponActiveGuns(HandleWeapon weaponactiveGun)
    {
        this.weaponactiveGun = weaponactiveGun;
    }

    public HandleWeapon GetWeaponActiveGun()
    {
        return weaponactiveGun;
    }

    void Update()
    {
        shotPoint.LookAt(targetLook);
        Vector3 origin = shotPoint.position;
        Vector3 dir = targetLook.position;
        
        Debug.DrawLine(origin, dir, Color.red, 0.0f, true);
        Debug.DrawLine(cameraMain.transform.position, dir, Color.red);
    }

    public void Shoot()
    {
        Instantiate(bullet, shotPoint.position + shotPoint.forward, shotPoint.rotation);
        weaponactiveGun.MuzzleFlash.Play();
    }
}
