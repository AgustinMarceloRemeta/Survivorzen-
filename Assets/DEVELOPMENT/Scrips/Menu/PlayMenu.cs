using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        ResetPlayerPrefs();
        //PlayerPrefs.DeleteAll();
    }

    private static void ResetPlayerPrefs()
    {
        //weapon Selected
        PlayerPrefs.DeleteKey("weaponSelected");

        //bullets
        PlayerPrefs.DeleteKey("gun0bullets");
        PlayerPrefs.DeleteKey("gun1bullets");
        PlayerPrefs.DeleteKey("gun2bullets");

        //weapons upgrade
        PlayerPrefs.DeleteKey("DamageRifle");
        PlayerPrefs.DeleteKey("DamageShotgun");
        PlayerPrefs.DeleteKey("DamageSniper");
        PlayerPrefs.DeleteKey("ReloadRifle");
        PlayerPrefs.DeleteKey("ReloadShotgun");
        PlayerPrefs.DeleteKey("ReloadSniper");
        PlayerPrefs.DeleteKey("SpecialRifle");
        PlayerPrefs.DeleteKey("SpecialShotgun");
        PlayerPrefs.DeleteKey("SpecialSniper");


        //shop sliders
        PlayerPrefs.DeleteKey("Slider0");
        PlayerPrefs.DeleteKey("Slider1");
        PlayerPrefs.DeleteKey("Slider2");
        PlayerPrefs.DeleteKey("Slider3");
        PlayerPrefs.DeleteKey("Slider4");
        PlayerPrefs.DeleteKey("Slider5");
        PlayerPrefs.DeleteKey("Slider6");
        PlayerPrefs.DeleteKey("Slider7");
        PlayerPrefs.DeleteKey("Slider8");

        //money
        PlayerPrefs.DeleteKey("Money");


        //player health
        PlayerPrefs.DeleteKey("PleyerHealth");


    }
}
