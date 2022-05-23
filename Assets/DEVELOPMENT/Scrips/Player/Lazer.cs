using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    LineRenderer lr;
    RaycastHit hit;
    AimController Ac;
    public bool aiming;
    public float lazerDistance;
    public GameObject[] shotgunlazer;
    public bool father;
    void Start()
    {
        
        lr = GetComponent<LineRenderer>();
        Ac = GetComponentInParent<AimController>();
    }
    void Update()
    {
        lr.SetPosition(0, transform.position);
        if (!aiming) lr.SetPosition(1, transform.position);
    }
    public void aimLineActivate()
    {
        if (father)
        {
            
            if (Ac.gun == 1)
            {
                
                for (int i = 0; i < Ac.gunActive.numberOfShots - 1; i++)
                {
                    shotgunlazer[i].SetActive(true);
                    Lazer lazer = shotgunlazer[i].GetComponent<Lazer>();
                    lazer.father = false;
                    lazer.lazerDistance = Ac.gunActive.fireDistance;
                    lazer.aimLineActivate();
                }
            }
            
            lazerDistance = Ac.gunActive.fireDistance;
            transform.rotation = Ac.findRotation();
        }
        
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, lazerDistance) && hit.collider)
        {
            lr.SetPosition(1, hit.point);
            if (PlayerPrefs.GetInt("ShootAssist", 0) == 2 && hit.collider.CompareTag("Enemy"))
            {
                Ac.aim();
                Ac.shotAnim();
            }
        }
        else lr.SetPosition(1, transform.forward * lazerDistance + transform.position);
        aiming = true;
    }
    public void aimLineDeactivate()
    {
        if (father)
        {
            if (Ac.gun == 1)
            {
                for (int i = 0; i < Ac.gunActive.numberOfShots - 1; i++)
                {
                    shotgunlazer[i].GetComponent<Lazer>().aimLineDeactivate();
                    shotgunlazer[i].SetActive(false);
                }
            }
            transform.rotation = Quaternion.identity;
        }
        aiming = false;
        lr.SetPosition(1, transform.position);
        
    }
}
