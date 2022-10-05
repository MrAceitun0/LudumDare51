using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    [SerializeField]
    public float deathLimitY = -5f;

    Respawner respawner;

    private void Start()
    {
        respawner = FindObjectOfType<Respawner>();
    }

    void Update()
    {
        if(transform.position.y < deathLimitY && !respawner.getIsDead())
        {
            respawner.setIsDead(true);
            StartCoroutine(respawner.respawnPlayer(transform));
        }
    }
}
