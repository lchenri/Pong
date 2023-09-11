using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    public int targetFps = 60;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = targetFps;
        QualitySettings.vSyncCount = 120;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
