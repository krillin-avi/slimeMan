using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D pellet)
    {
        PlayerController controller = pellet.GetComponent<PlayerController >();
        //Destroy(gameObject);
    }

}
