using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    int AA;
    int SA;
    public Slider volume;
    public Button[] AAbtns;
    public Button[] SAbtns;

    void Start()
    {
        LoadSettings();

    }

    public void LoadSettings()
    {
        AA = PlayerPrefs.GetInt("AimAssist", 0);
        SA = PlayerPrefs.GetInt("ShootAssist", 0);
        volume.value = PlayerPrefs.GetFloat("vol", 1);
        AudioListener.volume = volume.value;
        AAbtns[AA].interactable = false;
        SAbtns[SA].interactable = false;
    }

    void Update()
    {

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        PlayerPrefs.SetFloat("vol", volume.value);
        PlayerPrefs.Save();
    }



    //Aim Assist

    public void AimAssist(int i)
    {
        PlayerPrefs.SetInt("AimAssist", i);
        AA = i;
        PlayerPrefs.Save();
    }   
    public void ShotAssist(int i)
    {
        PlayerPrefs.SetInt("ShootAssist", i);
        SA = i;
        PlayerPrefs.Save();
    }
    
    public void SaveAll()
    {
        PlayerPrefs.SetFloat("vol", volume.value);
        PlayerPrefs.SetInt("AimAssist",AA);
        PlayerPrefs.SetInt("ShootAssist", SA);
    }
}
