using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    [SerializeField] GameObject[] Keys;
    void Start()
    {
        Keys[Random.Range(0, Keys.Length)].SetActive(true);
    }



}
