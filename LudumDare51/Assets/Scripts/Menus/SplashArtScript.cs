using System.Collections;
using UnityEngine;

public class SplashArtScript : MonoBehaviour
{
    public float splashTime;
    MenuManagerScript menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManagerScript>();
        StartCoroutine("goToMenu");
    }

    private IEnumerator goToMenu()
    {
        yield return new WaitForSeconds(splashTime);
        menuManager.loadScene("MainMenuScene");
    }
}
