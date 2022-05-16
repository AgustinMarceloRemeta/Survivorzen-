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
}
