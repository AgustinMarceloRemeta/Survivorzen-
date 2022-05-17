using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerHealth : Health
{
    public override void LossHealth(float Damage)
    {
        base.LossHealth(Damage);
        if (ValueHealth <= 0)
        {
            Debug.Log("Perder");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            LossHealth(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            LossHealth(other.GetComponentInParent<EnemyMelee>().damage);
        }
    }
}
