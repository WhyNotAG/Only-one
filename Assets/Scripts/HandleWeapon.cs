using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandleWeapon : MonoBehaviour
{

    [SerializeField] public ParticleSystem muzzleFlash;
    [SerializeField] private string _name;
    [SerializeField] private GunTypes _gunType;

    public string Name => _name;
    public GunTypes GunType => _gunType;
    


    public enum GunTypes
    {
        AUTO,
        NOTAUTO,
    }
    
}
