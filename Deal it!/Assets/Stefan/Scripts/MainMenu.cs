using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen, optionsScreen, creditsScreen;

    public void PlayGame ( )
    {
        Debug.Log ("Starting Game!");
    }

    public void ToMainScreen ( )
    {
        mainScreen.SetActive (true);
        optionsScreen.SetActive (false);
        creditsScreen.SetActive (false);
    }

    public void ToOptionsScreen ( )
    {
        mainScreen.SetActive (false);
        optionsScreen.SetActive (true);
        creditsScreen.SetActive (false);
    }

    public void ToCreditsScreen ( )
    {
        mainScreen.SetActive (false);
        optionsScreen.SetActive (false);
        creditsScreen.SetActive (true);
    }

    public void Quit ( )
    {
        Debug.Log ("Quitting Game!");
        Application.Quit ( );
    }
}
