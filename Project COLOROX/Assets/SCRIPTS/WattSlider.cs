using UnityEngine;
using UnityEngine.UI;

public class WattSlider : MonoBehaviour {

    public float amountOfWattEnergyToTransfer = 10;
    public float capacityOfWatt = 50;

    //private AudioController audioController;
    private Image practicalAmountImageGraphic;
    private Text amountCapacityText;
    private string colorOfIdentity;

    [HideInInspector]
    public float currentAmountOfEnergy;

    private void Awake()
    {
        //audioController = GetComponentInParent<AudioController>();
        practicalAmountImageGraphic = transform.GetChild(1).GetComponent<Image>();
        amountCapacityText = transform.GetChild(2).GetComponent<Text>();
        currentAmountOfEnergy = 0;

        practicalAmountImageGraphic.color = Color.white;
        SetAmountCapacityTextForWatt();
    }

    public void GenerateWattEnergy()
    {
        if (currentAmountOfEnergy > 0)
        {
            Energy newEnergy = Instantiate(Resources.Load("energy", typeof(Energy)), transform.position, transform.rotation) as Energy;
            newEnergy.transform.SetParent(transform);

            if (currentAmountOfEnergy >= amountOfWattEnergyToTransfer)
            {
                currentAmountOfEnergy -= amountOfWattEnergyToTransfer;
                newEnergy.SetEnergy(amountOfWattEnergyToTransfer, amountOfWattEnergyToTransfer / capacityOfWatt, colorOfIdentity, GetComponent<Image>().color, gameObject);
            }

            else if (currentAmountOfEnergy < amountOfWattEnergyToTransfer)
            {
                newEnergy.SetEnergy(currentAmountOfEnergy, amountOfWattEnergyToTransfer / capacityOfWatt, colorOfIdentity, GetComponent<Image>().color, gameObject);
                currentAmountOfEnergy -= currentAmountOfEnergy;
            }

            practicalAmountImageGraphic.fillAmount -= amountOfWattEnergyToTransfer / capacityOfWatt;

            if (currentAmountOfEnergy <= 0)
            {
                colorOfIdentity = "";
                SetColorOfWatt();
            }
        }

        SetAmountCapacityTextForWatt();

        //audioController.PlayAudio();
    }

    public void AddEnergyToWatt(float amountOfEnergyToAdd, string _colorOfIdentity)
    {
        currentAmountOfEnergy += amountOfEnergyToAdd;
        practicalAmountImageGraphic.fillAmount = currentAmountOfEnergy / capacityOfWatt;

        if (_colorOfIdentity != colorOfIdentity)
            colorOfIdentity += _colorOfIdentity;
        //else
        //colorOfIdentity = colorOfIdentity;

        SetAmountCapacityTextForWatt();
        SetColorOfWatt();

        if (currentAmountOfEnergy >= capacityOfWatt)
            currentAmountOfEnergy = capacityOfWatt;

        if (currentAmountOfEnergy >= capacityOfWatt)
            Debug.Log("Watt Filled");

        //audioController.PlayAudio();

    }

    public void SetAmountCapacityTextForWatt()
    {
        amountCapacityText.text = currentAmountOfEnergy.ToString("f0") + "/" + capacityOfWatt.ToString("f0");
    }

    private void SetColorOfWatt()
    {
        if (colorOfIdentity == "ab" || colorOfIdentity == "ba")
            colorOfIdentity = "ab";

        if (colorOfIdentity == "bc" || colorOfIdentity == "cb")
            colorOfIdentity = "bc";

        if (colorOfIdentity == "ca" || colorOfIdentity == "ac")
            colorOfIdentity = "ca";

        if (colorOfIdentity == "aa" || colorOfIdentity == "a")
            colorOfIdentity = "a";

        if (colorOfIdentity == "bb" || colorOfIdentity == "b")
            colorOfIdentity = "b";

        if (colorOfIdentity == "cc" || colorOfIdentity == "c")
            colorOfIdentity = "c";

        if (colorOfIdentity.Length > 2)
        {
            colorOfIdentity = colorOfIdentity.Substring(0, 2);
        }

        if (colorOfIdentity == "ab" || colorOfIdentity == "ba")
            colorOfIdentity = "ab";

        if (colorOfIdentity == "bc" || colorOfIdentity == "cb")
            colorOfIdentity = "bc";

        if (colorOfIdentity == "ca" || colorOfIdentity == "ac")
            colorOfIdentity = "ca";

        if (colorOfIdentity == "aa" || colorOfIdentity == "a")
            colorOfIdentity = "a";

        if (colorOfIdentity == "bb" || colorOfIdentity == "b")
            colorOfIdentity = "b";

        if (colorOfIdentity == "cc" || colorOfIdentity == "c")
            colorOfIdentity = "c";

        ColorIdentity.SetColor(colorOfIdentity, GetComponent<Image>());
    }
}
