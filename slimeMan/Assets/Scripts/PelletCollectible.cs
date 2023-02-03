using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PelletCollectible : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D pellet)
   {
      PlayerController controller = pellet.GetComponent<PlayerController >();
      Destroy(gameObject);
      controller.score = controller.score +50;
      controller.SetScoreText();
   }
}
