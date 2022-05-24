using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;
    void Start()
    {
        
    }

    
    void Update()
    {
      
    }

     public void droop()  // llamar desde el jugador
    {
        int random = Random.Range(0, Objects.Length);
        Instantiate(Objects[random], gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
