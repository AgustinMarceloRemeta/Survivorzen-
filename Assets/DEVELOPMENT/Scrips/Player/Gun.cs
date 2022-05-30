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
    public float fireRate;
    public int magazine;
    public int bullets;
    public float rechargerTime = 1f;
    public GameObject bulletPref;
    public AudioSource AudioSource;
    public AudioClip shootClip;
    public AudioClip reloadClip;
}
