using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTxt;
    [SerializeField] Animator Transition;

    void Start()
    {
        ResetScore();
        UpdateScoreUI();
    }
    private void Update()
    {
        
    }
    #region Score
    public void UpScore(float NewScore) // llamar desde el jugador
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + NewScore);
        UpdateScoreUI();
    }
    public void DownScore(float NewScore) // llamar desde el jugador
    {
        PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - NewScore);
        UpdateScoreUI();
    }
    private void ResetScore()
    {
        PlayerPrefs.SetFloat("Money", 0);
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        moneyTxt.text = PlayerPrefs.GetFloat("Money", 0).ToString();
    }
    #endregion

    public void ChangeLevel()
    {
        Transition.SetBool("End", true);
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }
    public void ToMenu()
    {
        Transition.SetBool("Dead", true);
    }
}
