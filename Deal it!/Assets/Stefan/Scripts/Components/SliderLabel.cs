using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SliderLabel : MonoBehaviour
{
    public string format = "F1";

    public TextMeshProUGUI textElement;

    public void SetLabel(float value )
    {
        if ( textElement == null )
            return;

        textElement.text = value.ToString(format) ;
    }
}
