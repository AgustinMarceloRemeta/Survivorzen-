using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public int Money;
    public AudioClip clip;
    public GameObject message;
    [SerializeField] int Min, Max;
    private void Awake()    
    {
        
        Money = Random.Range(Min, Max);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().UpScore(Money);
            sound();
            Destroy(gameObject);
        }
        if (FindObjectOfType<GameManager>().money >= 500 && PlayerPrefs.GetInt("firstMessageSend", 0) == 0)
        {
            Time.timeScale = 0;
            Instantiate(message);
            PlayerPrefs.SetInt("firstMessageSend", 1);
        }

    }
    public void sound()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1);
    }
}
