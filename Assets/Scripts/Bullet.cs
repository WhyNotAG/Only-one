using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private int _speed;
   [SerializeField] private GameObject decal; 
   private Vector3 lastFramePosition;
   private void Start()
   {
      lastFramePosition = transform.position;
   }

   private void Update()
   {
      transform.Translate(Vector3.forward * _speed * Time.deltaTime);

      RaycastHit hit;

      Debug.DrawLine(lastFramePosition, transform.position);

      if (Physics.Linecast(lastFramePosition, transform.position, out hit))
      {
         GameObject bulletHit = Instantiate(decal);
         bulletHit.transform.position = hit.point + hit.normal * 0.05f;
         bulletHit.transform.rotation = Quaternion.LookRotation(-hit.normal);
         Destroy(bulletHit, 10.0f);
         Destroy(this.gameObject);
      }

      lastFramePosition = transform.position;
   }
}
