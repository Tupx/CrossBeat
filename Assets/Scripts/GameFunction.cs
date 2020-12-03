using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameFunction : AudioSyncer
{

    public GameObject[] pads;
    private int picker;

    private IEnumerator MoveToScale(Vector2 _target)
    {
        Vector2 _curr = pads[picker].transform.localScale;
        Vector2 _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Vector2.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            pads[picker].transform.localScale = _curr;

            yield return null;
        }

        m_isBeat = false;
    }

    public override void OnUpdate()
	{
		base.OnUpdate();
	    if (m_isBeat) return;
        pads[picker].transform.localScale = Vector2.Lerp(pads[picker].transform.localScale, restScale, restSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();
        picker = Random.Range(0,9);
		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}

	public Vector2 beatScale;
	public Vector2 restScale;

}
