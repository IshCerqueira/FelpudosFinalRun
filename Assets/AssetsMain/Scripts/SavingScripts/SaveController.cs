using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{

    private string saveLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveGame()
    {
       
        SaveData saveData = new SaveData
        {
            level1 = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().GetLevel1(),
            level2 = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().GetLevel2(),
            level3 = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().GetLevel3(),
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
 
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().SetLevel1(saveData.level1);

            GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().SetLevel2(saveData.level2);

            GameObject.FindGameObjectWithTag("Controller").GetComponent<GameControllerScript>().SetLevel3(saveData.level3);
        }
        else
        {
            SaveGame();
        }
    }

    public void DeleteGame()
    {
        if (File.Exists(saveLocation))
        {
            File.Delete(saveLocation);
        }

        else
        {

        }
    }
}