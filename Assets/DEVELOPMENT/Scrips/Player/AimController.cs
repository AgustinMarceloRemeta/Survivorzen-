using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.Animations.Rigging;
public class AimController : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField] private Transform target;
    private float targetposZ;
    [SerializeField] private Transform[] shootTransforms;

    [Header("Shoot")]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private float  bulletImpulse = 10f;
    [SerializeField] private float  damage = 25f;
    [SerializeField] public int  gun = 0;
    [SerializeField] private GameObject[]  guns;
    [SerializeField] private GameObject OgunActive;
    [SerializeField] public Gun gunActive;
    private int shootMade = 0;
    private int bullets;
    [SerializeField] private Text bulletsTx;

    private bool canshot = true;
    public bool aiming = true;


    [Header("Input")]
    [SerializeField] private FixedJoystick fixedJoystick;
    public float sensivility;
    private float angle;

    //ThirdPersonController
    private ThirdPersonController _controller;

    [Header("Animation")]
    private Animator _animator;
    private int _animShot;
    private int _animFireRate;
    private int _animGun;
    private int _animReload;
    private int _animHit;
    private int _animDie;
    [SerializeField] private Rig rig;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _animShot = Animator.StringToHash("Shoot");
        _animFireRate = Animator.StringToHash("fireRate");
        _animGun = Animator.StringToHash("Gun");
        _animReload = Animator.StringToHash("Reload");
        _animHit = Animator.StringToHash("Hit");
        _animDie = Animator.StringToHash("Die");
        _controller = GetComponent<ThirdPersonController>();
        targetposZ = target.localPosition.z;


        //gun
        UpdateGun();
    }



    void Update() 
    {
        angleUpdate();
        if (fixedJoystick.Direction.magnitude > sensivility) aiming = true;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(1);
        }
    }

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

    public void ChangeGun(int gun)
    {
        _animator.SetInteger(_animGun, gun);
        OgunActive.SetActive(false);
        OgunActive = guns[gun];
        OgunActive.SetActive(true);
        UpdateGun();
        this.gun = gun;
    }
    private void UpdateGun()
    {
        gunActive = OgunActive.GetComponent<Gun>();
        bulletImpulse = gunActive.fireVelocity;
        damage = gunActive.damage;
        bulletPref = gunActive.bulletPref;
        bullets = gunActive.magazine;
        bulletsTx.text = bullets.ToString();
        shootTransforms = gunActive.fireTransforms;
        _animator.SetFloat(_animFireRate, gunActive.fireRate);
        canshot = true;
        
    }
    public void ReloadAnim()
    {
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animReload, true);
        canshot = false;
    }
    
    public void Reload()
    {
        
        _animator.SetLayerWeight(1, 0f);
        _animator.SetBool(_animReload, false);
        bullets = gunActive.magazine;
        bulletsTx.text = bullets.ToString();
        canshot = true;
    }
    public void shotAnim()
    {
        bool cancel = aiming && fixedJoystick.Direction.magnitude < sensivility;
        if (!canshot || cancel) return;
        _controller.shooting = true;
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animShot, true);
        
        canshot = false;
    }

    //animation events
    public void Shot()
    {
        if (gun == 1)
        {
            for (int i = 0; i < gunActive.numberOfShots; i++)
            {
                GameObject bullet = Instantiate(bulletPref, shootTransforms[i].position, Quaternion.identity);
                //bullet.GetComponent<Rigidbody>().AddRelativeForce(shootTransform.forward * bulletImpulse, ForceMode.Impulse);
                bullet.GetComponent<Rigidbody>().velocity = shootTransforms[i].forward * bulletImpulse;
                bullet.GetComponent<Bullet>().SetDamage(damage);
                Destroy(bullet, gunActive.fireDistance / bulletImpulse);
            }
        }
        else
        {
            GameObject bullet = Instantiate(bulletPref, shootTransforms[0].position, Quaternion.identity);
            //bullet.GetComponent<Rigidbody>().AddRelativeForce(shootTransform.forward * bulletImpulse, ForceMode.Impulse);
            bullet.GetComponent<Rigidbody>().velocity = shootTransforms[0].forward * bulletImpulse;
            bullet.GetComponent<Bullet>().SetDamage(damage);
            Destroy(bullet, gunActive.fireDistance / bulletImpulse);
        }
        shootMade++;
        bullets--;
        bulletsTx.text = bullets.ToString();
    }
    public void FinishShot()
    {
        if (gun == 0 && shootMade < gunActive.numberOfShots && bullets > 0) return;
        _animator.SetBool(_animShot, false);
        _animator.SetLayerWeight(1, 0f);
        target.localPosition = new Vector3(0, target.localPosition.y, targetposZ);
        canshot = true;
        _controller.shooting = false;
        shootMade = 0;
        if (bullets == 0) canshot = false;
        
    }
    public void AnimHit()
    {
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animHit, true);
        canshot = false;
    }
    public void AnimHitFinish()
    {
        _animator.SetLayerWeight(1, 0f);
        _animator.SetBool(_animHit, false);
        canshot = true;
    }
    public void AnimDead()
    {
        _animator.SetBool(_animDie, true);
        canshot = false;
        _controller.IsAlive = false;
    }

}
