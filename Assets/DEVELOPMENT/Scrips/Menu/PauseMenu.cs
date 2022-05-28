using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform cameraT;
    //public Transform cameraTDefault;
    //public Transform player;
    public void resumeBtn()
    {
        Vector3 camPos = cameraT.position;
        camPos.x += 3.5f;
        cameraT.position = camPos;
        //Time.timeScale = 1;
    }
    public void pauseBtn()
    {
        Vector3 camPos = cameraT.position;
        camPos.x -= 3.5f;
        cameraT.position = camPos;
        //Time.timeScale = 0;
    }
    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
