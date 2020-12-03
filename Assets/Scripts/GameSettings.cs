using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    public Animator musicAnimation;

    public void PlayGame()
    {
        Debug.Log("Clicked Play");
        StartCoroutine(FadeAudioScene("MusicSelection"));
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    public void  OpenSettings()
    {
        Debug.Log("Clicked Settings");
        Toast.Instance.Show("Settings Coming Soon");
    }

    public void OpenAchievements()
    {
        Debug.Log("Clicked Achievements");
        Toast.Instance.Show("Achievements Coming Soon");
    }

    public void OpenAccount()
    {
        Debug.Log("Clicked Account");
        Toast.Instance.Show("Account Coming Soon");
    }

    public void ComingSoon()
    {
        Toast.Instance.Show("Coming Soon");
    }

    public void FinalPlayGame()
    {
        Toast.Instance.Show("G na XD");
    }


    // Other Functions
    IEnumerator FadeAudioScene(string scene)
    {
        musicAnimation.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

}
