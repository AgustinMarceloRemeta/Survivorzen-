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
        Debug.Log(PlayerPrefs.GetInt("AimAssist", 0));
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
        PlayerPrefs.Save();
    }



    //Aim Assist

    public void AimAssist(int i)
    {
        PlayerPrefs.SetInt("AimAssist", i);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("AimAssist", 0));
    }   
    public void ShotAssist(int i)
    {
        PlayerPrefs.SetInt("ShootAssist", i);
        PlayerPrefs.Save();
    }
    
}
