using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighManager : MonoBehaviour
{
    public float onsetTime = 60, timeForPeak = 240;

    float _timer;

    public Material highMaterial;

    private void Update ( )
    {
        _timer += Time.deltaTime;

        if(_timer > onsetTime )
        {
            float lerp = Mathf.InverseLerp (onsetTime, timeForPeak, _timer);

            highMaterial.SetFloat ("_Highness",lerp);
        }
        else
        {
            highMaterial.SetFloat ("_Highness", 0);
        }
    }
}
