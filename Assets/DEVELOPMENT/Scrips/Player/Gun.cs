using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage;
    public Transform[] fireTransforms;
    public int numberOfShots;
    public float fireDistance;
    public float fireVelocity;
    public float fireRate = 1f;
    public int magazine;
    public int bullets;
    public float rechargerTime;
    public GameObject bulletPref;
    public AudioSource AudioSource;
    public AudioClip shootClip;
    public AudioClip reloadClip;
}
