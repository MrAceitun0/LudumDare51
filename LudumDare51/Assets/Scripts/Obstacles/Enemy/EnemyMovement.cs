using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Respawner respawner;

    public Transform player;
    protected NavMeshAgent enemyMesh;

    Vector3 initialPosition;
    PlayerDetector playerDetector;

    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        initialPosition = transform.position;
        respawner = FindObjectOfType<Respawner>();
        playerDetector = GetComponentInChildren<PlayerDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (respawner.getIsDead())
        {
            transform.position = initialPosition;
        }
        if ( !playerDetector.getIsPlayerDetected())
        {
            enemyMesh.SetDestination(initialPosition);
        } else
        {
            enemyMesh.SetDestination(player.position);
        }
    }

    public IEnumerator respawnEnemy()
    {
        yield return new WaitForSeconds(1f);
        transform.position = initialPosition;
    }
}