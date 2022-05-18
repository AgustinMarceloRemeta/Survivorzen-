using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerHealth : Health
{
    protected AimController aimController;

    protected override void Start()
    {
        base.Start();
        aimController = GetComponent<AimController>();
    }
    public override void LossHealth(float Damage)
    {
        base.LossHealth(Damage);
        if (ValueHealth <= 0)
        {
            aimController.AnimDead();
        }
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
