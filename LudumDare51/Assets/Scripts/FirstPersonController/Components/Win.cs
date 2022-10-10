using System;
using System.Collections;
using UnityEngine;

public class Win : MonoBehaviour
{
    public string nextScene;

    MenuManagerScript menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Win")
        {
            other.GetComponent<AudioSource>().Play();
            ParticleSystem[] confettis = other.GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i < confettis.Length; i++){
                confettis[i].Play();
            }

            StartCoroutine(enjoyConfetti());
        }
    }

    private IEnumerator enjoyConfetti()
    {
        yield return new WaitForSeconds(1f);
        menuManager.loadScene(nextScene);
    }
}
