using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.GetFloat("Money", 0);
    }
    private void Update()
    {

    }
    #region Score
    void UpScore(float NewScore) // llamar desde el jugador
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + NewScore);
    }
    void DownScore(float NewScore) // llamar desde el jugador
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - NewScore);
    }
    private void ResetScore()
    {
        PlayerPrefs.SetFloat("Money", 0);
    }
    #endregion
}
