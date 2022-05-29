using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public int i;
    public AimController aimController;
    public Image Weapon;
    public Sprite[] weapons;
    public GameObject[] shopimage;
    void Start()
    {
        i = PlayerPrefs.GetInt("weaponSelected", 0);
        shopimage[i].SetActive(true);
        Weapon.sprite = weapons[i];
        aimController.ChangeGun(i);
    }

    public void nextWeapon()
    {
        shopimage[i].SetActive(false);
        i++;
        if (i >= 3) i = 0;
        PlayerPrefs.SetInt("weaponSelected", i);
        PlayerPrefs.Save();
        Weapon.sprite = weapons[i];
        shopimage[i].SetActive(true);
        aimController.ChangeGun(i);
    }
    public void preWeapong()
    {
        shopimage[i].SetActive(false);
        i--;
        if (i <= -1) i = 2;
        PlayerPrefs.SetInt("weaponSelected", i);
        PlayerPrefs.Save();
        Weapon.sprite = weapons[i];
        shopimage[i].SetActive(true);
        aimController.ChangeGun(i);
    }
}
