using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayedAction());
    }


    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Main");

    } 

}
