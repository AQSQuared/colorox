using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public GameObject levelCompletionWindow;
    public GameObject levelWindow;

    [Header("UI Level Fields")]
    public Text levelNumberText;
    public Text levelNameText;
    public Text levelInstructionText;
    public Text completionIndicatorText;
    public Text collectorAmountInEndText;
    public Text levelButtonText;
    public Button levelButton;
    public Sprite levelButtonSprite;

    [Header("UI Level Field Values")]
    public string levelNumber;
    public string levelName;
    [TextArea(5, 6)]
    public string levelInstructions;

    [HideInInspector]
    public int numberOfCollectors;
    [HideInInspector]
    public int numberOfFilledCollectors;

    public string sceneToLoad;
    public int levelNumberToUnlock = 1;

    Animator anim;
    int completionHash = Animator.StringToHash("LevelCompleted");

    private void Awake()
    {
        numberOfFilledCollectors = 0;

        levelNumberText.text = levelNumber;
        levelNameText.text = levelName;
        levelInstructionText.text = levelInstructions;

        anim = GetComponent<Animator>();
    }

    public IEnumerator CompleteLevel ()
    {
        if(numberOfFilledCollectors == numberOfCollectors)
        {
            if (PlayerPrefs.GetInt("Unlocked Level Number") < levelNumberToUnlock)
            {
                PlayerPrefs.SetInt("Unlocked Level Number", levelNumberToUnlock);
            }

            completionIndicatorText.text = "LEVEL COMPLETED";
            levelInstructionText.text = "";
            SetCollectorAmountText();
            SetLevelButton(true);
            levelCompletionWindow.SetActive(true);
            numberOfCollectors = 0;
            anim.SetTrigger(completionHash);

            yield return new WaitForSeconds(1f);

            levelWindow.SetActive(false);
        }
    }

    private void SetCollectorAmountText()
    {
        collectorAmountInEndText.text = numberOfFilledCollectors.ToString() + "/" + numberOfCollectors.ToString();
    }

    private void SetLevelButton (bool lwState)
    {
        if (lwState == true)
        {
            levelButtonText.text = "NEXT";
            levelButton.GetComponent<Image>().color = Color.magenta;
        }

        if (lwState == false)
        {
            levelButtonText.text = "RETRY LEVEL";
            levelButton.GetComponent<Image>().sprite = levelButtonSprite;
            levelButton.GetComponent<Image>().color = Color.red;
        }
    }

    public void RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        numberOfCollectors = 0;
    }

    public void LevelButton ()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void BackButton()
    {
        SceneManager.LoadScene("LevelZero");
    }

}
