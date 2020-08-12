using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    //Creates public method that can exit the game.
    //Also prints to console if the game is being run in editor (since application.quit
    //only works in .exe files).

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting.");
    }
}
