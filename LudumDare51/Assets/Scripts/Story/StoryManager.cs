using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public string nextScene;

    CharByCharRenderScript charByCharRenderScript;
    MenuManagerScript menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManagerScript>();
        charByCharRenderScript = FindObjectOfType<CharByCharRenderScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            if (charByCharRenderScript.hasFinished)
            {
                menuManager.loadScene(nextScene);
            } else
            {
                charByCharRenderScript.showFullText();
            }
        }
    }
}
