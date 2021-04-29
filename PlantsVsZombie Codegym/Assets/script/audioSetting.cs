using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class audioSetting : MonoBehaviour
{
    public AudioMixer masterSlider;
    public void MasterVolume(float volume)
    {
        masterSlider.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
    
}
