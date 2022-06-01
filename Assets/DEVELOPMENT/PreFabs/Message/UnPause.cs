using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnPause : MonoBehaviour
{
    [SerializeField]GameObject message;
    public void unPause()
    {
        Time.timeScale = 1;
        
    }
    public void DestroyMessage()
    {
        Destroy(message);
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
