using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    private bool level1, level2, level3;
    public Color newColor = Color.green;
    [SerializeField] private SaveController _saveController;
    [SerializeField] private SpriteRenderer level1Spot, level2Spot, level3Spot;
    [SerializeField] private GameObject door;
    [SerializeField] private bool onSelection = false;

    public TextMeshProUGUI tutorialText;

    private void Start()
    {
        
        if (onSelection)
        {
            _saveController.LoadGame();

          
            if (level1)
            {
                SetTutorialText("Complete 3 provações no total para liberar o acesso até Uruca!");
                level1Spot.color = newColor;

            }

            if (level2)
            {
                SetTutorialText("Complete 3 provações no total para liberar o acesso até Uruca!");
                level2Spot.color = newColor;

            }

            if (level3)
            {
                SetTutorialText("Complete 3 provações no total para liberar o acesso até Uruca!");
                level3Spot.color = newColor;

            }

            if (level1 && level2 && level3)
            {
                SetTutorialText("Rápido, o caminho foi liberado, vá desafiar Uruca!");
                door.SetActive(false);
            }
        }
       
    }


    public void EndRunClick()
    {
        _saveController.LoadGame();
        SetLevel2(true);
        _saveController.SaveGame();
        SceneManager.LoadScene("MainSelectStage");
    }

    public void EndRaceClick()
    {
        _saveController.LoadGame();
        SetLevel1(true);
        _saveController.SaveGame();
        SceneManager.LoadScene("MainSelectStage");
    }

    public void EndFlappyClick()
    {
        _saveController.LoadGame();
        SetLevel3(true);
        _saveController.SaveGame();
        SceneManager.LoadScene("MainSelectStage");
    }

    public bool GetLevel1()
    {
        return level1;
    }

    public bool GetLevel2()
    {
        return level2;
    }
    public bool GetLevel3()
    {
        return level3;
    }

    public void SetLevel1( bool newValue)
    {
        level1 = newValue;
    }

    public void SetLevel2(bool newValue)
    {
        level2 = newValue;
    }

    public void SetLevel3(bool newValue)
    {
        level3 = newValue;
    }

    void SetTutorialText( string texto)
    {
        tutorialText.text = texto;

    }


}
