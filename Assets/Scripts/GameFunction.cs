using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameFunction : MonoBehaviour
{

    public GameObject[] pads;

	public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;
	public Color color;

	private float m_previousAudioValue;
	private float m_audioValue;
	private float m_timer;

    // Update is called once per frame
    void Update()
    {
		// update audio value
		m_previousAudioValue = m_audioValue;
		m_audioValue = AudioSpectrum.spectrumValue;

		// if audio value went below the bias during this frame
		if (m_previousAudioValue > bias &&
			m_audioValue <= bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		// if audio value went above the bias during this frame
		if (m_previousAudioValue <= bias &&
			m_audioValue > bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		m_timer += Time.deltaTime;

	}

    public virtual void OnBeat()
    {
		int picker = Random.Range(0,9);
		int r = Random.Range(0, 255);
		int g = Random.Range(0, 255);
		int b = Random.Range(0, 255);
		Debug.Log(r+","+ g + ","+ b + ",");
		Image chosenObj = pads[picker].GetComponent<Image>();
		///chosenObj.color = new Color32(r,g,b,255);
		chosenObj.color = new Color32(10,100,110,255);
	}
}
