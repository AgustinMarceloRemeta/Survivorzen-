using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBeContinue : MonoBehaviour
{
    public void finishAnim()
    {
        SceneManager.LoadScene(0);
    }
    public void startAnim()
    {
        Time.timeScale = 1;
    }
}
