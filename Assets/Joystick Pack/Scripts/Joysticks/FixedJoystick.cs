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
        lazer = FindObjectOfType<Lazer>();
        base.Start();
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        if (Direction.magnitude > aimController.sensivility) lazer.aimLineActivate();
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