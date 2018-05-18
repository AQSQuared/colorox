using UnityEngine;
using UnityEngine.UI;

public class GeneratorBehaviour : MonoBehaviour {
    
    public float amountOfEnergyToTransfer = 25;
    public float amountOfEnergyInThisGenerator = 125;
    public string generatorColorId;

    //private AudioController audioController;
    private Image practicalAmountImageGraphic;
    private Text amountCapacityText;

    [HideInInspector]
    public float currentAmountOfEnergy;

    private void Awake()
    {
        //audioController = GetComponent<AudioController>();
        practicalAmountImageGraphic = transform.GetChild(0).GetComponent<Image>();
        amountCapacityText = transform.GetChild(2).GetComponent<Text>();
        currentAmountOfEnergy = amountOfEnergyInThisGenerator;

        practicalAmountImageGraphic.color = Color.white;
        SetAmountCapacityText();
        SetColorOfGenerator();
    }

    public void GenerateEnergy ()
    {
        if(currentAmountOfEnergy > 0)
        {
            Energy newEnergy = Instantiate(Resources.Load("energy", typeof(Energy)), transform.position, transform.rotation) as Energy;
            newEnergy.transform.SetParent(transform);

            if(currentAmountOfEnergy >= amountOfEnergyToTransfer)
            {
                newEnergy.SetEnergy(amountOfEnergyToTransfer, amountOfEnergyToTransfer / amountOfEnergyInThisGenerator, generatorColorId, GetComponent<Image>().color, gameObject);
                currentAmountOfEnergy -= amountOfEnergyToTransfer;
            }

            else if (currentAmountOfEnergy < amountOfEnergyToTransfer)
            {
                newEnergy.SetEnergy(currentAmountOfEnergy, amountOfEnergyToTransfer / amountOfEnergyInThisGenerator, generatorColorId, GetComponent<Image>().color, gameObject);
                currentAmountOfEnergy -= currentAmountOfEnergy;
            }

            practicalAmountImageGraphic.fillAmount -= amountOfEnergyToTransfer / amountOfEnergyInThisGenerator;

            //newEnergy.GetComponent<RectTransform>().sizeDelta = new Vector2(generatorRange, generatorRange);

        }

        else if (currentAmountOfEnergy <= 0)
        {
            Debug.Log("Generator Out Of Energy.");
        }

        SetAmountCapacityText();

       // audioController.PlayAudio();
    }

    public void CollectEnergy(float amountOfEnergyToAdd)
    {
        if (currentAmountOfEnergy < amountOfEnergyInThisGenerator)
        {
            currentAmountOfEnergy += amountOfEnergyToAdd;
            practicalAmountImageGraphic.fillAmount += amountOfEnergyToTransfer / amountOfEnergyInThisGenerator;

            SetAmountCapacityText();
        }

       // audioController.PlayAudio();

    }

    public void SetAmountCapacityText()
    {
        amountCapacityText.text = currentAmountOfEnergy.ToString("f0") + "/" + amountOfEnergyInThisGenerator.ToString("f0");
    }

    public void SetColorOfGenerator()
    {
        ColorIdentity.SetColor(generatorColorId, GetComponent<Image>());
    }
}
