using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    protected int animattack;
    public override void Start()
    {
        base.Start();
        animattack = Animator.StringToHash("Melee");
        InvokeRepeating("Mov", 0, 0.01f);
    }

  
    void Update()
    {
        
    }

    public override void Attack()
    {
        _animator.SetBool(animattack, true);
        atacking = true;
    }
    public override void AttackFinish()
    {
        _animator.SetBool(animattack, false);
        atacking = false;
    }
}
