using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]GameObject On, Off;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        On.SetActive(true);
        Off.SetActive(false);
            Destroy(gameObject);
        }
    }
}
