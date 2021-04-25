using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class audioSetting : MonoBehaviour
{
    public AudioMixer masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public void MasterVolume(float volume)
    {
        masterSlider.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
    void MusicVolume()
    {
        Camera.main.GetComponent<AudioSource>().volume = musicSlider.value;
    }
}
