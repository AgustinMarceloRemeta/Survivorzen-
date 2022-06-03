using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelAnim : StateMachineBehaviour
{
    [SerializeField] bool NextLevel, Menu;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (NextLevel) 
        {
            FindObjectOfType<InterstitialAd>().ShowAd();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        if (Menu) 
        {
            
            FindObjectOfType<InterstitialAd>().ShowAd();
            SceneManager.LoadScene(0);
        }
        
    }
}
