using UnityEngine;
using UnityEngine.UI;

public class RotationControlSlider : MonoBehaviour {

    public Transform[] transformsToControl;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < transformsToControl.Length; i++)
        {
            transformsToControl[i].rotation = Quaternion.Euler(Vector3.forward * slider.value);
        }
    }
}
