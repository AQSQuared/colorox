using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    
    private GameObject transferrer;
    private float amountOfEnergy;
    private string colorOfIdentity;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * 25);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TransferEnergy(collision);
    }

    private void TransferEnergy(Collider2D _collision)
    {
        if (_collision.tag == "Generator" && _collision.GetComponent<GeneratorBehaviour>().generatorColorId == colorOfIdentity && _collision.GetComponent<GeneratorBehaviour>().currentAmountOfEnergy < _collision.GetComponent<GeneratorBehaviour>().amountOfEnergyInThisGenerator && _collision.gameObject != transferrer)
        {
            _collision.GetComponent<GeneratorBehaviour>().CollectEnergy(amountOfEnergy);
            Destroy(this.gameObject);
        }

        if (_collision.tag == "Collector" && _collision.GetComponent<CollectorBehaviour>().collectorColorId == colorOfIdentity && _collision.GetComponent<CollectorBehaviour>().amountOfEnergyCurrentlyStored < _collision.GetComponent<CollectorBehaviour>().amountOfEnergyRequired && amountOfEnergy <= _collision.GetComponent<CollectorBehaviour>().amountOfEnergyRequired - _collision.GetComponent<CollectorBehaviour>().amountOfEnergyCurrentlyStored)
        {
            _collision.GetComponent<CollectorBehaviour>().AddEnergy(amountOfEnergy);
            Destroy(this.gameObject);
        }

        if (_collision.tag == "Watt" && _collision.GetComponent<WattSlider>().currentAmountOfEnergy < _collision.GetComponent<WattSlider>().capacityOfWatt && _collision.gameObject != transferrer && amountOfEnergy <= _collision.GetComponent<WattSlider>().capacityOfWatt - _collision.GetComponent<WattSlider>().currentAmountOfEnergy)
        {
            _collision.GetComponent<WattSlider>().AddEnergyToWatt(amountOfEnergy, colorOfIdentity);
            Destroy(this.gameObject);
        }

        if (_collision.tag == "Lock")
        {
            _collision.GetComponent<LockBehaviour>().SubtractLockAmount(amountOfEnergy);
            Destroy(this.gameObject);
        }

        if (_collision.tag == "Wall" && _collision.GetComponent<WallBehaviour>().colorIdentityOfWall != colorOfIdentity)
        {
            //_collision.GetComponent<AudioController>().PlayAudio();
            Destroy(this.gameObject);
        }

        if (_collision.tag == "Seperator" && _collision.GetComponent<ColorSeparator>().currentAmountOfEnergyStoredInSeperator < _collision.GetComponent<ColorSeparator>().capacityOfSeperator && _collision.gameObject != transferrer && amountOfEnergy <= _collision.GetComponent<ColorSeparator>().capacityOfSeperator - _collision.GetComponent<ColorSeparator>().currentAmountOfEnergyStoredInSeperator && colorOfIdentity.Length == 2)
        {
            _collision.GetComponent<ColorSeparator>().AddEnergyToSeperator(amountOfEnergy, colorOfIdentity);
            Destroy(this.gameObject);
        }
    }

    public void SetEnergy (float amountOfEnergyToSet, float _imageFillAmount, string _colorOfIdentity, Color color,  GameObject _transferrer)
    {
        amountOfEnergy = amountOfEnergyToSet;
        colorOfIdentity = _colorOfIdentity;
        //imageFillAmount = _imageFillAmount;
        transferrer = _transferrer;

        this.GetComponent<Image>().color = color;

    }
}
