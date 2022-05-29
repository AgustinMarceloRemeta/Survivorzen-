using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EnemyRunner : EnemyMelee
{
    protected bool alert;
    protected int animAlert;

    public AudioClip alertClip;
    public override void Start()
    {
        base.Start();
        animAlert = Animator.StringToHash("alert");
    }
    public override void Mov()
    {
        if (!isAlive) return;
        {
            if (!attacking && Vector3.Distance(transform.position, Player.transform.position) < DistanceToPursue && Vector3.Distance(transform.position, Player.transform.position) > DistanceToStop)
            {
                _animator.SetBool(animAlert, true);
                ZombieAlert();
                if (alert || Player.GetComponent<StarterAssetsInputs>().sprint || Player.GetComponent<ThirdPersonController>().shooting)
                {
                    alert = true;
                    _animator.SetBool(animAlert, false);
                    Nav.SetDestination(Player.transform.position);
                    transform.LookAt(Player.transform);
                    _animator.SetFloat(animSpeedID, Nav.speed);
                    Zombiefollow();
                }
            }
            else
            {
                Nav.SetDestination(transform.position);
                _animator.SetBool(animAlert, false);
                _animator.SetFloat(animSpeedID, 0);
                Zombieidle();
            }
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < DistanceToStop)
        {
            alert = true;
            Nav.SetDestination(transform.position);
            transform.LookAt(Player.transform);
            Attack();
        }
    }
    public virtual void ZombieAlert()
    {
        if (audioSource.clip == alertClip || attacking) return;
        audioSource.loop = true;
        audioSource.clip = alertClip;
        audioSource.volume = 1f;
        audioSource.Play();
    }
}
