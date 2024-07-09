using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ScreenOptionsApplier : MonoBehaviour
{
    public Res[] resolutions;



    public void ApplyScreenOptions(OptionsData data )
    {
        int index = data.resolutionIndex;

        Screen.SetResolution (resolutions[index].width, resolutions[index].height, data.fullScreen);
    }


    [System.Serializable]
    public struct Res
    {
        public int width;
        public int height;
    }
}
