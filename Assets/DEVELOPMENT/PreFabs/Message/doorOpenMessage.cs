using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenMessage : MonoBehaviour
{
    public GameObject Camerafollow;

    public void SetTargetPos()
    {
        Destroy(Camerafollow);
    }
}
