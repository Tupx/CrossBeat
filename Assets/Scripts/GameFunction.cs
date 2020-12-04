using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameFunction : AudioSyncer
{

    public GameObject[] pads;
    public GameObject scoreText;
    public GameObject comboText;

    Queue<int> picker = new Queue<int>();
    private int picked;
    private float currentScale;

    public void calculateScore()
    {
        currentScale = pads[picked].transform.localScale.x;
        
        if(currentScale >= 1 && currentScale < 3)
        {
            combo = 0;
        } 
        else
        {
            if (currentScale > 4.5 && currentScale <= 5)
            {
                ///Debug.Log("Scale: (100)" + currentScale);
                score += 5;
                combo += 5;
                miss = false;
            }
            else if (currentScale >= 3 && currentScale < 4.5)
            {
                ///Debug.Log("Scale: (50)" + currentScale);
                score += 3;
                combo += 3;
                miss = false;
            }

            scoreText.GetComponent<Text>().text = score.ToString();
            comboText.GetComponent<Text>().text = combo.ToString();
        }

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

        
    }

	public override void OnBeat()
	{
		base.OnBeat();

        picker.Enqueue(Random.Range(0, 9));

        int x = picker.Dequeue();
        pads[x].GetComponent<Image>().color = Color.white;
        picked = x;

        pads[picker.Peek()].GetComponent<Image>().color = Color.green;

        StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}

    public void Start()
    {
        picker.Enqueue(Random.Range(0, 9));
    }

    public Vector2 beatScale;
	public Vector2 restScale;

    private int score = 0;
    private int combo = 0;
    private bool miss = false;


}
