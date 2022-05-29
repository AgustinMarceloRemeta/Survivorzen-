using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PleyerHealth : Health
{
    protected AimController aimController;
    [SerializeField]protected Slider healthSlider;
    public AudioClip[] hitclips;
    public AudioClip dieclip;
    public AudioSource audioSource;
    public bool canRecibeDamage;

    protected override void Start()
    {
        canRecibeDamage = true;
        base.Start();
        aimController = GetComponent<AimController>();
        ValueHealth = PlayerPrefs.GetFloat("PleyerHealth", MaxHealth);
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = ValueHealth;
        
    }
    public override void LossHealth(float Damage)
    {
        if (!canRecibeDamage) return;
        base.LossHealth(Damage);
        
        healthSlider.value = ValueHealth;
        if (ValueHealth <= 0)
        {
            aimController.AnimDead();
            DieSound();
        }
        else
        {
            HitSound();
        }
        canRecibeDamage = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            LossHealth(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
            aimController.AnimHit();
        }
        if (other.CompareTag("Enemy"))
        {
            LossHealth(other.GetComponentInParent<EnemyMelee>().damage);
            aimController.AnimHit();
        }
    }
    public void SaveHealth()
    {
        PlayerPrefs.SetFloat("PleyerHealth", ValueHealth);
        PlayerPrefs.Save();
    }
    public void HitSound()
    {
        var index = Random.Range(0, hitclips.Length);
        audioSource.clip = hitclips[index];
        audioSource.Play();
    }
    public void DieSound()
    {
        audioSource.clip = dieclip;
        audioSource.Play();
    }
}
