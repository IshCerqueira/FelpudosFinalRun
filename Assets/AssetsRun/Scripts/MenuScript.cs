using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("RunCutscene");
    }

    public void OnStartClick2()
    {
        SceneManager.LoadScene("RunMain");
    }
   
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}