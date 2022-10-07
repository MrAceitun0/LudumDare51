using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Transform initialTransform;
    Respawner respawner;

    private void Start()
    {
        respawner = FindObjectOfType<Respawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<ParticleSystem>().Play();
            respawner.setIsDead(true);
            StartCoroutine(respawner.respawnPlayer(other.transform));
        }
    }
}