using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelZeroManager : MonoBehaviour {

    public Image appretiateWindow;

    private List<Level> levels = new List<Level>();

    private void Update()
    {
        foreach(Level level in levels)
        {
            if (level.requiredUnlockLevelNumber <= PlayerPrefs.GetInt("Unlocked Level Number") - 1)
            {
                level.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }

    public void AddCompletedLevelToList (Level level)
    {
        levels.Add(level);
    }

    public void Apperetiate()
    {
        appretiateWindow.transform.GetChild(0).GetComponent<Text>().text = "THANKS FOR YOUR SUPPORT";
        appretiateWindow.transform.GetChild(1).GetComponent<Text>().text = "THIS HELPS ME CREATING MORE GAMES AND FURTHER UPDATES FOR THIS GAME.";
        appretiateWindow.gameObject.SetActive(true);
    }

    public void CloseAppretiationWindow()
    {
        appretiateWindow.gameObject.SetActive(false);
    }
    
    public void OnPurchaseFailed()
    {
        appretiateWindow.transform.GetChild(0).GetComponent<Text>().text = "PURCHASE FAILED";
        appretiateWindow.transform.GetChild(1).GetComponent<Text>().text = "";
        appretiateWindow.gameObject.SetActive(true);
    }

    public void LevelCreator()
    {
        SceneManager.LoadScene("LevelCreator");
    }

}
