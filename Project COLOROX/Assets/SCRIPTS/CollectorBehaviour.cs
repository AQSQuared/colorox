using UnityEngine;
using UnityEngine.UI;

public class CollectorBehaviour : MonoBehaviour {

    public float amountOfEnergyRequired;
    public string collectorColorId;

    //private Image collectorImage;
    //private AudioController audioController;
    private Image practicalAmountImageGraphic;
    private Text amountCapacityText;
    private LevelManager levelManager;

    [HideInInspector]
    public float amountOfEnergyCurrentlyStored;

    private void Awake()
    {
        //collectorImage = GetComponent<Image>();
        //audioController = GetComponent<AudioController>();
        practicalAmountImageGraphic = transform.GetChild(0).GetComponent<Image>();
        amountCapacityText = transform.GetChild(1).GetComponent<Text>();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.numberOfCollectors++;

        practicalAmountImageGraphic.color = Color.white;

        SetCollectorAmountCapacityText();
        SetColorOfCollector();
    }

    public void AddEnergy (float amountOfEnergyToAdd)
    {
        amountOfEnergyCurrentlyStored += amountOfEnergyToAdd;
        practicalAmountImageGraphic.fillAmount = amountOfEnergyCurrentlyStored / amountOfEnergyRequired;

        SetCollectorAmountCapacityText();

        if (amountOfEnergyCurrentlyStored >= amountOfEnergyRequired)
            OnEnergyFilledCompletely();

        //audioController.PlayAudio();
    }

    private void OnEnergyFilledCompletely ()
    {
        levelManager.numberOfFilledCollectors++;
        StartCoroutine(levelManager.CompleteLevel());
    }

    public void SetCollectorAmountCapacityText()
    {
        amountCapacityText.text = amountOfEnergyCurrentlyStored.ToString("f0") + "/" + amountOfEnergyRequired.ToString("f0");
    }

    public void SetColorOfCollector ()
    {
        ColorIdentity.SetColor(collectorColorId, GetComponent<Image>());
    }
}
