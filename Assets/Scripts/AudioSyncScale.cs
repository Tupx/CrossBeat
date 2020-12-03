
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{

	private IEnumerator MoveToScale(Vector2 _target)
	{
		Vector2 _curr = transform.localScale;
		Vector2 _initial = _curr;
		float _timer = 0;

		while (_curr != _target)
		{
			_curr = Vector2.Lerp(_initial, _target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			transform.localScale = _curr;

			yield return null;
		}

		m_isBeat = false;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;
		transform.localScale = Vector2.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
	}

	public override void OnBeat()
	{
		base.OnBeat();

		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}

	public Vector2 beatScale;
	public Vector2 restScale;
}