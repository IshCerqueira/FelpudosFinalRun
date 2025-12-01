using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuRedirectScript : MonoBehaviour
{
    [SerializeField] private SaveController _saveController;

    public void NewGame()
    {
        _saveController.DeleteGame();
        SceneManager.LoadScene("TutorialMainSelection");
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainSelectStage");
    }

    public void GoingToBoss()
    {
        SceneManager.LoadScene("FinalBossFight");
    }

    public void GoingToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("TutorialBoss");
        }
    }


}
