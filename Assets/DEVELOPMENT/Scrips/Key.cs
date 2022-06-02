using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]GameObject On, Off;
    [SerializeField]GameObject message;
    [SerializeField] GameObject CameraFollow;

    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(message).GetComponent<doorOpenMessage>().Camerafollow = CameraFollow;
            Time.timeScale = 0;
            On.SetActive(true);
            Off.SetActive(false);
            CameraFollow.SetActive(true);
            CameraFollow.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}
