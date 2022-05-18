using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected Enemy enemy;


    protected override void Start()
    {
        enemy = GetComponent<Enemy>();
        base.Start();
    }
    public override void LossHealth(float Damage)
    {
        base.LossHealth(Damage);
        if (ValueHealth <= 0)
        {
            enemy.Die();
        }
    }
}
