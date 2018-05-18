using UnityEngine;
using UnityEngine.UI;

public class ColorSeparator : MonoBehaviour {

    public float amountOfSeperatorEnergyToSeperate = 10;
    public float capacityOfSeperator = 50;
    [HideInInspector]
    public float currentAmountOfEnergyStoredInSeperator;

    //private AudioController audioController;
    private Image practicalAmountImageGraphic;
    private Text amountCapacityText;
    private string colorOfIdentity;

    private void Awake()
    {
        //audioController = GetComponent<AudioController>();
        practicalAmountImageGraphic = transform.GetChild(1).GetComponent<Image>();
        amountCapacityText = transform.GetChild(2).GetComponent<Text>();
        currentAmountOfEnergyStoredInSeperator = 0;

        practicalAmountImageGraphic.color = Color.white;
        SetAmountCapacityTextOfSeperator();
    }

    public void SeperateColor ()
    {
        if (currentAmountOfEnergyStoredInSeperator > 0)
        {
            Energy newEnergy01 = Instantiate(Resources.Load("energy", typeof(Energy)), transform.position, transform.rotation) as Energy;
            Energy newEnergy02 = Instantiate(Resources.Load("energy", typeof(Energy)), transform.position, Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + 180))) as Energy;

            newEnergy01.transform.SetParent(transform);
            newEnergy02.transform.SetParent(transform);

            if (currentAmountOfEnergyStoredInSeperator >= amountOfSeperatorEnergyToSeperate)
            {
                currentAmountOfEnergyStoredInSeperator -= amountOfSeperatorEnergyToSeperate;
                newEnergy01.SetEnergy(amountOfSeperatorEnergyToSeperate / 2, amountOfSeperatorEnergyToSeperate / capacityOfSeperator, colorOfIdentity.Substring(0, 1), Color.white, gameObject);
                newEnergy02.SetEnergy(amountOfSeperatorEnergyToSeperate / 2, amountOfSeperatorEnergyToSeperate / capacityOfSeperator, colorOfIdentity.Substring(1, 1), Color.white, gameObject);
            }

            practicalAmountImageGraphic.fillAmount -= (amountOfSeperatorEnergyToSeperate / capacityOfSeperator);

            if (currentAmountOfEnergyStoredInSeperator <= 0)
            {
                colorOfIdentity = "";
                SetColor();
            }
        }

        SetAmountCapacityTextOfSeperator();

        //audioController.PlayAudio();

    }

    public void AddEnergyToSeperator(float amountOfEnergyToAdd, string _colorOfIdentity)
    {
        currentAmountOfEnergyStoredInSeperator += amountOfEnergyToAdd;
        practicalAmountImageGraphic.fillAmount = currentAmountOfEnergyStoredInSeperator / capacityOfSeperator;

        if (_colorOfIdentity != colorOfIdentity)
            colorOfIdentity += _colorOfIdentity;
        //else
        //colorOfIdentity = colorOfIdentity;

        SetAmountCapacityTextOfSeperator();
        SetColor();

        if (currentAmountOfEnergyStoredInSeperator >= capacityOfSeperator)
            currentAmountOfEnergyStoredInSeperator = capacityOfSeperator;

        //audioController.PlayAudio();

    }

    public void SetAmountCapacityTextOfSeperator()
    {
        amountCapacityText.text = currentAmountOfEnergyStoredInSeperator.ToString("f0") + "/" + capacityOfSeperator.ToString("f0");
    }

    private void SetColor()
    {
        if (colorOfIdentity == "ab" || colorOfIdentity == "ba")
            colorOfIdentity = "ab";

        if (colorOfIdentity == "bc" || colorOfIdentity == "cb")
            colorOfIdentity = "bc";

        if (colorOfIdentity == "ca" || colorOfIdentity == "ac")
            colorOfIdentity = "ca";

        if (colorOfIdentity.Length > 2)
        {
            colorOfIdentity = colorOfIdentity.Substring(0, 2);
        }

        ColorIdentity.SetColor(colorOfIdentity, GetComponent<Image>());
    }
}
