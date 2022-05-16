using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : Enemy
{
 
   
    [SerializeField] GameObject BulletPref;
    [SerializeField] Transform Gun;
    public override void Start()
    {
        base.Start();
        InvokeRepeating("Mov", 0, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(BulletPref, Gun.position, Gun.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
        Destroy(bullet, 5);

    }
    public override void AttackFinish()
    {
        
    }


}
