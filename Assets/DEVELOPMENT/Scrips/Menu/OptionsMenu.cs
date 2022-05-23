using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volume;
    public Button[] AAbtns;
    public Button[] SAbtns;

    void Start()
    {
        volume.value = PlayerPrefs.GetFloat("vol", 1);
        AudioListener.volume = volume.value;
        AAbtns[PlayerPrefs.GetInt("AimAssist", 0)].interactable = false;
        SAbtns[PlayerPrefs.GetInt("ShootAssist", 0)].interactable = false;
        
    }


    void Update()
    {

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        PlayerPrefs.SetFloat("vol", volume.value);
    }
    public void resumeBtn()
    {
        Time.timeScale = 1;
    }
    //Aim Assist

    public void AimAssist(int i)
    {
        PlayerPrefs.SetInt("AimAssist", i);
    }   
    public void ShotAssist(int i)
    {
        PlayerPrefs.SetInt("ShootAssist", i);
    }
    
}
