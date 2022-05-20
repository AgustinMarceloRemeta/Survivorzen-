using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    protected int animattack;
    [SerializeField]protected BoxCollider weapon;
    public override void Start()
    {
        base.Start();
        animattack = Animator.StringToHash("Melee");
        InvokeRepeating("Mov", 0, 0.01f);
        weapon.enabled = false;
    }


    public override void Attack()
    {
        _animator.SetBool(animattack, true);
        attacking = true;
    }
    public void ColliderActive()
    {
        weapon.enabled = true;
    }
    public override void AttackFinish()
    {
        _animator.SetBool(animattack, false);
        attacking = false;
        weapon.enabled = false;
    }
}
