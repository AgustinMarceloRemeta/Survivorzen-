using System;
using System.Linq;
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
    [SerializeField] public int  gun = 0;
    [SerializeField] private GameObject[]  guns;
    [SerializeField] private GameObject OgunActive;
    [SerializeField] public Gun gunActive;
    private int shootMade = 0;
    //private int bullets;
    [SerializeField] private Text bulletsTx;

    [SerializeField]private bool canshot;
    public bool aiming = true;

    [SerializeField] private LayerMask EnemyLayer;


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


    void Awake()
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
        LoadGuns();
        UpdateGun();
    }



    void Update() 
    {
        angleUpdate();
        if (fixedJoystick.Direction.magnitude > sensivility) aiming = true;
    }

    public void angleUpdate() => angle = Vector2.SignedAngle(fixedJoystick.Direction, new Vector2(transform.forward.x, transform.forward.z));

    public void aim()
    {
        if (!canshot || (fixedJoystick.Direction.magnitude < sensivility && PlayerPrefs.GetInt("AimAssist", 0) == 0)) return;

        if (PlayerPrefs.GetInt("AimAssist", 0) == 0 || fixedJoystick.Direction.magnitude > sensivility)
        {
            if (angle > -100 && angle <= 100) target.localPosition = RotateVector3(target.localPosition,angle);
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
                angleUpdate();
                target.localPosition = RotateVector3(target.localPosition,angle);
            }
        }
        else if (fixedJoystick.Direction.magnitude < sensivility && PlayerPrefs.GetInt("AimAssist", 0) == 1)
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, gunActive.fireDistance, EnemyLayer);
           
            if (colliderArray.Length == 0) return;
            float minDistance = (transform.position - colliderArray[0].transform.position).sqrMagnitude;
            int enemytarget = 0;
            for (int i = 1; i < colliderArray.Length; i++)
            {
                float enemyDistance = (transform.position - colliderArray[i].transform.position).sqrMagnitude;
                if (enemyDistance < minDistance)
                {
                    minDistance = enemyDistance;
                    enemytarget = i;
                }
            }
            
            //var orderedByProximity = colliderArray.OrderBy(c => (transform.position - c.transform.position).sqrMagnitude).ToArray();
            Vector3 targetDirection = colliderArray[enemytarget].transform.position - transform.position;
            float assistAngle = Vector2.SignedAngle(new Vector2(targetDirection.x, targetDirection.z), new Vector2(transform.forward.x, transform.forward.z));
            //Debug.Log(assistAngle);
            if (assistAngle > -100 && assistAngle <= 100) target.localPosition = RotateVector3(target.localPosition,assistAngle);
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
                assistAngle = Vector2.SignedAngle(new Vector2(targetDirection.x, targetDirection.z), new Vector2(transform.forward.x, transform.forward.z));
                target.localPosition = RotateVector3(target.localPosition,assistAngle);
            }
        }

        
    }

    private Vector3 RotateVector3(Vector3 vector, float angle)
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
        this.gun = gun;
        UpdateGun();   
    }

    private void UpdateGun()
    {
        gunActive = OgunActive.GetComponent<Gun>();
        bulletImpulse = gunActive.fireVelocity;
        bulletPref = gunActive.bulletPref;
        //gunActive.bullets = PlayerPrefs.GetInt("gun" + gun + "bullets", gunActive.magazine);
        bulletsTx.text = gunActive.bullets.ToString();
        shootTransforms = gunActive.fireTransforms;
        canshot = true;
        if (gunActive.bullets <= 0) canshot = false;
    }
    public void ReloadAnim()
    {
        if (_controller.shooting) return;

        _animator.SetFloat(_animFireRate, gunActive.rechargerTime);
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animReload, true);
        gunActive.AudioSource.clip = gunActive.reloadClip;
        gunActive.AudioSource.pitch = gunActive.rechargerTime;
        gunActive.AudioSource.Play();
        canshot = false;
    }
    
    public void Reload()
    {
        
        _animator.SetLayerWeight(1, 0f);
        _animator.SetBool(_animReload, false);
        gunActive.bullets = gunActive.magazine;
        PlayerPrefs.SetInt("gun" + this.gun + "bullets", gunActive.bullets);
        bulletsTx.text = gunActive.bullets.ToString();
        canshot = true;
    }
    public void shotAnim()
    {
        bool cancel = aiming && fixedJoystick.Direction.magnitude < sensivility;
        if (!canshot || gunActive.bullets <=0 ||cancel) return;
        _controller.shooting = true;
        _animator.SetLayerWeight(1, 1f);
        _animator.SetBool(_animShot, true);
        
        canshot = false;
    }

    //animation events
    public void Shot()
    {
        Vector2 tempdirection = new Vector2(target.position.x - transform.position.x, target.position.z - transform.position.z);
        float bulletangle = Vector2.SignedAngle(tempdirection,Vector2.up);
        if (gun == 1)
        {
            for (int i = 0; i < gunActive.numberOfShots; i++)
            {
                GameObject bullet = Instantiate(bulletPref, shootTransforms[i].position, Quaternion.Euler(90, bulletangle, 0));
                //bullet.GetComponent<Rigidbody>().AddRelativeForce(shootTransform.forward * bulletImpulse, ForceMode.Impulse);
                bullet.GetComponent<Rigidbody>().velocity = shootTransforms[i].forward * bulletImpulse;
                bullet.GetComponent<Bullet>().SetDamage(gunActive.damage);
                Destroy(bullet, gunActive.fireDistance / bulletImpulse);
            }
        }
        else
        {
            GameObject bullet = Instantiate(bulletPref, shootTransforms[0].position, Quaternion.Euler(90, bulletangle, 0));
            //bullet.GetComponent<Rigidbody>().AddRelativeForce(shootTransform.forward * bulletImpulse, ForceMode.Impulse);
            bullet.GetComponent<Rigidbody>().velocity = shootTransforms[0].forward * bulletImpulse;
            bullet.GetComponent<Bullet>().SetDamage(gunActive.damage);
            Destroy(bullet, gunActive.fireDistance / bulletImpulse);
        }
        gunActive.AudioSource.clip = gunActive.shootClip;
        gunActive.AudioSource.pitch = 1;
        gunActive.AudioSource.Play();
        shootMade++;
        if (gun == 0 && shootMade < gunActive.numberOfShots && gunActive.bullets > 0) return;
        gunActive.bullets--;
        PlayerPrefs.SetInt("gun" + this.gun + "bullets", gunActive.bullets);
        bulletsTx.text = gunActive.bullets.ToString();
    }
    public void FinishShot()
    {
        if (gun == 0 && shootMade < gunActive.numberOfShots && gunActive.bullets > 0) return;
        _animator.SetBool(_animShot, false);
        _animator.SetLayerWeight(1, 0f);
        target.localPosition = new Vector3(0, target.localPosition.y, targetposZ);
        canshot = true;
        if (gunActive.bullets <= 0) canshot = false;
        _controller.shooting = false;
        shootMade = 0;
        
        
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
        GetComponent<PleyerHealth>().canRecibeDamage = true;
    }
    public void AnimDead()
    {
        _animator.SetBool(_animDie, true);
        canshot = false;
        _controller.IsAlive = false;
    }
    public void DeadFinish()
    {
        FindObjectOfType<GameManager>().ToMenu();
    }
    public void SaveGuns()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Gun gun = guns[i].GetComponent<Gun>();
            PlayerPrefs.SetInt("gun" + i + "bullets" + "atfinish", gun.bullets);
        } 
    }
    public void LoadGuns()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Gun gun = guns[i].GetComponent<Gun>();
            switch (i)
            {
                case 0:
                    gun.damage = PlayerPrefs.GetFloat("DamageRifle", gun.damage);
                    gun.rechargerTime = PlayerPrefs.GetFloat("ReloadRifle", gun.rechargerTime);
                    gun.numberOfShots = PlayerPrefs.GetInt("SpecialRifle", gun.numberOfShots);
                    break;
                case 1:
                    gun.damage = PlayerPrefs.GetFloat("DamageShotgun", gun.damage);
                    gun.rechargerTime = PlayerPrefs.GetFloat("ReloadShotgun", gun.rechargerTime);
                    gun.numberOfShots = PlayerPrefs.GetInt("SpecialShotgun", gun.numberOfShots);
                    break;
                case 2:
                    
                    gun.damage = PlayerPrefs.GetFloat("DamageSniper", gun.damage);
                    gun.rechargerTime = PlayerPrefs.GetFloat("ReloadSniper", gun.rechargerTime);
                    gun.magazine = PlayerPrefs.GetInt("SpecialSniper", gun.magazine);
                    break;
                default:
                    break;
            }
            gun.bullets = PlayerPrefs.GetInt("gun" + i + "bullets" + "atfinish", gun.magazine);
        }
    }
}
