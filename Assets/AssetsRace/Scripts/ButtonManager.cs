using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnclickMenu()
    {
        SceneManager.LoadScene("MainSelectStage");
    }

    public void OnClickMainScene()
    {
        SceneManager.LoadScene("MainSceneRace");
    }
    public void OnClickCutScene()
    {
        SceneManager.LoadScene("RaceCutscene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
