using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{

    public override void Start()
    {
        base.Start();
        InvokeRepeating("Mov", 0, 0.01f);
    }

  
    void Update()
    {
        
    }

    public override void Attack()
    {
        base.Attack();
        if (Shoot)
        {
            Shoot = false;
            StartCoroutine(Timer(Cooldown));
            print("te mordi");
            //agregar quite de daño al player;
        }

    }

}
