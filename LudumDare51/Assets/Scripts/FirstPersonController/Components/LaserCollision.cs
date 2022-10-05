using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{

    Respawner respawner;

    private void Start()
    {
        respawner = FindObjectOfType<Respawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            respawner.setIsDead(true);
            StartCoroutine(respawner.respawnPlayer(transform));
        }
    }
}
