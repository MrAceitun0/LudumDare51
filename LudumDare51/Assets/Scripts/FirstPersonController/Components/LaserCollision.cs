using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip laserDeath;
    Respawner respawner;

    private void Start()
    {
        respawner = FindObjectOfType<Respawner>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            audioSource.PlayOneShot(laserDeath);
            respawner.setIsDead(true);
            StartCoroutine(respawner.respawnPlayer(transform));
        }
    }
}
