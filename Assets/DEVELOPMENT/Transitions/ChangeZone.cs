using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeZone : MonoBehaviour
{
   [SerializeField] GameObject ZoneOff, ZoneOn;
    private void OnTriggerEnter(Collider other)
    {        
       if(other.gameObject.CompareTag("Player"))
        {
            ZoneOn.SetActive(true);
            ZoneOff.SetActive(false);
        }
    }
}
