using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyTxt;

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
}
