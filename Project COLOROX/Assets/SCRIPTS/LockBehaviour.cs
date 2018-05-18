using UnityEngine;
using UnityEngine.UI;

public class LockBehaviour : MonoBehaviour {

    public Slider sliderToSitOn;
    public float totalLockAmount;

   // private AudioController audioController;
    private Text requiredLockAmountText;

    private void Start()
    {
       // audioController = GetComponent<AudioController>();
        requiredLockAmountText = transform.GetChild(1).GetComponent<Text>();

        SetTextForLock();
    }

    private void FixedUpdate()
    {
        if (sliderToSitOn != null)
        {
            sliderToSitOn.interactable = false;
        }
    }

    public void SubtractLockAmount (float lockAmountToSubtact)
    {
       // audioController.PlayAudio();

        totalLockAmount -= lockAmountToSubtact;
        SetTextForLock();

        if(totalLockAmount <= 0)
        {
            OnLockAmountIsZero();
        }
    }

    private void OnLockAmountIsZero ()
    {
        sliderToSitOn.interactable = true;
        gameObject.SetActive(false);
    }

    public void SetTextForLock ()
    {
        requiredLockAmountText.text = totalLockAmount.ToString("f0");
    }
}
