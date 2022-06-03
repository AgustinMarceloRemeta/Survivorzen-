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
    [SerializeField] protected Store store;
    public float money;

    public virtual void Start()
    {
        money = PlayerPrefs.GetFloat("Money", 0);
        UpdateScoreUI();
    }
    private void Update()
    {
        
    }
    #region Score
    public void UpScore(float NewScore) 
    {
        money += NewScore;
       // PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + NewScore);
        UpdateScoreUI();
    }
    public void DownScore(float NewScore) 
    {
        money -= NewScore;
        //PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") - NewScore);
        UpdateScoreUI();
    }
    private void ResetScore()
    {
       // PlayerPrefs.SetFloat("Money", 0);
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        //moneyTxt.text = PlayerPrefs.GetFloat("Money", 0).ToString();
        moneyTxt.text = money.ToString();
    }
    #endregion

    public void ChangeLevel()
    {
        Transition.SetBool("End", true);
        Time.timeScale = 0;
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        SaveLevel();
        
    }

    public void SaveLevel()
    {     
        FindObjectOfType<PleyerHealth>().SaveHealth();
        FindObjectOfType<AimController>().SaveGuns();
        PlayerPrefs.SetFloat("Money", money);
        store.SaveSliders();
        store.SaveUpgrades();
        PlayerPrefs.Save();
    }

    public void ToMenu()
    {
        Transition.SetBool("Dead", true);
    }
}
