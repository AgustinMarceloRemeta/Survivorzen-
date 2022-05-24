using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] Gun Rifle, Shotgun, Sniper;
    [SerializeField] Slider[] Sliders;


    private void Start()
    {
        LoadSliders();
        LoadGuns();
    }

    public void UpgradeDamage(int Id)
    {
        switch (Id)
        {
            case 0:

                if (Sliders[Id].value >= 3) return;
                Sliders[Id].value++;
                PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                Rifle.damage += 10;
                PlayerPrefs.SetFloat("DamageRifle", PlayerPrefs.GetFloat("DamageRifle", Rifle.damage));



                break;

            case 1:

                if (Sliders[Id].value >= 3) return;
                Sliders[Id].value++;
                PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                Shotgun.damage += 5;
                PlayerPrefs.SetFloat("DamageShotgun", PlayerPrefs.GetFloat("DamageShotgun", Shotgun.damage));

                break;
            case 2:

                if (Sliders[Id].value >= 3) return;
                Sliders[Id].value++;
                PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                Sniper.damage += 15;
                PlayerPrefs.SetFloat("DamageSniper", PlayerPrefs.GetFloat("DamageSniper", Sniper.damage));

                break;
            default:
                break;               
        }

    }
    public void UpgradeReload(int Id)
    {
        switch (Id)
        {
            case 0:

                if (Sliders[Id+3].value >= 3) return;
                Sliders[Id+3].value++;
                int i1 = Id + 3;
                PlayerPrefs.SetFloat("Slider" + i1, Sliders[Id+3].value);
                Rifle.rechargerTim�e += 0.5f;
                PlayerPrefs.SetFloat("ReloadRifle", PlayerPrefs.GetFloat("ReloadRifle", Rifle.rechargerTim�e));

                break;

            case 1:

                if (Sliders[Id+3].value >= 3) return;
                Sliders[Id+3].value++;
                int i2 = Id + 3;
                PlayerPrefs.SetFloat("Slider" + i2, Sliders[Id+3].value);
                Shotgun.rechargerTim�e += 0.5f;
                PlayerPrefs.SetFloat("ReloadShotgun", PlayerPrefs.GetFloat("ReloadShotgun", Shotgun.rechargerTim�e));
                
                break;

            case 2:

                if (Sliders[Id+3].value >= 3) return;
                Sliders[Id+3].value++;
                int i3 = Id + 3;
                PlayerPrefs.SetFloat("Slider" + i3, Sliders[Id+3].value);
                Sniper.rechargerTim�e += 0.5f;
                PlayerPrefs.SetFloat("ReloadSniper", PlayerPrefs.GetFloat("ReloadSniper", Sniper.rechargerTim�e));

                break;

            default:
                break;
        }

    }
    public void UpgradeSpecial(int Id)
    {
        switch (Id)
        {
            case 0:

                if (Sliders[Id+6].value >= 3) return;
                Sliders[Id+6].value++;
                int i1 = Id + 6;
                PlayerPrefs.SetFloat("Slider" + i1, Sliders[Id+6].value);
                Rifle.numberOfShots += 1;
                PlayerPrefs.SetInt("SpecialRifle", PlayerPrefs.GetInt("SpecialRifle", Rifle.numberOfShots));

                break;

            case 1:

                if (Sliders[Id+6].value >= 3) return;
                Sliders[Id+ 6].value++;
                int i2 = Id + 6;
                PlayerPrefs.SetFloat("Slider" + i2, Sliders[Id+6].value);
                Shotgun.numberOfShots += 2;
                PlayerPrefs.SetInt("SpecialShotgun", PlayerPrefs.GetInt("SpecialShotgun", Shotgun.numberOfShots));

                break;
            case 2:

                if (Sliders[Id+6].value >= 3) return;
                Sliders[Id+6].value++;
                int i3= Id + 6;
                PlayerPrefs.SetFloat("Slider" + i3, Sliders[Id+6].value);
                Sniper.magazine += 1;
                PlayerPrefs.SetInt("SpecialSniper", PlayerPrefs.GetInt("SpecialSniper", Sniper.magazine));

                break;
            default:
                break;
        }
    }
  
    public void LoadSliders()
    {
        for (int i = 0; i < Sliders.Length; i++)
        {
            Sliders[i].value = PlayerPrefs.GetFloat("Slider" + i,0);
        }
    }
    public void ResetKeys()
    {
        PlayerPrefs.DeleteAll();
    }
    private void LoadGuns()
    {
        Rifle.damage = PlayerPrefs.GetFloat("DamageRifle", Rifle.damage);
        Shotgun.damage = PlayerPrefs.GetFloat("DamageShotgun", Shotgun.damage);
     //   Sniper.damage = PlayerPrefs.GetFloat("DamageSniper", Sniper.damage);
        Rifle.rechargerTim�e = PlayerPrefs.GetFloat("ReloadRifle", Rifle.rechargerTim�e);
        Shotgun.rechargerTim�e = PlayerPrefs.GetFloat("ReloadShotgun", Shotgun.rechargerTim�e);
        //Sniper.rechargerTim�e = PlayerPrefs.GetFloat("ReloadSniper", Sniper.rechargerTim�e);
        Rifle.numberOfShots = PlayerPrefs.GetInt("SpecialRifle", Rifle.numberOfShots);
        Shotgun.numberOfShots = PlayerPrefs.GetInt("SpecialShotgun", Shotgun.numberOfShots);
       // Sniper.magazine = PlayerPrefs.GetInt("SpecialSniper", Sniper.magazine);
    }
}