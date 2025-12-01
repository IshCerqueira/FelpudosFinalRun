using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{

    [SerializeField] PlayerMainSelectScript _playerScript;
    private string nowMovingTo = "";
    [SerializeField] bool race = false, run = false, flappy = false;
    [SerializeField] GameObject _thumbnail;

    private void Start()
    {
        if (race)
        {
            nowMovingTo = "TutorialRace";
        }
        else if (run)
        {
            nowMovingTo = "TutorialRun";
        }
        else if (flappy)
        {
            nowMovingTo = "TutorialFlappy";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _thumbnail.SetActive(true);
            _playerScript = other.GetComponent<PlayerMainSelectScript>();
            _playerScript.ToggleInteract();
            StartCoroutine(WaitForInteraction());

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _thumbnail.SetActive(false);
            _playerScript = other.GetComponent<PlayerMainSelectScript>();
            _playerScript.ToggleInteract();
        }

    }

    IEnumerator WaitForInteraction()
    {

        while (_playerScript.GetInteract())
        {
            if (_playerScript.GetInteractionTime())
            {
                SceneManager.LoadScene(nowMovingTo);
                yield return null;
            }
            else yield return null;
        }

        yield return null;
    }
}
