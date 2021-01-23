using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate()
        {
            OnClick(param);
        });
    }
}

public class MusicSelection : MonoBehaviour
{

    [Serializable]
    public struct Music
    {
        public string Title;
        public string Author;
        public int Difficulty;
        public AudioClip audio;
    }

    [SerializeField] Music[] allMusics;

    public GameObject SelectedTitle;
    public GameObject SelectedAuthor;
    public GameObject SelectedDifficultyA;
    public GameObject SelectedDifficultyB;
    public GameObject SelectedDifficultyC;
    public AudioSource mainAudioSource;

    // Start is called before the first frame update
    void Start()
    {

        GameObject musicItemTemplate = transform.GetChild(0).gameObject;
        GameObject instanceObj;
        int musicCount = allMusics.Length;


        for (int i = 0; i < musicCount; i++)
        {
            instanceObj = Instantiate(musicItemTemplate, transform);
            instanceObj.transform.GetChild(0).GetComponent<Text>().text = allMusics[i].Title;
            instanceObj.transform.GetChild(1).GetComponent<Text>().text = allMusics[i].Author;

            if(allMusics[i].Difficulty == 1)
            {
                instanceObj.transform.GetChild(4).GetComponent<RawImage>().enabled = true;
                instanceObj.transform.GetChild(5).GetComponent<RawImage>().enabled = false;
                instanceObj.transform.GetChild(6).GetComponent<RawImage>().enabled = false;
            } 
            else if(allMusics[i].Difficulty == 2)
            {
                instanceObj.transform.GetChild(4).GetComponent<RawImage>().enabled = true;
                instanceObj.transform.GetChild(5).GetComponent<RawImage>().enabled = true;
                instanceObj.transform.GetChild(6).GetComponent<RawImage>().enabled = false;
            }
            else if (allMusics[i].Difficulty == 3)
            {
                instanceObj.transform.GetChild(4).GetComponent<RawImage>().enabled = true;
                instanceObj.transform.GetChild(5).GetComponent<RawImage>().enabled = true;
                instanceObj.transform.GetChild(6).GetComponent<RawImage>().enabled = true;
            }
            else
            {
                instanceObj.transform.GetChild(4).GetComponent<RawImage>().enabled = false;
                instanceObj.transform.GetChild(5).GetComponent<RawImage>().enabled = false;
                instanceObj.transform.GetChild(6).GetComponent<RawImage>().enabled = false;
            }

            instanceObj.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(musicItemTemplate);
    }

    public void ItemClicked(int itemIndex)
    {
        mainAudioSource.Stop();
        SelectedTitle.GetComponent<Text>().text = allMusics[itemIndex].Title;
        SelectedAuthor.GetComponent<Text>().text = allMusics[itemIndex].Author;

        if (allMusics[itemIndex].Difficulty == 1)
        {
            SelectedDifficultyA.GetComponent<Image>().enabled = true;
            SelectedDifficultyB.GetComponent<Image>().enabled = false;
            SelectedDifficultyC.GetComponent<Image>().enabled = false;
        }
        else if (allMusics[itemIndex].Difficulty == 2)
        {
            SelectedDifficultyA.GetComponent<Image>().enabled = true;
            SelectedDifficultyB.GetComponent<Image>().enabled = true;
            SelectedDifficultyC.GetComponent<Image>().enabled = false;
        }
        else if (allMusics[itemIndex].Difficulty == 3)
        {
            SelectedDifficultyA.GetComponent<Image>().enabled = true;
            SelectedDifficultyB.GetComponent<Image>().enabled = true;
            SelectedDifficultyC.GetComponent<Image>().enabled = true;
        }
        else
        {
            SelectedDifficultyA.GetComponent<Image>().enabled = false;
            SelectedDifficultyB.GetComponent<Image>().enabled = false;
            SelectedDifficultyC.GetComponent<Image>().enabled = false;
        }

        mainAudioSource.clip = allMusics[itemIndex].audio;
        mainAudioSource.Play();
    }
}
