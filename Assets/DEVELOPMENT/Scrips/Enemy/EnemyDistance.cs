using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : Enemy
{
 
   
    [SerializeField] protected GameObject BulletPref;
    [SerializeField] protected Transform Gun;
    [SerializeField] protected float ShootImpulse;

    protected int animattack;
    public override void Start()
    {
        base.Start();
        animattack = Animator.StringToHash("Shoot");
        InvokeRepeating("Mov", 0, 0.01f);

    }

    public override void Attack()
    {
        _animator.SetBool(animattack, true);
        attacking = true;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPref, Gun.position, Quaternion.identity);
        Vector3 Direction = Player.transform.position;
        
        Direction -= Gun.position;
        Direction.y = 0f;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Direction * ShootImpulse, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().SetDamage(damage);
        Destroy(bullet, 5);
    }
    public override void AttackFinish()
    {
        _animator.SetBool(animattack, false);
        attacking = false;
    }


}
