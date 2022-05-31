using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FixedJoystick : Joystick, IPointerDownHandler, IDragHandler, IPointerUpHandler, ICancelHandler
{
    AimController aimController;
    Lazer lazer;
    bool aiming;

    protected override void Start()
    {
        aimController = FindObjectOfType<AimController>();
        lazer = GameObject.FindGameObjectWithTag("Lazer").GetComponent<Lazer>();
        base.Start();
    }


    private void Update()
    {
        if (Direction.magnitude > aimController.sensivility && aiming)
        {
            lazer.aimLineActivate();
            if (PlayerPrefs.GetInt("ShootAssist", 0) == 1)
            {
                aimController.aim();
                aimController.shotAnim();
                aimController.aiming = false;
            }
        }
        else
        {
            lazer.aimLineDeactivate();
        }
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            aiming = false;
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
            lazer.aimLineDeactivate();
        }

    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        aiming = true;
    }
    public override void OnDrag(PointerEventData eventData)
    {
        if (!aiming) return;
        base.OnDrag(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (aiming)
        {
            aimController.aim();
            aimController.shotAnim();
            aimController.aiming = false;
            lazer.aimLineDeactivate();
        }
        base.OnPointerUp(eventData);
        aiming = false;
    }

    public void OnCancel(BaseEventData eventData)
    {
        
    }
}