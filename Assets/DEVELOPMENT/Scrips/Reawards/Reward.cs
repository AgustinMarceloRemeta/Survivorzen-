using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int Money;
    [SerializeField] int Min, Max;
    private void Start()    
    {
        Money = Random.Range(Min, Max);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().UpScore(Money);
            Destroy(gameObject);
        }
        
    }
}
