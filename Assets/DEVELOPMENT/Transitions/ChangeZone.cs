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
            PlayerPrefs.SetInt("Zone", PlayerPrefs.GetInt("Zone") + 1);
            ZoneOn.SetActive(true);
            Destroy(ZoneOff);
            FindObjectOfType<GameManager>().SaveLevel();
            FindObjectOfType<InterstitialAd>().ShowAd();
            Destroy(gameObject);
        }
    }
}
