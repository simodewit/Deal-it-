using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CokeCounter : MonoBehaviour
{
    public Image cokeBag;

    public Color noCokeColor;

    public GameObject cokeObject;
    public Transform cokeParent;


    public void SetCokeCounter(int cokeAmount )
    {
        foreach ( Transform child in cokeParent )
        {
            Destroy (child.gameObject);
        }

        cokeBag = Instantiate (cokeObject, cokeParent).GetComponent<Image> ( );
        for ( int i = 1; i < cokeAmount; i++ )
        {
            Instantiate (cokeObject, cokeParent);
        }

        if (cokeAmount == 0 )
        {
            cokeBag.color = noCokeColor;
        }
        else
        {
            cokeBag.color = Color.white;
        }

    }

}
