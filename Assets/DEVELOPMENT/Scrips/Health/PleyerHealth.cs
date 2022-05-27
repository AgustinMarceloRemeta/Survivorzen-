using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PleyerHealth : Health
{
    protected AimController aimController;
    [SerializeField]protected Slider healthSlider;
    public bool canRecibeDamage;

    protected override void Start()
    {
        canRecibeDamage = true;
        base.Start();
        aimController = GetComponent<AimController>();
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = MaxHealth;
    }
    public override void LossHealth(float Damage)
    {
        if (!canRecibeDamage) return;
        base.LossHealth(Damage);
        Debug.Log(Damage);
        healthSlider.value = ValueHealth;
        if (ValueHealth <= 0)
        {
            aimController.AnimDead();
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
}
