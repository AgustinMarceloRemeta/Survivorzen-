using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    [SerializeField] Gun Rifle, Shotgun, Sniper;
    [SerializeField] Slider[] Sliders;
    [SerializeField] int[] Price;
    [SerializeField] TextMeshProUGUI[] TextPrice;
    [SerializeField] AudioClip sellClip;
    GameManager Manager;
    [SerializeField] int PriceX;


    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        LoadSliders();
        LoadGuns();
        StartSlider();
        AsignPrice();
        AsignText();
      
    }

    public void UpgradeDamage(int Id)
    {
        switch (Id)
        {
            case 0:
                if (Price[Id] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                    Rifle.damage += 10;
                    PlayerPrefs.SetFloat("DamageRifle", PlayerPrefs.GetFloat("DamageRifle", Rifle.damage));
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);

                }


                break;

            case 1:
                if (Price[Id] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                    Shotgun.damage += 5;
                    PlayerPrefs.SetFloat("DamageShotgun", PlayerPrefs.GetFloat("DamageShotgun", Shotgun.damage));
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            case 2:
                if (Price[Id] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id].value >= 3) return;
                    Sliders[Id].value++;
                    PlayerPrefs.SetFloat("Slider" + Id, Sliders[Id].value);
                    Sniper.damage += 15;
                    PlayerPrefs.SetFloat("DamageSniper", PlayerPrefs.GetFloat("DamageSniper", Sniper.damage));
                    Manager.DownScore(Price[Id]);
                    Price[Id] = Price[Id] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            default:
                break;               
        }
        
        PlayerPrefs.Save();
    }
    public void UpgradeReload(int Id)
    {

        switch (Id)
        {
            case 0:
                if (Price[Id+3] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i1 = Id + 3;
                    PlayerPrefs.SetFloat("Slider" + i1, Sliders[Id + 3].value);
                    Rifle.rechargerTimºe += 0.5f;
                    PlayerPrefs.SetFloat("ReloadRifle", PlayerPrefs.GetFloat("ReloadRifle", Rifle.rechargerTimºe));
                    Manager.DownScore(Price[Id+3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 1:
                if (Price[Id + 3] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i2 = Id + 3;
                    PlayerPrefs.SetFloat("Slider" + i2, Sliders[Id + 3].value);
                    Shotgun.rechargerTimºe += 0.5f;
                    PlayerPrefs.SetFloat("ReloadShotgun", PlayerPrefs.GetFloat("ReloadShotgun", Shotgun.rechargerTimºe));
                    Manager.DownScore(Price[Id + 3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 2:
                if (Price[Id + 3] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 3].value >= 3) return;
                    Sliders[Id + 3].value++;
                    int i3 = Id + 3;
                    PlayerPrefs.SetFloat("Slider" + i3, Sliders[Id + 3].value);
                    Sniper.rechargerTimºe += 0.5f;
                    PlayerPrefs.SetFloat("ReloadSniper", PlayerPrefs.GetFloat("ReloadSniper", Sniper.rechargerTimºe));
                    Manager.DownScore(Price[Id + 3]);
                    Price[Id + 3] = Price[Id + 3] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            default:
                break;
        }
        PlayerPrefs.Save();
    }
    public void UpgradeSpecial(int Id)
    {

        switch (Id)
        {
            case 0:
                if (Price[Id + 6] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i1 = Id + 6;
                    PlayerPrefs.SetFloat("Slider" + i1, Sliders[Id + 6].value);
                    Rifle.numberOfShots += 1;
                    PlayerPrefs.SetInt("SpecialRifle", PlayerPrefs.GetInt("SpecialRifle", Rifle.numberOfShots));
                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;

            case 1:

                if (Price[Id + 6] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i2 = Id + 6;
                    PlayerPrefs.SetFloat("Slider" + i2, Sliders[Id + 6].value);
                    Shotgun.numberOfShots += 2;
                    PlayerPrefs.SetInt("SpecialShotgun", PlayerPrefs.GetInt("SpecialShotgun", Shotgun.numberOfShots));
                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            case 2:
                if (Price[Id + 6] <= PlayerPrefs.GetFloat("Money"))
                {
                    if (Sliders[Id + 6].value >= 3) return;
                    Sliders[Id + 6].value++;
                    int i3 = Id + 6;
                    PlayerPrefs.SetFloat("Slider" + i3, Sliders[Id + 6].value);
                    Sniper.magazine += 1;
                    PlayerPrefs.SetInt("SpecialSniper", PlayerPrefs.GetInt("SpecialSniper", Sniper.magazine));
                    Manager.DownScore(Price[Id + 6]);
                    Price[Id + 6] = Price[Id + 6] * PriceX;
                    AsignText();
                    AudioSource.PlayClipAtPoint(sellClip, Rifle.transform.position, 1);
                }
                break;
            default:
                break;
        }
        PlayerPrefs.Save();
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
        Sniper.damage = PlayerPrefs.GetFloat("DamageSniper", Sniper.damage);
        Rifle.rechargerTimºe = PlayerPrefs.GetFloat("ReloadRifle", Rifle.rechargerTimºe);
        Shotgun.rechargerTimºe = PlayerPrefs.GetFloat("ReloadShotgun", Shotgun.rechargerTimºe);
        Sniper.rechargerTimºe = PlayerPrefs.GetFloat("ReloadSniper", Sniper.rechargerTimºe);
        Rifle.numberOfShots = PlayerPrefs.GetInt("SpecialRifle", Rifle.numberOfShots);
        Shotgun.numberOfShots = PlayerPrefs.GetInt("SpecialShotgun", Shotgun.numberOfShots);
        Sniper.magazine = PlayerPrefs.GetInt("SpecialSniper", Sniper.magazine);
    }
    void StartSlider()
    {
        foreach (var i in Sliders)
        {
         if(i.value == 0) i.value = 1;
        }
    }
    void AsignText()
    {
        for (int i = 0; i < Price.Length; i++)
        {
            if (Sliders[i].value >= 3) TextPrice[i].text = "Full";            
            else TextPrice[i].text = Price[i].ToString();
        }
    }
    void AsignPrice()
    {
        for (int i = 0; i < Price.Length; i++)
        {
            switch (Sliders[i].value)
            {
                case 1: 
                    break;

                case 2: Price[i] = Price[i] * PriceX;
                    break;

                case 3: TextPrice[i].text = "Full";
                    break;

                default:
                    break;
            }
        }
    }
}