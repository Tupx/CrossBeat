using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{ 
    public void PlayGame()
    {
        Debug.Log("Clicked Play");
    }

    public static void ExitGame()
    {
        Debug.Log("Exit Game");
    }

    public void  OpenSettings()
    {
        Debug.Log("Clicked Settings");
        Application.Quit();
    }

    public void OpenAchievements()
    {
        Debug.Log("Clicked Achievements");
    }

    public void OpenAccount()
    {
        Debug.Log("Clicked Account");
    }

}
