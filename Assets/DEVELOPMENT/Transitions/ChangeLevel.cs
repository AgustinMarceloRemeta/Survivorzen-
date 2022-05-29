using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] List <Enemy> EnemysToChange;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemysToChange.RemoveAll(Zombie => !Zombie.isAlive);
            if (!EnemysToChange.Any())
            {
                GameManager manager = FindObjectOfType<GameManager>();
                manager.ChangeLevel();
            }
        }
    }
}
