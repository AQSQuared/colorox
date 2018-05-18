using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {

    public static bool soundEnabled = true;

    private AudioSource audioSource;
    private float delayInRepeating;
    private float nextRepeatTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio ()
    {
        if(soundEnabled == true)
        {
            audioSource.volume = 0.56f;
            audioSource.Play();
            nextRepeatTime = Time.time - nextRepeatTime;
            delayInRepeating = nextRepeatTime;

            StartCoroutine(RepeatAudio());
        }
    }

    public IEnumerator RepeatAudio ()
    {
        yield return new WaitForSeconds(delayInRepeating + 2.25f);

        audioSource.volume = 0.05f;
        audioSource.Play();

        StartCoroutine(RepeatAudio());
    }

    public void ToggleSFX ()
    {
        if(soundEnabled == false)
        {
            soundEnabled = true;
        }

        if (soundEnabled == true)
        {
            soundEnabled = false;
        }
    }
}
