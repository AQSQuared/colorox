using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public int requiredUnlockLevelNumber;
    public string levelNameToLoad;
    public string _levelName;

    private Text levelNameText;
    private Image lockImageGraphic;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Unlocked Level Number", 1);

        levelNameText = transform.GetChild(0).GetComponent<Text>();
        lockImageGraphic = transform.GetChild(1).GetComponent<Image>();

        levelNameText.text = _levelName;

        if (requiredUnlockLevelNumber <= PlayerPrefs.GetInt("Unlocked Level Number"))
        {
            lockImageGraphic.gameObject.SetActive(false);
            this.GetComponent<Button>().interactable = true;

            GetComponentInParent<LevelZeroManager>().AddCompletedLevelToList(this);
        }
    }

    public void LoadLevelButton ()
    {
        SceneManager.LoadScene(levelNameToLoad);
    }
}
