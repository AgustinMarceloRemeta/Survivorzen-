using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject CameraFollow;
    GameManagerLvl3 manager;
    private void Start()
    {
        manager = FindObjectOfType<GameManagerLvl3>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //   Time.timeScale = 0;
            Destroy(manager.Zone3);
            CameraFollow.SetActive(true);
            CameraFollow.transform.SetParent(null);
            StartCoroutine(DelayFinish(2));
        }
    }

    IEnumerator DelayFinish(int delay)
    {
        yield return new WaitForSeconds(delay);
        manager.ChangeLevel();
    }

}
