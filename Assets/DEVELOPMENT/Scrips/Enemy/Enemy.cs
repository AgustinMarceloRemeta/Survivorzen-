using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement")]
    NavMeshAgent Nav;
    GameObject Player;
    [SerializeField] float DistanceToPursue, DistanceToStop;
    public float Cooldown;
    protected bool atacking = false;

    [Header("Animation")]
    protected Animator _animator;
    protected int animSpeedID;

    public virtual void Start()
    {
        animSpeedID = Animator.StringToHash("Speed");
        Nav = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    public virtual void Mov()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceToPursue && Vector3.Distance(transform.position, Player.transform.position) > DistanceToStop && !atacking)
        {
            Nav.SetDestination(Player.transform.position);
            transform.LookAt(Player.transform);
            _animator.SetFloat(animSpeedID, Nav.speed);
        }
        else
        {
            _animator.SetFloat(animSpeedID, Nav.speed);
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
}
