using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
  [SerializeField] private Transform targetLook;

  private void Update()
  {
    TargetLook();
  }

  void TargetLook()
  {
    Ray ray = new Ray(transform.position, transform.forward * 2000);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 40);
    }
    else
    {
      targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * 200, Time.deltaTime);
    }
  }
}
