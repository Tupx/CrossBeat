using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    public Animator musicAnimation;

    public void PlayGame()
    {
        StartCoroutine(FadeAudioScene("MusicSelection"));
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void  OpenSettings()
    {
        Toast.Instance.Show("Settings Coming Soon");
    }

    public void OpenAchievements()
    {
        SceneManager.LoadScene("Scoreboard");
    }

    public void OpenAccount()
    {
        Toast.Instance.Show("Account Coming Soon");
    }

    public void ComingSoon()
    {
        Toast.Instance.Show("Coming Soon");
    }

    public void FinalPlayGame()
    {
        /// FadeAudioScene("Game");
        SceneManager.LoadScene("Game");
    }


    // Other Functions
    IEnumerator FadeAudioScene(string scene)
    {
        musicAnimation.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

}
