using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLvl3 : GameManager
{
    GameObject Player;
    [SerializeField] Vector3 ZonePosition2, ZonePosition3;
    int Zone;
    public GameObject Zone1, Zone2, Zone3, ChangeZone1, ChangeZone2;
    void Awake()
    {
        
        Zone = PlayerPrefs.GetInt("Zone", 0);
        Player = GameObject.FindGameObjectWithTag("Player");       
        switch (Zone)
        {
        case 1:
                Destroy(Zone1);
                    Zone2.SetActive(true);
                Player.transform.position = ZonePosition2;
                Destroy(ChangeZone1);
                break;

       case 2:
                Destroy(Zone1);
                Zone3.SetActive(true);
                Player.transform.position = ZonePosition3;
                Destroy(ChangeZone2);
                break;

            default:
                break;
        }
    }
    
}
