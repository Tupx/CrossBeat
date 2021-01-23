using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MusicSelection : MonoBehaviour
{   
    [Serializable]
    public struct Music
    {
        public string Title;
        public string Author;
        public int Difficulty;
        public AudioSource audio;
    }

    [SerializeField] Music[] allMusics;

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
        }

        Destroy(musicItemTemplate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
