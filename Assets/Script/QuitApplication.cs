using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
