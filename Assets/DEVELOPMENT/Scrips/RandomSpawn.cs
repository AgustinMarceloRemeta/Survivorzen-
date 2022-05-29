using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] Vector3[] Spawners;
    void Start()
    {
        int i = Random.Range(0, Spawners.Length);
        transform.position = Spawners[i];
    }

}
