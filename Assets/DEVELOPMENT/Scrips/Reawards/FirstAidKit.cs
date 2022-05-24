using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public float heal = -50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PleyerHealth>(out PleyerHealth player))
        {
            player.LossHealth(heal);
            Destroy(gameObject);
        }

    }
}
