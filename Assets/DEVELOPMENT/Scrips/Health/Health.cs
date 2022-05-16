using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class  Health : MonoBehaviour
{
    [SerializeField] float ValueHealth;
    public virtual void LossHealth(float Damage)
    {
        ValueHealth -= Damage;
    }
}
