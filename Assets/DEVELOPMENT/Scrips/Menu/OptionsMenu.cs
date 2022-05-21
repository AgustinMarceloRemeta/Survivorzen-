using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volume;

    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("vol", 1);
        AudioListener.volume = volume.value;
    }


    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        PlayerPrefs.SetFloat("vol", volume.value);
    }
}
