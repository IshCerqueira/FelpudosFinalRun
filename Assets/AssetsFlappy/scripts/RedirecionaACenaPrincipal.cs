using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirecionaACenaPrincipal : MonoBehaviour
{
 

    public void OnStartClick()
    {
        SceneManager.LoadScene("MainSceneFlappy");
    }

    public void OnStartClick2()
    {
        SceneManager.LoadScene("MainSelectStage");
    }

    public void OnStartClick3()
    {
        SceneManager.LoadScene("FlappyWin");
    }

    public void OnStartClick4()
    {
        SceneManager.LoadScene("FlappyCutscene");
    }

    public void OnStartClick5()
    {
        SceneManager.LoadScene("FinalBossFight");
    }

}
