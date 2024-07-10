using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVApplier : MonoBehaviour
{
    public Camera cam;

    private void Start ( )
    {
        cam.fieldOfView = OptionsData.Saved.fov;
    }
}
