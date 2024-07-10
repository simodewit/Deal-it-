using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    public PlayerInput input;

    public void Exit ( InputAction.CallbackContext context )
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene ("Main Menu");
    }
}
