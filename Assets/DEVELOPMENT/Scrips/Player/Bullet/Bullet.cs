using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public bool sniper;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }
}
