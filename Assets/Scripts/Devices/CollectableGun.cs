using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGun : MonoBehaviour
{
  [SerializeField] private string gunName;
  private const float SPEED = 100.0f;

  private void OnTriggerEnter(Collider other)
  {
    if (Managers.Inventory1.ContainsGun(gunName))
    {
      return;
    }
    Managers.Inventory1.AddGuns(gunName);
    Destroy(this.gameObject);
  }

  private void Update()
  {
    transform.Rotate(Vector3.up * Time.deltaTime * SPEED, Space.Self);
  }
}
