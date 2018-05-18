using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    public Text timerText;
    public float timer;

    private bool timerZeroDeclarer;

    private void FixedUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            SetTimeText();
        }

        if (timer <= 0 && timerZeroDeclarer == false)
        {
            OnTimerZero();
            timerZeroDeclarer = true;
        }
    }

    private void OnTimerZero ()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.3f);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetTimeText ()
    {
        timerText.text = timer.ToString("F0");
    }
}
