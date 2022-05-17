using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class  Health : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float ValueHealth;

    protected virtual void Start()
    {
        ValueHealth = MaxHealth;
    }
    public virtual void LossHealth(float Damage)
    {
        ValueHealth -= Damage;
    }
}
