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
    protected bool Shoot = true;




    public virtual void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    public virtual void Mov()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceToPursue && Vector3.Distance(transform.position, Player.transform.position) > DistanceToStop)
        {
            Nav.SetDestination(Player.transform.position);
            transform.LookAt(Player.transform);
        }

        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceToStop)
        {
            Nav.SetDestination(transform.position);
            transform.LookAt(Player.transform);
            Attack();
        }
    }

    public virtual void Attack()
    {

    }

   public virtual IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shoot = true;
    }
}
