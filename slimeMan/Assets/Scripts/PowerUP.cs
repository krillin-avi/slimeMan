using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D pellet)
   {
      PlayerController controller = pellet.GetComponent<PlayerController >();
      Destroy(gameObject);
      controller.score = controller.score +50;
      controller.SetScoreText();
   }
}
