using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashArtScript : MonoBehaviour
{

    MenuManagerScript menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManagerScript>();
        StartCoroutine("goToMenu");
    }

    private IEnumerator goToMenu()
    {
        yield return new WaitForSeconds(4f);
        menuManager.loadScene("MainMenuScene");
    }
}
