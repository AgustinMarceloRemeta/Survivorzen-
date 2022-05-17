using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class AimController : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField] private Transform target;
    private float targetposZ;
    [SerializeField] private Transform gun;

    [Header("Shoot")]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float  bulletImpulse = 10f;
    [SerializeField] private float  damage = 25f;
    private bool canshot = true;

    [Header("Input")]
    [SerializeField] private FixedJoystick fixedJoystick;
    public float sensivility;
    private float angle;

    //ThirdPersonController
    private ThirdPersonController _controller;

    [Header("Animation")]
    private AnimationState ShotState;
    private Animator _animator;
    private int _animShot;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _animShot = Animator.StringToHash("Shoot");
        _controller = GetComponent<ThirdPersonController>();
        targetposZ = target.localPosition.z;
    }

    void Update() => angleUpdate();

    public void angleUpdate() => angle = Vector2.SignedAngle(fixedJoystick.Direction, new Vector2(transform.forward.x, transform.forward.z));

    public void aim()
    {
        if (!canshot || fixedJoystick.Direction.magnitude < sensivility) return;
        if (angle > -100 && angle <= 100) target.localPosition = RotateVector3(target.localPosition);
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
            angleUpdate();
            target.localPosition = RotateVector3(target.localPosition);
        }
    }

    private Vector3 RotateVector3(Vector3 vector)
    {
        Vector3 v = new Vector3();
        v.x = vector.x * Mathf.Cos(-angle * Mathf.Deg2Rad) - vector.z * Mathf.Sin(-angle * Mathf.Deg2Rad);
        v.z = vector.x * Mathf.Sin(-angle * Mathf.Deg2Rad) + vector.z * Mathf.Cos(-angle * Mathf.Deg2Rad);
        v.y = vector.y;
        return v;
    }
    public Quaternion findRotation()
    {
        Quaternion rot = Quaternion.Euler(transform.rotation.eulerAngles.x, Vector2.SignedAngle(fixedJoystick.Direction, Vector2.up), transform.rotation.eulerAngles.z);
        return rot;
    }

    public void shotAnim()
    {
        if (!canshot) return;
        _controller.shooting = true;
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animShot, true);
        canshot = false;
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(bulletPref, gun.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(gun.forward * bulletImpulse, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().SetDamage(damage);
        Destroy(bullet, 2);
    }

    public void FinishShot()
    {
        _animator.SetBool(_animShot, false);
        _animator.SetLayerWeight(1, 0f);
        target.localPosition = new Vector3(0, target.localPosition.y, targetposZ);
        canshot = true;
        _controller.shooting = false;
    }
    public void attackSpeed(float speed)
    {
        ShotState.speed = speed;
    }

}
