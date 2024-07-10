using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI cokeDealtText;
    public TextMeshProUGUI timeSurvivedText;

    public void SetCokeDealtAmount(float cokeDealt )
    {
        cokeDealtText.text = $"Coke dealt: {cokeDealt:F1} G's";
    }

    public void SetTimeAliveAmount(float secondsAlive )
    {
        timeSurvivedText.text = $"Caught {FormatTime (secondsAlive)} after entering club!";
    }
    public void EnableScreen(bool enable )
    {
        gameObject.SetActive (enable);
    }
    public void Replay ( )
    {
        SceneManager.LoadScene ("Main Scene");
    }

    public void ToMenu ( )
    {
        SceneManager.LoadScene ("Main Menu");
    }

    private string FormatTime(float seconds )
    {
        TimeSpan span = TimeSpan.FromSeconds (seconds);

        return span.ToString ("hh':'mm':'ss");
    }
}
