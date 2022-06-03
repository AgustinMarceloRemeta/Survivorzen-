using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLvl3 : GameManager
{
    [SerializeField] GameObject Player1,player2,player3;
    [SerializeField] Store store1, store2, store3;
    int Zone;
    public GameObject Zone1, Zone2, Zone3, ChangeZone1, ChangeZone2;
      void Awake()
    {       
        Zone = PlayerPrefs.GetInt("Zone", 0);
       // Player = GameObject.FindGameObjectWithTag("Player");
        print(Zone);
        switch (Zone)
        {
        case 1:
                print(Zone);
                player2.SetActive(true);
                store = store2;
                // Destroy(Zone1);                
                Zone2.SetActive(true);
                Destroy(ChangeZone1);
                break;

       case 2:
                player3.SetActive(true);
                store = store3;
                // Destroy(Zone1);
                Zone3.SetActive(true);
              Destroy(ChangeZone2);
                break;

            default:
                store = store1;
                Player1.SetActive(true);
                break;
        }
    }
    
}
