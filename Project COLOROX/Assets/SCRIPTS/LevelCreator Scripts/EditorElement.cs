using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorElement : MonoBehaviour {
    
    [HideInInspector]
    public ElementClasses eClass;

    public Slider amountSlider;
    public Slider transferSlider;
    public Slider rotationSlider;
    public Slider sliderRotationSlider;
    public Slider lengthSlider;
    public Slider timeSlider;
    public Dropdown colorDropdown;
    public InputField misjointField;
    public InputField lockField;

    public Slider seperateWattSlider01;
    public Slider seperateWattSlider02;
    public Slider seperateWattTransferSlider01;
    public Slider seperateWattTransferSlider02;
    public Slider seperateWattRotationSlider01;
    public Slider seperateWattRotationSlider02;

    private void Update()
    {
        if (transform.parent.name == "Generator(Clone)")
        {
            SetGenerator();
        }

        if (transform.parent.name == "COLLECTOR(Clone)")
        {
            SetCollector();
        }

        if (transform.parent.name == "Watt Slider(Clone)")
        {
            SetWattSlider();
        }

        if (transform.parent.name == "Lock(Clone)")
        {
            SetLock();
        }

        if (transform.parent.name == "Timed COLLECTOR(Clone)")
        {
            SetTimedCollector();
        }

        if (transform.parent.name == "Color SEPERATOR(Clone)")
        {
            SetColorSeperator();
        }

        if (transform.parent.name == "Wall(Clone)")
        {
            SetWall();
        }

        if (transform.parent.name == "Generator Slider(Clone)")
        {
            SetGeneratorSlider();
        }

        if (transform.parent.name == "COLLECTOR Slider(Clone)")
        {
            SetCollectorSlider();
        }

        if (transform.parent.name == "Timed COLLECTOR Slider(Clone)")
        {
            SetTimedCollectorSlider();
        }
    }

    public void SetThisObjectAsCurrentElement ()
    {
        FindObjectOfType<LevelEditorManager>().SetObjectAsElement(this.GetComponent<UnityEngine.UI.Button>());
    }

    public void MoveButtonOrder ()
    {
        FindObjectOfType<LevelEditorManager>().MoveButton();
    }
    public void RemoveButtonOrder()
    {
        FindObjectOfType<LevelEditorManager>().RemoveButton();
    }

    private void SetGenerator()
    {
        colorDropdown.gameObject.SetActive(true);
        sliderRotationSlider.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(false);
        timeSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(false);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.GetComponent<GeneratorBehaviour>().amountOfEnergyInThisGenerator = amountSlider.value;
        transform.parent.GetComponent<GeneratorBehaviour>().SetAmountCapacityText();

        transferSlider.gameObject.SetActive(true);
        transform.Find("Transfer Text").gameObject.SetActive(true);
        transform.parent.GetComponent<GeneratorBehaviour>().amountOfEnergyToTransfer = transferSlider.value;
        transform.Find("Transfer Text").GetComponent<Text>().text = transferSlider.value.ToString("f0");
        transform.Find("Transfer Text").GetComponent<Text>().color = Color.black;

        transform.parent.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "a";
                break;

            case 1:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "b";
                break;

            case 2:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "c";
                break;

            case 3:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "ab";
                break;

            case 4:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "ca";
                break;

            case 5:
                transform.parent.GetComponent<GeneratorBehaviour>().generatorColorId = "bc";
                break;

        }

        transform.parent.GetComponent<GeneratorBehaviour>().SetColorOfGenerator();
    }
    private void SetCollector()
    {
        colorDropdown.gameObject.SetActive(true);
        sliderRotationSlider.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(false);
        timeSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(false);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.GetComponent<CollectorBehaviour>().amountOfEnergyRequired = amountSlider.value;
        transform.parent.GetComponent<CollectorBehaviour>().SetCollectorAmountCapacityText();

        transferSlider.gameObject.SetActive(false);
        transform.Find("Transfer Text").gameObject.SetActive(false);

        transform.parent.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "a";
                break;

            case 1:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "b";
                break;

            case 2:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "c";
                break;

            case 3:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "ab";
                break;

            case 4:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "ca";
                break;

            case 5:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "bc";
                break;

        }

        transform.parent.GetComponent<CollectorBehaviour>().SetColorOfCollector();
    }
    private void SetWattSlider()
    {
        colorDropdown.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(true);
        lengthSlider.gameObject.SetActive(true);
        timeSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(true);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.localScale = transform.parent.GetComponent<RectTransform>().localScale;

        transform.parent.Find("Handle Slide Area").Find("Handle").GetComponent<WattSlider>().capacityOfWatt = amountSlider.value;
        transform.parent.Find("Handle Slide Area").Find("Handle").GetComponent<WattSlider>().SetAmountCapacityTextForWatt();

        transferSlider.gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").GetComponent<WattSlider>().amountOfWattEnergyToTransfer = transferSlider.value;
        transform.Find("Transfer Text").gameObject.SetActive(true);
        transform.Find("Transfer Text").transform.position = transform.parent.Find("Handle Slide Area").Find("Handle").position;
        transform.Find("Transfer Text").GetComponent<Text>().color = Color.white;
        transform.Find("Transfer Text").GetComponent<Text>().text = transferSlider.value.ToString("f0");

        sliderRotationSlider.gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.parent.rotation = Quaternion.Euler(Vector3.forward * sliderRotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(lengthSlider.value, transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        foreach(Slider slider in FindObjectOfType<LevelEditorManager>().sliders)
        {
            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().misjointField.text == this.misjointField.text && misjointField.text != "")
            {
                slider.value = transform.parent.GetComponent<Slider>().value;
            }
        }
    }
    private void SetColorSeperator ()
    {
        colorDropdown.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(false);
        timeSlider.gameObject.SetActive(false);
        transferSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        rotationSlider.gameObject.SetActive(false);
        sliderRotationSlider.gameObject.SetActive(false);
        lockField.gameObject.SetActive(false);

        seperateWattSlider01.gameObject.SetActive(true);
        seperateWattSlider02.gameObject.SetActive(true);
        seperateWattTransferSlider01.gameObject.SetActive(true);
        seperateWattTransferSlider02.gameObject.SetActive(true);
        seperateWattRotationSlider01.gameObject.SetActive(true);
        seperateWattRotationSlider02.gameObject.SetActive(true);

        transform.parent.GetComponent<ColorSeparator>().capacityOfSeperator = amountSlider.value;
        transform.parent.GetComponent<ColorSeparator>().SetAmountCapacityTextOfSeperator();

        transform.parent.Find("Seperated Color Watt Storage").Find("Handle (1)").GetComponent<WattSlider>().capacityOfWatt = seperateWattSlider01.value;
        transform.parent.Find("Seperated Color Watt Storage").Find("Handle").GetComponent<WattSlider>().capacityOfWatt = seperateWattSlider02.value;
        transform.parent.Find("Seperated Color Watt Storage").Find("Handle (1)").GetComponent<WattSlider>().SetAmountCapacityTextForWatt();
        transform.parent.Find("Seperated Color Watt Storage").Find("Handle").GetComponent<WattSlider>().SetAmountCapacityTextForWatt();

        transform.parent.GetComponent<ColorSeparator>().amountOfSeperatorEnergyToSeperate = transferSlider.value / 2;
        transform.Find("Transfer Text").gameObject.SetActive(true);
        transform.Find("Transfer Text").transform.position = transform.parent.position;
        transform.Find("Transfer Text").GetComponent<Text>().color = Color.white;
        transform.Find("Transfer Text").GetComponent<Text>().text = transferSlider.value.ToString("f0");

        transform.parent.Find("Seperated Color Watt Storage").Find("Handle (1)").GetComponent<WattSlider>().amountOfWattEnergyToTransfer = seperateWattTransferSlider01.value;
        seperateWattTransferSlider01.transform.Find("Text").GetComponent<Text>().text = "W01 TRANSFER AM. " + seperateWattTransferSlider01.value.ToString("f0");
        transform.parent.Find("Seperated Color Watt Storage").Find("Handle").GetComponent<WattSlider>().amountOfWattEnergyToTransfer = seperateWattTransferSlider02.value;
        seperateWattTransferSlider02.transform.Find("Text").GetComponent<Text>().text = "W02 TRANSFER AM. " + seperateWattTransferSlider02.value.ToString("f0");

        transform.parent.Find("Seperated Color Watt Storage").Find("Handle (1)").rotation = Quaternion.Euler(Vector3.forward * seperateWattRotationSlider01.value);
        transform.parent.Find("Seperated Color Watt Storage").Find("Handle").rotation = Quaternion.Euler(Vector3.forward * seperateWattRotationSlider02.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
    }
    private void SetLock ()
    {
        colorDropdown.gameObject.SetActive(false);
        sliderRotationSlider.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(false);
        timeSlider.gameObject.SetActive(false);
        transferSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(true);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.GetComponent<LockBehaviour>().totalLockAmount = amountSlider.value;
        transform.parent.GetComponent<LockBehaviour>().SetTextForLock();

        transform.Find("Transfer Text").gameObject.SetActive(false);

        foreach (Slider slider in FindObjectOfType<LevelEditorManager>().sliders)
        {
            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().lockField.text == this.lockField.text && lockField.text != "")
            {
                transform.parent.GetComponent<LockBehaviour>().sliderToSitOn = slider;
            }

            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().lockField.text != this.lockField.text)
            {
                if (transform.parent.GetComponent<LockBehaviour>().sliderToSitOn != null)
                {
                    transform.parent.GetComponent<LockBehaviour>().sliderToSitOn.interactable = true;
                    transform.parent.GetComponent<LockBehaviour>().sliderToSitOn = null;
                }
            }
        }

        transform.parent.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
    }
    private void SetTimedCollector()
    {
        colorDropdown.gameObject.SetActive(true);
        sliderRotationSlider.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(false);
        timeSlider.gameObject.SetActive(true);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(false);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.GetComponent<CollectorBehaviour>().amountOfEnergyRequired = amountSlider.value;
        transform.parent.GetComponent<CollectorBehaviour>().SetCollectorAmountCapacityText();

        transferSlider.gameObject.SetActive(false);
        transform.Find("Transfer Text").gameObject.SetActive(false);

        transform.parent.GetComponent<TimerBehaviour>().timer = timeSlider.value;
        transform.parent.GetComponent<TimerBehaviour>().SetTimeText();

        transform.parent.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "a";
                break;

            case 1:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "b";
                break;

            case 2:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "c";
                break;

            case 3:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "ab";
                break;

            case 4:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "ca";
                break;

            case 5:
                transform.parent.GetComponent<CollectorBehaviour>().collectorColorId = "bc";
                break;

        }

        transform.parent.GetComponent<CollectorBehaviour>().SetColorOfCollector();
        
    }
    private void SetWall ()
    {
        colorDropdown.gameObject.SetActive(true);
        sliderRotationSlider.gameObject.SetActive(false);
        misjointField.gameObject.SetActive(false);
        lengthSlider.gameObject.SetActive(true);
        timeSlider.gameObject.SetActive(false);
        transferSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(false);
        lockField.gameObject.SetActive(false);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(transform.parent.GetComponent<RectTransform>().sizeDelta.x, lengthSlider.value);

        transform.Find("Transfer Text").gameObject.SetActive(false);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "a";
                break;

            case 1:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "b";
                break;

            case 2:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "c";
                break;

            case 3:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "ab";
                break;

            case 4:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "ca";
                break;

            case 5:
                transform.parent.GetComponent<WallBehaviour>().colorIdentityOfWall = "bc";
                break;

        }

        transform.parent.GetComponent<WallBehaviour>().SetWallColor();

        transform.parent.rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);
    }
    private void SetGeneratorSlider()
    {
        colorDropdown.gameObject.SetActive(true);
        misjointField.gameObject.SetActive(true);
        lengthSlider.gameObject.SetActive(true);
        timeSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(true);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().amountOfEnergyInThisGenerator = amountSlider.value;
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().SetAmountCapacityText();

        transferSlider.gameObject.SetActive(true);
        transform.Find("Transfer Text").gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().amountOfEnergyToTransfer = transferSlider.value;
        transform.Find("Transfer Text").transform.position = transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").position;
        transform.Find("Transfer Text").GetComponent<Text>().text = transferSlider.value.ToString("f0");
        transform.Find("Transfer Text").GetComponent<Text>().color = Color.black;

        sliderRotationSlider.gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.parent.rotation = Quaternion.Euler(Vector3.forward * sliderRotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "a";
                break;

            case 1:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "b";
                break;

            case 2:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "c";
                break;

            case 3:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "ab";
                break;

            case 4:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "ca";
                break;

            case 5:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().generatorColorId = "bc";
                break;

        }

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Generator").GetComponent<GeneratorBehaviour>().SetColorOfGenerator();

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(lengthSlider.value, transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        foreach (Slider slider in FindObjectOfType<LevelEditorManager>().sliders)
        {
            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().misjointField.text == this.misjointField.text && misjointField.text != "")
            {
                slider.value = transform.parent.GetComponent<Slider>().value;
            }
        }
    }
    private void SetCollectorSlider()
    {
        colorDropdown.gameObject.SetActive(true);
        misjointField.gameObject.SetActive(true);
        lengthSlider.gameObject.SetActive(true);
        timeSlider.gameObject.SetActive(false);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(true);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().amountOfEnergyRequired = amountSlider.value;
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().SetCollectorAmountCapacityText();

        transferSlider.gameObject.SetActive(false);
        transform.Find("Transfer Text").gameObject.SetActive(false);

        sliderRotationSlider.gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.parent.rotation = Quaternion.Euler(Vector3.forward * sliderRotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "a";
                break;

            case 1:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "b";
                break;

            case 2:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "c";
                break;

            case 3:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "ab";
                break;

            case 4:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "ca";
                break;

            case 5:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "bc";
                break;

        }

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("COLLECTOR").GetComponent<CollectorBehaviour>().SetColorOfCollector();

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(lengthSlider.value, transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        foreach (Slider slider in FindObjectOfType<LevelEditorManager>().sliders)
        {
            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().misjointField.text == this.misjointField.text && misjointField.text != "")
            {
                slider.value = transform.parent.GetComponent<Slider>().value;
            }
        }
    }
    private void SetTimedCollectorSlider()
    {
        colorDropdown.gameObject.SetActive(true);
        misjointField.gameObject.SetActive(true);
        lengthSlider.gameObject.SetActive(true);
        timeSlider.gameObject.SetActive(true);
        rotationSlider.gameObject.SetActive(true);
        amountSlider.gameObject.SetActive(true);
        lockField.gameObject.SetActive(true);

        seperateWattSlider01.gameObject.SetActive(false);
        seperateWattSlider02.gameObject.SetActive(false);
        seperateWattTransferSlider01.gameObject.SetActive(false);
        seperateWattTransferSlider02.gameObject.SetActive(false);
        seperateWattRotationSlider01.gameObject.SetActive(false);
        seperateWattRotationSlider02.gameObject.SetActive(false);

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().amountOfEnergyRequired = amountSlider.value;
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().SetCollectorAmountCapacityText();

        transferSlider.gameObject.SetActive(false);
        transform.Find("Transfer Text").gameObject.SetActive(false);

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<TimerBehaviour>().timer = timeSlider.value;
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<TimerBehaviour>().SetTimeText();

        sliderRotationSlider.gameObject.SetActive(true);
        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").rotation = Quaternion.Euler(Vector3.forward * rotationSlider.value);
        transform.parent.rotation = Quaternion.Euler(Vector3.forward * sliderRotationSlider.value);
        transform.rotation = Quaternion.Euler(Vector3.forward * 0);

        switch (colorDropdown.value)
        {
            case 0:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "a";
                break;

            case 1:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "b";
                break;

            case 2:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "c";
                break;

            case 3:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "ab";
                break;

            case 4:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "ca";
                break;

            case 5:
                transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().collectorColorId = "bc";
                break;

        }

        transform.parent.Find("Handle Slide Area").Find("Handle").Find("Timed COLLECTOR").GetComponent<CollectorBehaviour>().SetColorOfCollector();

        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(lengthSlider.value, transform.parent.GetComponent<RectTransform>().sizeDelta.y);

        foreach (Slider slider in FindObjectOfType<LevelEditorManager>().sliders)
        {
            if (slider.transform.Find("EditorElement(Clone)").GetComponent<EditorElement>().misjointField.text == this.misjointField.text && misjointField.text != "")
            {
                slider.value = transform.parent.GetComponent<Slider>().value;
            }
        }
    }
}

public enum ElementClasses
{
    GENERATOR,
    COLLECTOR,
    SLIDER,
    WALL,
    SEPERATOR
}
