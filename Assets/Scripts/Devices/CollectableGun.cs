using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGun : MonoBehaviour
{
  [SerializeField] private string gunName;

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
    transform.Rotate(0.0f, 0.2f, 0.0f, Space.Self);
  }
}
