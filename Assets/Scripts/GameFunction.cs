using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunction : AudioSyncer
{

    public GameObject[] pads;
    public GameObject scoreText;
    public GameObject comboText;
    public AudioSource gameAudioSource;

    public GameObject title;
    public GameObject singer;


    Queue<int> picker = new Queue<int>();
    private int picked;


    public void calculateScore()
    {
        float currentScale = pads[picked].transform.localScale.x;
        if (currentScale >= 4.5 && currentScale <= 5)
        {
            ///Debug.Log("Scale: (100)" + currentScale);
            score += 10;
            miss = false;
        }
        else if (currentScale >= 3 && currentScale <= 4)
        {
            ///Debug.Log("Scale: (50)" + currentScale);
            score += 5;
            miss = false;
        }
        else
        {
            ///Debug.Log("Scale: (miss)" + currentScale);
            miss = true;
            combo = 0;
        }

        if (!miss)
        {
            combo += 3;
        }
        scoreText.GetComponent<Text>().text = score.ToString();
        comboText.GetComponent<Text>().text = combo.ToString();
    }

    private IEnumerator MoveToScale(Vector2 _target)
    {
        Vector2 _curr = pads[picked].transform.localScale;
        Vector2 _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Vector2.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            pads[picked].transform.localScale = _curr;

            yield return null;
        }

        m_isBeat = false;
    }

    public override void OnUpdate()
	{
		base.OnUpdate();
	    if (m_isBeat) return;
        pads[picked].transform.localScale = Vector2.Lerp(pads[picked].transform.localScale, restScale, restSmoothTime * Time.deltaTime);

        if (!gameAudioSource.isPlaying)
        {
            SceneManager.LoadScene("Scoring");
            PlayerPrefs.SetString("score", scoreText.GetComponent<Text>().text);
            PlayerPrefs.SetString("combo", comboText.GetComponent<Text>().text);
            PlayerPrefs.Save();
        }
    }

    public override void OnBeat()
	{
		base.OnBeat();

        for (int i = 0; i < 2; i++)
            picker.Enqueue(Random.Range(0, 9));

        int x = picker.Dequeue();
        pads[x].GetComponent<Image>().color = Color.white;
        picked = x;

        Color custom = new Color32(184, 75, 255,200);
        pads[picker.Peek()].GetComponent<Image>().color = custom;

        StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}


    public void Start()
    {
        gameAudioSource.clip = MusicSelection.selectedAudio;
        gameAudioSource.Play();

        title.GetComponent<Text>().text = MusicSelection.selectedTitle;
        singer.GetComponent<Text>().text = MusicSelection.selectedSinger;

    }

    public Vector2 beatScale;
	public Vector2 restScale;

    private int score = 0;
    private int combo = 0;
    private bool miss = false;


}
