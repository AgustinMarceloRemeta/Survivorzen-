using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FixedJoystick : Joystick, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    AimController aimController;
    Lazer lazer;

    protected override void Start()
    {
        aimController = FindObjectOfType<AimController>();
        lazer = GameObject.FindGameObjectWithTag("Lazer").GetComponent<Lazer>();
        base.Start();
    }


    private void Update()
    {
        if (Direction.magnitude > aimController.sensivility) 
        {
            lazer.aimLineActivate();
            if(PlayerPrefs.GetInt("ShootAssist", 0) == 1) 
            {
                aimController.aim();
                aimController.shotAnim();
                aimController.aiming = false;
            }
        } 
        else lazer.aimLineDeactivate();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        aimController.aim();
        aimController.shotAnim();
        aimController.aiming = false;
        lazer.aimLineDeactivate();
        base.OnPointerUp(eventData);
    }
}