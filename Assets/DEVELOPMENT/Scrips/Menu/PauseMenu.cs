using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform cameraT;
    public void resumeBtn()
    {
        Vector3 camPos = cameraT.localPosition;
        camPos.x = 0f;
        cameraT.localPosition = camPos;
        //Time.timeScale = 1;
    }
    public void pauseBtn()
    {
        Vector3 camPos = cameraT.localPosition;
        camPos.x = -3.5f;
        cameraT.localPosition = camPos;
        //Time.timeScale = 0;
    }
}
