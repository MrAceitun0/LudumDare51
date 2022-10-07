using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
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
            GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(respawner.respawnPlayer(other.transform));
            StartCoroutine(deactivateRenderTemporaly());
        }
    }

    public IEnumerator deactivateRenderTemporaly()
    {
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<MeshRenderer>().enabled = true;
    }
}