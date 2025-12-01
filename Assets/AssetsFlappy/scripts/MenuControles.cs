using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControles : MonoBehaviour
{

    public GameObject controles;
 
    public void OnStartClick()
    {
        SceneManager.LoadScene("FlappyCutscene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
