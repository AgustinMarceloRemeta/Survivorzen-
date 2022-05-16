using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    LineRenderer lr;
    RaycastHit hit;
    AimController Ac;
    public bool aiming;
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
        transform.rotation = Ac.findRotation();
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f) && hit.collider)
        {
            lr.SetPosition(1, hit.point);
        }
        else lr.SetPosition(1, transform.forward * 10 + transform.position);

        aiming = true;
    }
    public void aimLineDeactivate()
    {
        aiming = false;
        lr.SetPosition(1, transform.position);
        transform.rotation = Quaternion.identity;
    }
}
