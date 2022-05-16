using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public NavMeshAgent Nav;
    protected GameObject Player;
    [SerializeField] float DistanceToPursue, DistanceToStop;
    public float Cooldown;
    protected bool atacking = false;

    [Header("Animation")]
    protected Animator _animator;
    protected int animSpeedID;

    [Header("Health")]
    protected EnemyHealth health;
    public bool isAlive =true;

    public virtual void Start()
    {
        animSpeedID = Animator.StringToHash("Speed");
        Nav = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
        _animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public virtual void Mov()
    {
        if (!isAlive) return;
        if (!atacking && Vector3.Distance(transform.position, Player.transform.position) < DistanceToPursue && Vector3.Distance(transform.position, Player.transform.position) > DistanceToStop )
        {
            Nav.SetDestination(Player.transform.position);
            transform.LookAt(Player.transform);
            _animator.SetFloat(animSpeedID, Nav.speed);
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
            health.LossHealth(other.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
    }
}
