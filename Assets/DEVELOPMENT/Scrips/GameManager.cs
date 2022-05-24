using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    void Start()
    {
        PlayerPrefs.GetFloat("Score", 0);
    }
    private void Update()
    {

    }
    void UpScore(float NewScore) // llamar desde el jugador
    {
        PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + NewScore);
    }
    private void ResetScore()
    {
        PlayerPrefs.SetFloat("Score", 0);
    }
}
