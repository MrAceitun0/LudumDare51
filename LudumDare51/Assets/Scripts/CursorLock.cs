using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public Texture2D texture;
    public bool isCursorVisible;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);

        Cursor.visible = isCursorVisible;

        if (isCursorVisible) { 
            Cursor.lockState = CursorLockMode.None;
        } else{
            Cursor.lockState = CursorLockMode.Locked;
        }
    }   
}
