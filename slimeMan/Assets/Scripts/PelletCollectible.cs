using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletCollectible : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D pellet)
   {
      Destroy(gameObject);
   }
}
