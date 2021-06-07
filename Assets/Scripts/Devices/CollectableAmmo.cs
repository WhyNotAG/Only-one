using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CollectableAmmo : MonoBehaviour
{
    [SerializeField] private string ammoName;
    [SerializeField] private float verticalSpeed = 10.0f;
    private Vector3 startPosition;
    private void OnTriggerEnter(Collider other)
    {
        
        if (Managers.Inventory1.GetItemCount(ammoName) >= 100)
        {
            return;
        }
        
        Managers.Inventory1.AddAmmo(ammoName);
        Debug.Log("Ammo " + ammoName + " " + Managers.Inventory1.GetItemCount(ammoName) + "/100");
        Destroy(this.gameObject);
    }


    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
       transform.Rotate(0.0f, 0.1f, 0.0f, Space.Self);
       transform.position = new Vector3(transform.position.x, 
            startPosition.y + 0.5f * Mathf.Sin(Time.time * verticalSpeed), transform.position.z);
    }
}
