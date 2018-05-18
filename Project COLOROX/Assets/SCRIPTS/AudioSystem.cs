using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour {

    private static AudioSystem audioInstance;
    private static float preVolume;

    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        DontDestroyOnLoad(this.gameObject);
        if(audioInstance == null)
        {
            audioInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(volumeSlider != null)
        {
            GetComponent<AudioSource>().volume = volumeSlider.value;
            preVolume = GetComponent<AudioSource>().volume;
        }
        else if(volumeSlider == null && GameObject.Find("VolumeSlider") != null)
        {
            volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
            volumeSlider.value = preVolume;
        }
    }
}
