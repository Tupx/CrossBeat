using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject comboText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = PlayerPrefs.GetString("score");
        comboText.GetComponent<Text>().text = PlayerPrefs.GetString("score");
    }

}
