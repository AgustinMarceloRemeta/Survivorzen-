using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public NavMeshAgent Nav;
    protected GameObject Player;
    [SerializeField] protected float DistanceToPursue, DistanceToStop;
    public float damage;
    protected bool attacking = false;

    [Header("Animation")]
    protected Animator _animator;
    protected int animSpeedID;
    protected int animhit;
    protected int animDead;

    [Header("Health")]
    protected EnemyHealth health;
    public bool isAlive =true;


    public virtual void Start()
    {
        _animator = GetComponent<Animator>();
        animSpeedID = Animator.StringToHash("Speed");
        animhit = Animator.StringToHash("hit");
        animDead = Animator.StringToHash("Dead");
        Nav = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        Player = FindObjectOfType<PleyerHealth>().gameObject;
        
    }

    public virtual void Mov()
    {
        if (!isAlive) return;
        if (!attacking && Vector3.Distance(transform.position, Player.transform.position) < DistanceToPursue && Vector3.Distance(transform.position, Player.transform.position) > DistanceToStop )
        {
            Nav.SetDestination(Player.transform.position);
            transform.LookAt(Player.transform);
            if (_animator.GetFloat(animSpeedID) == 0) _animator.SetFloat(animSpeedID, Nav.speed);
        }
        else
        {
            _animator.SetFloat(animSpeedID, 0);
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceToStop)
        {
            Nav.SetDestination(transform.position);
            transform.LookAt(Player.transform);
            Attack();
        }
    }

    public abstract void Attack();
    public abstract void AttackFinish();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            health.LossHealth(bullet.damage);
            _animator.SetLayerWeight(1, 1f);
            _animator.SetBool(animhit, true);
            if(!bullet.sniper) Destroy(other.gameObject);
        }
    }
    public virtual void HitAnimFinish()
    {
        _animator.SetBool(animhit, false);
        _animator.SetLayerWeight(1, 0);
    }

    public virtual void Die()
    {
        AttackFinish();
        _animator.SetBool(animDead, true);
        _animator.SetFloat(animSpeedID, 0);
        Nav.SetDestination(transform.position);
        isAlive = false;
        GetComponent<Collider>().enabled = false;
        
    }
    public virtual void AnimDeathFinish()
    {
        Destroy(gameObject);
    }

}
